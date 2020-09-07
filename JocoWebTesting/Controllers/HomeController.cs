using JocoWebTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JocoWebTesting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Curso.DameNumeros((num) => { Console.WriteLine(num); }, 10);

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
    }
}