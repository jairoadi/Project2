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


        [HttpPost]
        public ActionResult CreateQuestion([Bind(Include = "questionID,question,answer,missionID,userID")] MissionQuestions newQuestion, FormCollection form)
        {


            if (newQuestion != null)
            {  
                string question = form["CreateQuestion"].ToString();
                var userEmail = User.Identity.Name;//this line of code will look at current user and find it's name
                var userObj = db.User.Where(m => m.userEmail == userEmail).FirstOrDefault();//After the user is found then will store it's object into the the userObj

                newQuestion.question = question;// now the  object question will be the form question
                newQuestion.answer = " ";
                newQuestion.userId = userObj.userId;//assigning a useriD to the newly created question
                db.MissionQuestion.Add(newQuestion);//addint the newQuestion object to the MissionQuestion table
                db.SaveChanges();// Saving new changes

                return RedirectToAction("Missions", "Mission", new { id = newQuestion.missionId });

            }

            return View(newQuestion);
        }

        // GET: MissionQuestions/Edit/5
        public ActionResult Edit(int? id, MissionQuestions missionQuestion)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestion.Find(id);


            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestion);
        }

        // POST: MissionQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "missionquestionID,missionId,userId,question,answer")] MissionQuestions missionQuestions, int? id)
        {
            if (missionQuestions != null)
            {

                var update = db.MissionQuestion.Find(id);//create a variable that is storing the question that it founds in the db
                
                update.answer = missionQuestions.answer;

                missionQuestions = update;

                db.Entry(missionQuestions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Missions", "Mission", new { id = missionQuestions.missionId });
            }
            return View(missionQuestions);
        }
    }
}