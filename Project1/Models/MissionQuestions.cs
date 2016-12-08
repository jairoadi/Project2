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
    [Table ("MissionQuestions")]
    public class MissionQuestions
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int missionquestionID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int missionId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int userId { get; set; }
        [DisplayName("Question")]
        [Required (ErrorMessage="Please enter a question")]
        public string question { get; set; }
        public string answer { get; set; }

    }
}