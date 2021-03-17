using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Security
{
    public static class SessionPersister
    {
        public static string Username
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionVar = HttpContext.Current.Session["username"];
                if (sessionVar != null)
                {
                    return sessionVar as string;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["username"] = value;
            }
        }
    }
}