using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ilac_etkilesimleri
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region ibrahiekinci.Plugin.Localization
                        routes.MapRoute(
                   name: "DefaultLocalized",
                   url: "{lang}/{controller}/{action}/{id}",
                     constraints: new { lang = @"(TR)|(EN)|(IT)" },
                   //constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US
                   defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
               );
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
