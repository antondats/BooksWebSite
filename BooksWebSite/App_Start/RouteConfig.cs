using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BooksWebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "Books",
                new {controller = "BookEditor", action = "Index"}
                );

            routes.MapRoute(null,
                "Magazines",
                new { controller = "MagzineEditor", action = "Index" }
                );

            routes.MapRoute(null,
                "Brochures",
                new { controller = "BrochureEditor", action = "Index" }
                );

            routes.MapRoute(null,
                "",
                new { controller = "Home", action = "Index" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
