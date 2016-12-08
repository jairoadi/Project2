using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class TablesAll
    {
        //missions
        public int missionId { get; set; }
        public string mission_name { get; set; }
        public string mission_address { get; set; }
        public string mission_language { get; set; }
        public string mission_climate { get; set; }
        public string mission_religion { get; set; }
        public string mission_flag { get; set; }

        //users
        public int userId { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }

        //missionQuestion
        public int missionquestionID { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

    }
}