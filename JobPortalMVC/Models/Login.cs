using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalMVC.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Enter valid username")]
        public string username { get; set; }
        [Required(ErrorMessage ="Enter valid password")]
        public string password { get; set; }
        
        public string message { get; set; }
    }
}