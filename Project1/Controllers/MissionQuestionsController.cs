using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project1.DAL;
using Project1.Models;

namespace Project1.Controllers
{
    public class MissionQuestionsController : Controller
    {
        private MissionContext db = new MissionContext();

        // GET: MissionQuestions
        public ActionResult Index()
        {
            return View(db.MissionQuestion.ToList());
        }

        // GET: MissionQuestions/Details/5
        public ActionResult Details(int? id)
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
            return View(missionQuestions);
        }

        // GET: MissionQuestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MissionQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "missionquestionID,missionId,userId,question,answer")] MissionQuestions missionQuestions)
        {
            if (ModelState.IsValid)
            {
                db.MissionQuestion.Add(missionQuestions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(missionQuestions);
        }

        // GET: MissionQuestions/Edit/5
        public ActionResult Edit(int? id, MissionQuestions missionQuestion)
        {
            var question = db.MissionQuestion.Find(id);
            question.answer = missionQuestion.answer;
            db.MissionQuestion.Add(missionQuestion);
            db.SaveChanges();
            
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestion.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        // POST: MissionQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "missionquestionID,missionId,userId,question,answer")] MissionQuestions missionQuestions)
        {
            if (missionQuestions != null)
            {
               // var question = db.MissionQuestion.Where(dbQuest => missionQuestions.question == dbQuest.question).FirstOrDefault();
                

                db.Entry(missionQuestions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Missions","Mission");
            }
            return View(missionQuestions);
        }

        // GET: MissionQuestions/Delete/5
        public ActionResult Delete(int? id)
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
            return View(missionQuestions);
        }

        // POST: MissionQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MissionQuestions missionQuestions = db.MissionQuestion.Find(id);
            db.MissionQuestion.Remove(missionQuestions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
