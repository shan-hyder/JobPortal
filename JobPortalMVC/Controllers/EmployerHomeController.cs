using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVC.Models;

namespace JobPortalMVC.Controllers
{
    public class EmployerHomeController : Controller
    {
        MVCJOBPORTALEntities3 entityobject = new MVCJOBPORTALEntities3();
        // GET: EmployerHome
        public ActionResult Employer_Load()
        {

            ViewBag.empname = Session["empname"].ToString();
            ViewBag.Statusmesg = TempData["statusmesg"];
            ViewBag.deletemsg = TempData["delete"];
            EmployerHomeModel modelobject = new EmployerHomeModel();
            int id =Convert.ToInt32(Session["employerid"]);
            var result=entityobject.get_application(id);
            List<Applications> applications = result.Select(r => new Applications
            {
                employerid = r.employerid,
                jobseekerid = r.jobseekerid,
                jobname = r.jobname,
                name = r.name,
                phone = r.phone,
                email = r.email,
                status = r.status,
                resume = r.resume
            }).ToList();
            modelobject.Applicantretreive = applications;

            var jobbyemployer = entityobject.getJobsById(id);

            List<postedJobs> postedjobs = jobbyemployer.Select(a => new postedJobs
            {
                id=a.id,
                name = a.name,
                qualification = a.qualification,
                validuntil = a.validuntil

            }).ToList();
            modelobject.allPostedjob = postedjobs;

            return View(modelobject);
        }
        [HttpPost]
        public ActionResult  UpdateStatus(int jobseekerid,int employerid,string status)
        {
            entityobject.updatestatus(employerid, jobseekerid, status);
            EmployerHomeModel modelobject = new EmployerHomeModel();

            TempData["statusmesg"] = "Status updated successfully";

            return RedirectToAction("Employer_Load");

        }
        public ActionResult Deletejob(int jobid)
        {
            entityobject.deletejob(jobid);
            TempData["delete"] = "Job deleted successfully";
            return RedirectToAction("Employer_Load");

        }
    }
}