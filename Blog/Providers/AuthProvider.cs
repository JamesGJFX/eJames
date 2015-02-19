﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Blog.Providers
{
    public class AuthProvider : IAuthProvider
    {
        public bool IsLoggedIn
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        public bool Login(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);

            if (result)
                FormsAuthentication.SetAuthCookie(username, false);

            return result;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

    }
}
