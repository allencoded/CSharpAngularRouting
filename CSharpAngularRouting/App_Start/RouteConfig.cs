using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CSharpAngularRouting
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // serves plane html
            routes.MapRoute(
                 name: "DefaultViews",
                 url: "view/{controller}/{action}/{id}",
                 defaults: new { id = UrlParameter.Optional }
            );

            // Home Index page have ng-app
            routes.MapRoute(
                name: "AngularApp",
                url: "{*.}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
