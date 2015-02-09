using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpAngularRouting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        
        // Anytime we add a route we need to add a mimic of it below. So here is our example of Test.html
        public ActionResult Test()
        {
            var result = new FilePathResult("~/Views/Home/test.html", "text/html");
            return result;
        }

    }
}
