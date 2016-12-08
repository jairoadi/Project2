using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class MissionController : Controller
    {
        // GET: Mission
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Missions(string mission)
        {
            if (mission == "Angola")
            {
                ViewBag.Mission = "Angola Luanda Mission";
                ViewBag.Map = "";
                ViewBag.President = "Denelson Silva";
                ViewBag.Address = "Condominio Concha, de Talatona #77";
                ViewBag.Language = "Portuguese";
                ViewBag.Climate = "Average Temperatures in Luanda, Angola. The mean annual temperature in Luanda, Angola is fairly hot at 25.1 degrees Celsius (77.2 degrees Fahrenheit). Mean monthly temperatures vary by 6.5 °C (11.7°F) which is a very low range.";          
                ViewBag.Religion = "Roman Catholics";
                ViewBag.Flag = "/Content/Images/Angolaflag.jpg";
            }
            else if (mission == "Colorado")
            {
                ViewBag.Mission = "Colorado Colorado Springs Mission";
                ViewBag.Map = "";
                ViewBag.President = "J. Patrick Anderson";
                ViewBag.Address = "4090 Center Park Drive";
                ViewBag.Language = "English";
                ViewBag.Climate = "Dry winters with an occasional wind-blown snow. Some very cold temperatures alternating with some surprisingly warm days. Windy springs with highly changeable weather, an occasional blizzard, large temperature changes and an occasional gentle soaking rain or wet snow to help nurture the grasslands.";
                ViewBag.Religion =  "Roman Catholics";
                ViewBag.Flag = "/Content/Images/USflag.jpg";
            }
            else if (mission == "Portugal")
            {
                ViewBag.Mission = "Portugal Lisbon Mission";
                ViewBag.Map = "";
                ViewBag.President = "Victor Emanuel Engelhardt Tavares";
                ViewBag.Address = "Rua Jorge Barradas 14C";
                ViewBag.Language = "European Portuguese";
                ViewBag.Climate = "Portugal is mainly characterized by a warm temperate, mediterranean climate with a distinct wet season in winter. During winter, Portugal experiences a similar temperature pattern to the Spanish coastal towns, i.e. average daytime maxima of about 16°C (61°F).";
                ViewBag.Religion = "Roman Catholics";
                ViewBag.Flag = "/Content/Images/Portugalflag.jpg";
            }
            else
            {
                ViewBag.Mission = "Unlisted Mission";
            }

            return View();
        }

        
    }
}