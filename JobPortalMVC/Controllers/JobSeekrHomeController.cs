using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVC.Models;

namespace JobPortalMVC.Controllers
{
    public class JobSeekrHomeController : Controller
    {
        MVCJOBPORTALEntities1 entityobject = new MVCJOBPORTALEntities1();
        // GET: JobSeekrHome
        
        public ActionResult JobseekerHome_Load()
        {
            int id = Convert.ToInt32(Session["jobseekerid"]);
            var result = entityobject.get_jobseeker_application(id);

            List<AppliedStatus> appliedStatuses = result.Select(r => new AppliedStatus
            {
                Jobname = r.jobname,
                Status = r.status
            }
            ).ToList();
            JobSeekerRegister modelobject = new JobSeekerRegister();
            modelobject.ApplyStatus = appliedStatuses;

              


            return View(modelobject);
        }
        
        
      
    }
}