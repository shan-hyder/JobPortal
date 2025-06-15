using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalMVC.Models
{
    public class Qualifications
    {
        public string name { get; set; }
        public bool Isselected { get; set; }
    }
    
    public class JobSeekerRegister
    {
        public List<Qualifications> Chosenquals { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string qualification{ get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string message { get; set; }
    }
}