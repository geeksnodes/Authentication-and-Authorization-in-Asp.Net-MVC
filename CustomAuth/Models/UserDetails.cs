using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAuth.Models
{
    public class UserDetails
    {
        public int id { get; set; }
        public string username { get; set; }
        public string pwd { get; set; }
        public string confirmpwd { get; set; }
        public string role { get; set; }
        public int roleid { get; set; }
    }
}