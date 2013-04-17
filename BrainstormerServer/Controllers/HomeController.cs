using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Breainstorming.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Brainstormer";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your Brainstormer.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your Brainstormer page.";

            return View();
        }
    }
}
