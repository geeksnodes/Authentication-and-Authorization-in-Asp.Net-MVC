using CustomAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace CustomAuth.Controllers
{
    public class RegisterController : Controller
    {

        CustomAuthEntities obj = new CustomAuthEntities();
        // GET: Register
        public ActionResult Index()
        {
            ViewBag.role = new SelectList( obj.t_usersType.ToList(),"id", "roles");
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserDetails users)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDetails, t_users>()
                .ForMember(
                    dest => dest.role, opt => opt.MapFrom(src => src.id)
                    );
                });
            IMapper mapper = config.CreateMapper();
            t_users adduser = mapper.Map<UserDetails, t_users>(users);
            //t_users adduser = new t_users();
            obj.t_users.Add(adduser);
            obj.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}