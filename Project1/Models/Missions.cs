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
    [Table ("Missions")]
    public class Missions
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int missionID { get; set; }

        [DisplayName("Mission Name")]
        [HiddenInput(DisplayValue = false)]
        public string mission_name { get; set; }

        [DisplayName("Mission Name")]
        [HiddenInput(DisplayValue = false)]
        public string mission_address { get; set; }

        [DisplayName("Mission Name")]
        [HiddenInput(DisplayValue = false)]
        public string mission_language { get; set; }
        
        [DisplayName("Climate")]
        [HiddenInput(DisplayValue = false)]
        public string mission_climate { get; set; }

        [DisplayName("Dominant Religion")]
        [HiddenInput(DisplayValue = false)]
        public string mission_religion { get; set; }
        
        [DisplayName("Flag")]
        [HiddenInput(DisplayValue = false)]
        public string mission_flag { get; set; }

        [DisplayName("Map")]
        [HiddenInput(DisplayValue = false)]
        public string mission_map { get; set; }
    }
}