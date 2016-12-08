using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Models
{
    [Table ("Users")]
    public class Users
    {
        [Key]
        [HiddenInput(DisplayValue=false)]
        public int userId { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage="Please enter Email")]
        public string userEmail { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Please enter Password")]
        [DataType (DataType.Password)]
        public string userPassword { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter First Name")]
        public string userFirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        public string userLastName { get; set; }

    }
}