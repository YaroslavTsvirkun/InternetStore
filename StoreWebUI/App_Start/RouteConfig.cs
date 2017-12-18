using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StoreWebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                new { controller = "Books", action = "List", genre = (String)null, page = 1 }
            );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Books", action = "List", genre = (String)null },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                null,
                "{genre}",
                new { controller = "Books", action = "List", page = 1 }
            );

            routes.MapRoute(
                null,
                "{genre}/Page{page}",
                new { controller = "Books", action = "List" },
                new { page = @"\d+" }
            );

            routes.MapRoute(
                null,
                "{controller}/{action}"
            );

            routes.MapRoute(name: "Default", url: "{language}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { language = @"ru|en" },
                namespaces: new[] { "StoreWebUI.Controllers" });

            routes.MapRoute(name: "Language", url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, language = "ru" },
                namespaces: new[] { "StoreWebUI.Controllers" });
        }
    }
}
