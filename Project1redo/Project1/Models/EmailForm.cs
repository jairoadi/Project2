using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Enter Your name")]
        public string FromName { get; set; }

        [Required, Display(Name = "Enter Your email"), EmailAddress]
        public string FromEmail { get; set; }

        [Required, Display(Name = "Select subject")]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        
    }
}