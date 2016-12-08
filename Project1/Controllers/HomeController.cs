using Project1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;
using System.Web.Security;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        MissionContext db = new MissionContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Users newUser, bool rememberMe = false)
        {
            //if the model is verified
            if(newUser != null)
            {
                db.User.Add(newUser);//adding a new user object to the user table
                db.SaveChanges();//saving the data
            }
            ModelState.Clear();
            Session["userEmail"] = newUser.userEmail;
            Session["userID"] = newUser.userId;
            FormsAuthentication.SetAuthCookie(newUser.userEmail, rememberMe);

            return View();
        }
    }

      
}