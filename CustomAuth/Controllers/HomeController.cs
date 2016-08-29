using CustomAuth.Models;
using CustomAuth.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomAuth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize(Roles = "user,admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult Admin()
        {
            ViewBag.Message = "Admin can only view this page";

            return View();
        }

        [CustomAuthorize(Roles = "user")]
        public ActionResult Users()
        {
            ViewBag.Message = "Any User can only view this page";

            return View();
        }
        [CustomAuthorize(Roles = "user,admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult NotAuthorised()
        {
            ViewBag.Message = "You are not authorised to view this page";

            return View();
        }
        public ActionResult Session()
        {
            signout ob = new signout();
            ob.sessionabandon();
            return View("Index");
        }
    }
}