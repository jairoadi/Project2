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

        public ActionResult editAnswer(FormCollection form)
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateQuestion([Bind(Include = "questionID,question,answer,missionID,userID")] MissionQuestions newQuestion)
        {
            

            if (ModelState.IsValid)
            {
                var userEmail = User.Identity.Name;//this line of code will look at current user and find it's name
                var userObj = db.User.Where(m => m.userEmail == userEmail).FirstOrDefault();//After the user is found then will store it's object into the the userObj

                newQuestion.userId = userObj.userId;//assigning a useriD to the newly created question
                db.MissionQuestion.Add(newQuestion);//addint the newQuestion object to the MissionQuestion table
                db.SaveChanges();// Saving new changes

                return RedirectToAction("Missions", "Mission", newQuestion.missionId);

            }

            return View(newQuestion);
        }
    }
}