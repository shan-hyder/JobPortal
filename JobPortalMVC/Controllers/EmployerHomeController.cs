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
        MVCJOBPORTALEntities1 entityobject = new MVCJOBPORTALEntities1();
        // GET: EmployerHome
        public ActionResult Employer_Load()
        {

            ViewBag.empname = Session["empname"].ToString();
            EmployerHomeModel modelobject = new EmployerHomeModel();
            int id =Convert.ToInt32(Session["employerid"]);
            entityobject.get_application(id);

            return View(modelobject);
        }

        public ActionResult Employer_PostJob_click(EmployerHomeModel modelobject)
        {
            if (ModelState.IsValid)
            {
                modelobject.employerid = Convert.ToInt32(Session["employerid"]);
                modelobject.employername = Session["employername"].ToString();
                modelobject.postdate = DateTime.Now;
                modelobject.validuntil = modelobject.postdate.AddDays(30);
                entityobject.add_job(modelobject.name, modelobject.qualification,modelobject.experience, modelobject.salary, modelobject.employerid, modelobject.employername, modelobject.postdate, modelobject.validuntil);
                modelobject.mesg = "job posted successfully";
                return View(modelobject);

            }
            modelobject.mesg = "Invalid entry";
            return View(modelobject);
        }
    }
}