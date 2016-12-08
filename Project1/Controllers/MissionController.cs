using Project1.DAL;
using Project1.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class MissionController : Controller
    {
        private MissionContext db = new MissionContext();

        // GET: Mission
        public ActionResult Index()
        {
            var listof = db.Mission.ToList();// I'm using the listof var to hold all the missions
            ViewBag.ListMissions = listof;//storing the mission list to a viewbag since it can store "everything"
            return View();
        }

        

        [Authorize]
        public ActionResult Missions(int? id)
        {
            Missions currentMission = db.Mission.Find(id);//the parameter received will be the id used to search in the mission table
           
                if (currentMission == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    var currentMissionQuestions = db.MissionQuestion.Where(question => question.missionId == id);//the var currentMissionQuestions will store all the questions that belong to the missionID
                    
                    ViewBag.currentQuestions = currentMissionQuestions.ToList();//this viewbag will store the list of questions of missionID  
                }

            return View(currentMission);
        }

        
    }
}