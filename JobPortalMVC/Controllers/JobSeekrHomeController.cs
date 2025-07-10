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
        MVCJOBPORTALEntities3 entityobject = new MVCJOBPORTALEntities3();
        // GET: JobSeekrHome
        
        public ActionResult JobseekerHome_Load(JobseekerHome modelobject)
        {
            var jobs = entityobject.get_jobs().ToList();
            int jid = Convert.ToInt32(Session["jobsid"]);
            var applystatus = entityobject.applicationid(jid).ToList();
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
                }).ToList(),
                 appliedjobs = applystatus.Select(x => new AppliedJobs
                 {
                     jobseekerid = x.jobseekerid,
                     jobname = x.jobname,
                     employername = x.employername,
                     status = x.status

                 }).ToList()
            };
            int id = Convert.ToInt32(Session["jobsid"]);       
            ViewBag.name = Session["jobsname"].ToString();
            var result = entityobject.get_jobseeker_application(id);
            if (TempData["message"] != null)
                model.message = TempData["message"].ToString();
            return View(model);
        }
       public ActionResult Job_Apply(int JobID, string Employername, int Employerid, string Jobname, HttpPostedFileBase Resume)
        {
            int id = Convert.ToInt32(Session["jobsid"]);
            string name = Session["jobsname"].ToString();
            string phone = Session["jphone"].ToString();
            string email = Session["jemail"].ToString();

            string resumePath = null;

            if (Resume != null && Resume.ContentLength > 0)
            {
                // Unique file name
                string fileName = Guid.NewGuid().ToString() + "_" + System.IO.Path.GetFileName(Resume.FileName);

                // Full physical path
                string fullPath = Server.MapPath("~/resume/" + fileName);

                // Save file
                Resume.SaveAs(fullPath);

                // Relative path to store in DB
                resumePath = "/resume/" + fileName;
            }


                // Store relative path in DB (not file content!)
                entityobject.insert_jobapplication(
                    Employerid, id, Jobname,
                    name, phone,
                    resumePath, // now a string
                    email, Employername, "pending");
                TempData["message"] = "Successfully applied!";
            
            return RedirectToAction("JobseekerHome_Load");
        }
        public ActionResult SearchJob(string SearchTerm, JobseekerHome modelobject)
        {
            var jobs = entityobject.search_select(SearchTerm).ToList();
            int jid = Convert.ToInt32(Session["jobsid"]);
            var applystatus = entityobject.applicationid(jid).ToList();
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
                }).ToList(),
                appliedjobs = applystatus.Select(x => new AppliedJobs
                {
                    jobseekerid = x.jobseekerid,
                    jobname = x.jobname,
                    employername = x.employername,
                    status = x.status

                }).ToList()
            };


            ViewBag.name = Session["jobsname"].ToString();

            return View("JobseekerHome_Load", model);
        }
        
        
      
    }
}