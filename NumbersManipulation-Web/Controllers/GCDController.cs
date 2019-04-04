using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NumbersManipulations;

namespace NumbersManipulation_Web.Controllers
{
    public class GCDController : Controller
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

        [HttpPost]
        public ActionResult GCD(int numberFirst, int numberSecond, string algorithm)
        {
            if (algorithm == "Eukledian")
            {
               ViewBag.Result = GCDAlgorithms.CalculateByEuclidean(numberFirst, numberSecond);
            }
            else
            {
               ViewBag.Result = GCDAlgorithms.CalculateByStein(numberFirst, numberSecond);
            }

            return View();

        }
    }
}