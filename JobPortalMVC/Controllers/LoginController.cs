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
        MVCJOBPORTALEntities entityobject = new MVCJOBPORTALEntities();
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
                var msgfrom = resp.ToString();
                if(msgfrom=="code red")
                {
                    modelobject.message = "invalid login attempt";
                    return View("Page_Load", modelobject);
                }else
                {
                    ObjectParameter type= new ObjectParameter("type", typeof(string));
                    entityobject.get_user(modelobject.username, modelobject.password, type);
                    string usertype = type.ToString();
                    if(usertype== "JOBSEEKER")
                    {
                        return RedirectToAction("");
                    }
                    else
                    {
                        return RedirectToAction("");
                    }

                }

            }
            else
            {
                return View("Page_Load", modelobject);
            }

        }
    }
}