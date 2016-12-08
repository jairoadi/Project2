using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    [Table ("Missions")]
    public class Missions
    {
        [Key]
        public int missionID { get; set; }
        public string mission_name { get; set; }
        public string mission_address { get; set; }
        public string mission_language { get; set; }
        public string mission_climate { get; set; }
        public string mission_religion { get; set; }
        public string mission_flag { get; set; }
    }
}