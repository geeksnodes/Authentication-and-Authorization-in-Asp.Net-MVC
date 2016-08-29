using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using CustomAuth.Models;
namespace CustomAuth.Security
{
    public class CustomPrincipal : IPrincipal
    {
        UserDetails userDetail;

        public CustomPrincipal(UserDetails objUserDetails)
        {
            this.userDetail = objUserDetails;
            this.Identity = new GenericIdentity(objUserDetails.username);
        }
        public IIdentity Identity
        {
            get; set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.userDetail.role.Contains(r));
        }
    }
}