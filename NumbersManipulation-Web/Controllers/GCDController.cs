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

        //int numberFirst, int numberSecond, string algorithm
        public ActionResult GCD()
        {
            var a = ViewBag.n1;
            //if (algorithm == "Eurledian")
            //{
            //     return GCDAlgorithms.CalculateByEuclidean(numberFirst, numberSecond);
            //}

            //else
            //{
            //    return GCDAlgorithms.CalculateByStein(numberFirst, numberSecond);
            //}

            return View();

        }
    }
}