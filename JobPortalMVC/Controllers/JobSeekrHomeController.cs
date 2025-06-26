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
        
        public ActionResult JobseekerHome_Load(JobseekerHome modelobject)
        {
            var jobs = entityobject.get_jobs().ToList();
            var model = new JobseekerHome
            {
                alljobs = jobs.Select(x => new Jobs
                {
                    id = x.id,
                    name = x.name,
                    qualification = x.qualification,
                    experience = x.experience,
                    salary = x.salary,
                    employerid = x.employerid,
                    employername = x.employername,
                    postdate = x.postdate,
                    validuntil = x.validuntil
                }).ToList()
            };   
            int id = Convert.ToInt32(Session["jobsid"]);       
            ViewBag.name = Session["jobsname"].ToString();
            var result = entityobject.get_jobseeker_application(id);
            return View(model);

            
        }
        
        
      
    }
}