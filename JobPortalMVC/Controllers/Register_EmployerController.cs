using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVC.Models;

namespace JobPortalMVC.Controllers
{
    public class Register_EmployerController : Controller
    {
        MVCJOBPORTALEntities1 entityobject = new MVCJOBPORTALEntities1();
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
                return View("Register_Load", modelobject);
            }
            modelobject.message = "Employer Registration failed";
            return View("Register_Load", modelobject);

        }
    }
}