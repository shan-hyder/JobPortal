using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVC.Models;

namespace JobPortalMVC.Controllers
{
    public class Register_JobSeekerController : Controller
    {
        MVCJOBPORTALEntities entityobject = new MVCJOBPORTALEntities();
        // GET: Register_JobSeeker
        public ActionResult Register_Jobseeker_Load()
        {
            JobSeekerRegister modelobject = new JobSeekerRegister();
            modelobject.Chosenquals = GetQualifications();
            return View(modelobject);
        }
        public List<Qualifications> GetQualifications()
        {
            List<Qualifications> sts = new List<Qualifications>()
            {
                new Qualifications{text="SSLC",value="SSLC",Ischecked=true},
                new Qualifications{text="PLUSTWO",value="PLUSTWO",Ischecked=false},
                new Qualifications{text="UG",value="UG",Ischecked=false},
                new Qualifications{text="PG",value="PG",Ischecked=false}
            };
            return sts;
        }
        public ActionResult Register_Click(JobSeekerRegister modelobject)
        {
            if (ModelState.IsValid)
            {


                ObjectParameter maxidob = new ObjectParameter("max_id", typeof(int));
                entityobject.get_maxlogin(maxidob);
                int maxid = Convert.ToInt32(maxidob.Value);
                int id = 0;
                if (maxid == 0)
                {
                    id = 1;
                }
                else
                {
                    id += maxid;
                }
                string qual = string.Join(",", modelobject.Chosenquals);
                modelobject.qualification = qual;
                modelobject.Chosenquals = GetQualifications();
                entityobject.register_jobseeker(id, modelobject.name, modelobject.age, modelobject.qualification, modelobject.phone, modelobject.email);
                entityobject.insert_login(id, "JOBSEEKER", modelobject.username, modelobject.password);
                modelobject.message = "Jobseeker Successfully Registered";
                return View("Register_Jobseeker_Load", modelobject);
            }
            modelobject.message = "Jobseeker Registration Failed";
            return View("Register_Jobseeker_Load", modelobject);


        }
    }
}