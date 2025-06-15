using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalMVC.Models
{
    public class EmployerRegister
    {
        
        public int id { get; set; }
        [Required(ErrorMessage = "invalid name")]
        public string name { get; set; }
        [EmailAddress(ErrorMessage ="invalid email")]
        public string email { get; set; }
        [Required(ErrorMessage ="invalid username")]
        public string username { get; set; }
        [Required(ErrorMessage ="invalid password")]
        public string password { get; set; }
        public string message { get; set; }
    }
}