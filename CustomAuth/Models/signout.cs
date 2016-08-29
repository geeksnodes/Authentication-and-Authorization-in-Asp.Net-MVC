using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAuth.Models
{
    public class signout
    {
        public void sessionabandon()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}