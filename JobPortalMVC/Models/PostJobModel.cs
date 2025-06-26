using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalMVC.Models
{
    public  class qualification
    {
        public string Stext { get; set; }
        public string Svalue { get; set; }
        public bool Iscehcked { get; set; }

    }
    public class PostJobModel
    {
        public List<qualification> selecetedqual { get; set; }
        [Required(ErrorMessage ="Enter valid name")]
        public string name { get; set; }
        public List<string> qualification { get; set; }
        [Required(ErrorMessage = "Cannot be blank")]
        public string experience { get; set; }
        [Required(ErrorMessage ="Enter salary")]
        public int salary { get; set; }
        public int employerid { get; set; }
        public string employername { get; set; }
        public DateTime postdate { get; set; }
        public DateTime validuntil { get; set; }

        public string message { get; set; }
    }
}