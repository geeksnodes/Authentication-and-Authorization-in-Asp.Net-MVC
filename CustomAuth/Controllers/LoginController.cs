using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomAuth.Models;

namespace CustomAuth.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(t_users userLogin)
        {
            CustomAuthEntities obj = new CustomAuthEntities();

            var x = obj.t_users.Where(m => m.username.Equals(userLogin.username) && m.pwd.Equals(userLogin.pwd)).FirstOrDefault();
            if (x != null)
            {
                var login = (from i in obj.t_users join j in obj.t_usersType on i.role equals j.id where i.username.Equals(userLogin.username) && i.pwd.Equals(userLogin.pwd)
                            select new UserDetails { username = i.username, role = j.roles }).FirstOrDefault();
                UserDetails userDetails = new UserDetails();
                userDetails.role = login.role;
                userDetails.username = login.username;
                Session["userDetails"] = userDetails;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}