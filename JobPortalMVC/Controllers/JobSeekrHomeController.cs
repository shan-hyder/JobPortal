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
            if (TempData["message"] != null)
                model.message = TempData["message"].ToString();
            return View(model);
        }
        public ActionResult Job_Apply(int JobID,string Employername,int Employerid,string Jobname,HttpPostedFileBase Resume)
        {
            int id = Convert.ToInt32(Session["jobsid"]);
            string name=Session["jobsname"].ToString();
            string phone =Session["jphone"].ToString();
            string email = Session["jemail"].ToString();
            byte[] resumeBytes = null;
            if (Resume != null && Resume.ContentLength > 0)
            {
                using (var binaryReader = new System.IO.BinaryReader(Resume.InputStream))
                {
                    resumeBytes = binaryReader.ReadBytes(Resume.ContentLength);
                }
            }
            entityobject.insert_jobapplication(Employerid, id, Jobname, name, phone, resumeBytes, email, Employername, "pending");
            JobseekerHome modelobject = new JobseekerHome();
            TempData["message"] = "Successfully applied!";
            return RedirectToAction("JobseekerHome_Load");


        }
        
        
      
    }
}