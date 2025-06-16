using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalMVC.Models
{
    public class Qualifications
    {
        public string text { get; set; }
        public string value { get; set; }
        public bool Ischecked { get; set; }

    }
    
    public class JobSeekerRegister
    {
        
        public string[] selectedqual { get; set; }
        public List<Qualifications> Chosenquals { get; set; }
        public string id { get; set; }
        [Required(ErrorMessage ="Enter valid name")]
        public string name { get; set; }
        [Range(18,45,ErrorMessage ="Enter valid age")]
        public int age { get; set; }
        public string qualification{ get; set; }
        [RegularExpression(@"^[6-9]\d{9}$",ErrorMessage ="Enter valid phone")]
        public string phone { get; set; }
        [EmailAddress(ErrorMessage ="Invalid email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Enter valid username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Enter valid password")]
        public string password { get; set; }
        public string message { get; set; }
    }
}