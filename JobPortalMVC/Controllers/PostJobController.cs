using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVC.Models;

namespace JobPortalMVC.Controllers
{
    public class PostJobController : Controller
    {
        MVCJOBPORTALEntities1 entityobject = new MVCJOBPORTALEntities1();
        // GET: PostJob
        public ActionResult PostJob_Load()
        {
            PostJobModel modelobject = new PostJobModel();
            modelobject.selecetedqual = getqual();
            return View(modelobject);
        }
        public ActionResult PostJob_Click(EmployerHomeModel modelobject)
        {
           if(ModelState.IsValid)
            {
                int empid=Convert.ToInt32(Session["Empid"]);
                string empname = Session["empname"].ToString();
                DateTime exp = DateTime.Now.AddDays(30);
                entityobject.add_job(modelobject.name, modelobject.qualification, modelobject.experience, modelobject.salary, empid, empname, DateTime.Now, exp);
                modelobject.mesg = "Job Posted Successfully";
                return View("Employer_Load", "EmployerHomeModel", modelobject);
            }
            modelobject.mesg = "invalid inputs";
            return View("Employer_Load", "EmployerHome", modelobject);
        }
        public List<qualification> getqual()
        {
            List<qualification> sts = new List<qualification>()
            { new qualification{Stext="SSLC",Svalue="SSLC",Iscehcked=false},
             new qualification{Stext="PLUSTWO",Svalue="PLUSTWO",Iscehcked=false},
            new qualification{Stext="BCA",Svalue="BCA",Iscehcked=false},
            new qualification{Stext="MCA",Svalue="MCA",Iscehcked=false},
            new qualification{Stext="B.TECH",Svalue="B.TECH",Iscehcked=false},
            new qualification{Stext="BSC.CS",Svalue="BSC.CS",Iscehcked=false},
            };
            return sts;

                
                
                
                
        }
    }
    
}