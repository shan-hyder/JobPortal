using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalMVC.Models
{
    public class Jobs
    {
       
        public int id { get; set; }
        public string name { get; set; }
        public string qualification { get; set; }
        public string experience { get; set; }
        public string salary { get; set; }
        public int employerid { get; set; }
        public string employername { get; set; }
   
        public DateTime postdate { get; set; }
        public DateTime validuntil { get; set; }
       
    }
    public class AppliedJobs
    {
        public int jobseekerid { get; set; }
        public string employername { get; set; }
        public string jobname { get; set; }
        public string status { get; set; }
        
    }
    public class JobseekerHome
    {
        public List<AppliedJobs> appliedjobs { get; set; }
        public string searchterm { get; set; }
        public List<Jobs> alljobs{ get; set; }
        public string message { get; set; }
    }
}