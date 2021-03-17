using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebMVC.AccountService;

namespace WebMVC.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (String.IsNullOrEmpty(SessionPersister.Username))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    (new { controller = "Account", action = "Index" }));
            }
            else
            {
                WCFAccountServiceClient accountServiceClient = new WCFAccountServiceClient();
                CustomPrincipal customPrincipal = new CustomPrincipal
                    (accountServiceClient.Find(SessionPersister.Username));
                if (!customPrincipal.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "Error", action = "Index" }));
                }
            }
        }
    }
}