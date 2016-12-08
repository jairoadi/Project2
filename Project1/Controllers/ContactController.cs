using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Project1.Models;
using System.Net;
using System.Net.Mail;

namespace Project1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }

        //method for the email
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("jairoadi@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("jairoadi@gmail.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "jairoadi@gmail.com",  // replace with valid value
                        Password = "MyamaHamama"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Sent(FormCollection form)
        {
            ViewBag.Name = form["FromName"].ToString();
            ViewBag.Email = form["FromEmail"].ToString();
            ViewBag.Conc = "Thank you " + ViewBag.Name + " we will get back to you to: " + ViewBag.Email;

            return View();
        }

        
    }
}