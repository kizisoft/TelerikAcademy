using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSumApp.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Calc(Models.CalcViewModel model)
        {
            var firstNumber = int.Parse(model.FirstNumber);
            var secondNumber = int.Parse(model.SecondNumber);
            var result = firstNumber + secondNumber;

            ViewBag.Message = "Result = " + result;

            return View("Index");
        }
    }
}