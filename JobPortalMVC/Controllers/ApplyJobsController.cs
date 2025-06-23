using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortalMVC.Controllers
{
    public class ApplyJobsController : Controller
    {
        // GET: ApplyJobs
        public ActionResult ApplyHome_Load()
        {
            return View();
        }
        public ActionResult JobSearch()
        {
            return View();
        }
    }
}