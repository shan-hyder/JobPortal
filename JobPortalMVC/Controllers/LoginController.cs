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
        MVCJOBPORTALEntities3 entityobject = new MVCJOBPORTALEntities3();
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
                        ObjectParameter uname = new ObjectParameter("name", typeof(string));
                        entityobject.get_jobseeker_name(modelobject.username, modelobject.password, uname);
                        string name = uname.Value.ToString();
                        Session["jobsname"] = name;
                        ObjectParameter empidParam = new ObjectParameter("id", typeof(int));
                        entityobject.get_empid(modelobject.username, modelobject.password, empidParam);

                        Session["jphone"] = entityobject.get_jphone(modelobject.username, modelobject.password).FirstOrDefault();
                        Session["jemail"] = entityobject.get_jemail(modelobject.username, modelobject.password).FirstOrDefault();
                        int empid = empidParam.Value != null ? Convert.ToInt32(empidParam.Value) : 0;
                        if (empid != 0)
                        {
                            Session["jobsid"] = empid;
                        }

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
                        ObjectParameter empidParam = new ObjectParameter("id", typeof(int));
                        entityobject.get_empid(modelobject.username, modelobject.password, empidParam);

                        int empid = empidParam.Value != null ? Convert.ToInt32(empidParam.Value) : 0;
                        if (empid !=0)
                        {
                            Session["employerid"] = empid;
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