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
        MVCJOBPORTALEntities3 entityobject = new MVCJOBPORTALEntities3();
        // GET: PostJob
        public ActionResult PostJob_Load()
        {
            PostJobModel modelobject = new PostJobModel();
            modelobject.selecetedqual = getqual();
            return View(modelobject);
        }
        public ActionResult PostJob_Click(PostJobModel modelobject)
        {
           if(ModelState.IsValid)
            {
                string qual = string.Join(",", modelobject.qualification);
                int empid=Convert.ToInt32(Session["employerid"]);
                string empname = Session["empname"].ToString();
                DateTime exp = DateTime.Now.AddDays(30);
                entityobject.add_job(modelobject.name,qual, modelobject.experience, (modelobject.salary).ToString(),empid, empname, DateTime.Now, exp);
                modelobject.message = "Job Posted Successfully";
                return RedirectToAction("Employer_Load", "EmployerHome");
            }
            modelobject.selecetedqual = getqual();
            modelobject.message = "invalid inputs";
            return View("PostJob_Load", modelobject);
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