using CustomAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomAuth.Security
{
    public class CustomAuthorize:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["userDetails"] != null)
            {
                UserDetails userDetails = new UserDetails();
                CustomPrincipal obj = new CustomPrincipal((UserDetails)HttpContext.Current.Session["userDetails"]);
                if (!obj.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "NotAuthorised" }));
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Login", Action = "Index" }));
            }
        }
    }
}