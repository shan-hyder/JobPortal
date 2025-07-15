using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVC.Models;
using System.Net;
using System.Net.Mail;

namespace JobPortalMVC.Controllers
{
    public class Register_EmployerController : Controller
    {
        MVCJOBPORTALEntities3 entityobject = new MVCJOBPORTALEntities3();
        // GET: Register_Employer
        public ActionResult Register_Load()
        {
            return View();
        }
        public ActionResult Register_Click(EmployerRegister modelobject)
        {
            if(ModelState.IsValid)
            {
                ObjectParameter maxidob = new ObjectParameter("max_id", typeof(int));
                entityobject.get_maxlogin(maxidob);
                int maxid = 0;
                int id = 0;
                if (maxidob.Value != DBNull.Value && maxidob.Value != null)
                {
                    maxid = Convert.ToInt32(maxidob.Value);
                }
                if (maxid==0)
                {
                    id = 1;
                }
                else if(maxid>0)
                {
                    id = maxid+1;
                }
                entityobject.register_employer(id, modelobject.name, modelobject.email);
                entityobject.insert_login(id,"EMPLOYER", modelobject.username, modelobject.password);
                modelobject.message = "Employer successfully registered";
                try
                {
                    SendConfirmationEmail(modelobject.email, "register Alert", "successfully registered");
                }
                catch
                {
                    ViewBag.EmailStatus = "Registration Successfull but email not send";
                }
                ViewBag.EmailStatus = "Registration successfull Confirmation email send";
                return View("Register_Load", modelobject);
            }
            modelobject.message = "Employer Registration failed";
            return View("Register_Load", modelobject);

        }
        public static void SendConfirmationEmail(string toEmail, string subject, string body)
        {
            var fromEmail = new MailAddress("shibilshanhyder@gmail.com", "jobportal");
            var to = new MailAddress(toEmail);
            var password = "yvac vpts dhmn cdma";
            var smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, password)
            };
            using (var message = new MailMessage(fromEmail, to)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }
    }
}