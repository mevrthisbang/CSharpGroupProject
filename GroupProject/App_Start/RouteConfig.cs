using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GroupProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Add Cart",
               url: "add-to-cart",
               defaults: new { controller = "ShoppingCart", action = "addToCart", id = UrlParameter.Optional },
               namespaces: new[] { "GroupProject.Controllers" }
           );
            routes.MapRoute(
               name: "Update Cart Add",
               url: "update-cart-add",
               defaults: new { controller = "ShoppingCart", action = "updateAddCart", id = UrlParameter.Optional },
               namespaces: new[] { "GroupProject.Controllers" }
           );
            routes.MapRoute(
             name: "Update Cart Sub",
             url: "update-cart-sub",
             defaults: new { controller = "ShoppingCart", action = "updateSubCart", id = UrlParameter.Optional },
             namespaces: new[] { "GroupProject.Controllers" }
         );
            routes.MapRoute(
               name: "Delete Cart",
               url: "delete-cart",
               defaults: new { controller = "ShoppingCart", action = "removeCart", id = UrlParameter.Optional },
               namespaces: new[] { "GroupProject.Controllers" }
           );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );

        }
    }
}
