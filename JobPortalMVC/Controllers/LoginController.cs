using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVC.Models;

namespace JobPortalMVC.Controllers
{
    public class LoginController : Controller
    {
        MVCJOBPORTALEntities1 entityobject = new MVCJOBPORTALEntities1();
        // GET: Login
        public ActionResult Page_Load()
        { 
            return View();
        }
        public ActionResult Login_Click(Login modelobject)
        {
            if(ModelState.IsValid)
            {
                ObjectParameter resp = new ObjectParameter("msg",typeof(string));
                entityobject.login_check(modelobject.username, modelobject.password, resp);
                var msgfrom = resp.Value.ToString();
                if(msgfrom=="code red")
                {
                    modelobject.message = "invalid login attempt";
                    return View("Page_Load", modelobject);
                }else
                {
                    ObjectParameter type= new ObjectParameter("type", typeof(string));
                    entityobject.get_user(modelobject.username, modelobject.password, type);
                    string usertype = type.Value.ToString();
                    if(usertype == "JOBSEEKER")
                    {
                        return RedirectToAction("JobseekerHome_Load", "JobSeekrHome");
                    }
                    else if(usertype == "EMPLOYER")
                    {
                        ObjectParameter param = new ObjectParameter("name", typeof(string));
                        entityobject.get_empname(modelobject.username, modelobject.password, param);
                        string empname = param.Value.ToString();
                        if(empname!=null)
                        {
                            Session["empname"] = empname;
                        }
                        ObjectParameter param1 = new ObjectParameter("id", typeof(int));
                        entityobject.get_empid(modelobject.username, modelobject.password, param1);
                        int empid = Convert.ToInt32(param1.Value);
                        if (empid !=0)
                        {
                            Session["empid"] = empid;
                        }
                        return RedirectToAction("Employer_Load", "EmployerHome");
                    }

                    modelobject.message = "invalid user";
                    return View("Page_Load", modelobject);

                }

            }
            else
            {
                return View("Page_Load", modelobject);
            }

        }
    }
}