using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortalMVC.Controllers
{
    public class JobSeekrHomeController : Controller
    {
        // GET: JobSeekrHome
        public ActionResult JobseekerHome_Load()
        {
            return View();
        }
    }
}