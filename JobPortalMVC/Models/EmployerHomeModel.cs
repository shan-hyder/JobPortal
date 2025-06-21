using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalMVC.Models
{
    public class Applications
    {
        public int employerid { get; set; }
        public int jobseekerid { get; set; }
        public string jobname { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string resume { get; set; }
        public string status { get; set; }


    }
    public class EmployerHomeModel
    {
        public List<Applications> Applicantretreive { get; set; } = new List<Applications>();
        public int id { get; set; }
        [Required(ErrorMessage ="Invalid entry")]
        public string name { get; set; }
        [Required(ErrorMessage ="Invalid entry")]
        public string qualification { get; set; }
        [Required(ErrorMessage ="Invalid entry")]
        public string experience { get; set; }
        [Required(ErrorMessage ="Invalid entry")]
        public string salary { get; set; }
        public int employerid { get; set; }
        public string employername { get; set; }

        public DateTime postdate { get; set; }
        public DateTime validuntil { get; set; }
        public string mesg { get; set; }
    }
    
}