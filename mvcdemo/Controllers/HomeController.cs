using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
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

        public ActionResult More(string name="")
        {
            ViewBag.name = name;
            ViewBag.str1 = "value from controller1";
            ViewBag.str2 = "value from controller2";

            var d = new List<string>();
            d.Add(ViewBag.str1);
            d.Add(ViewBag.str2);

            ViewBag.data = d;
            ViewBag.Message = "More information";

            return View();
        }
    }
}