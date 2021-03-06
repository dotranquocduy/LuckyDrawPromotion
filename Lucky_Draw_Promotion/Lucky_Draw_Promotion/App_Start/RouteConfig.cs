using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lucky_Draw_Promotion
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                name: "LoginUser",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AuthenticationUsers", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AuthenticationCMS", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "register",
                url: "{controller}/{action}",
                defaults: new { controller = "AuthenticationUsers", action = "Register" }
            );
            routes.MapRoute(
                name: "RecoverPass",
                 url: "{controller}/{action}/{number}",
                defaults: new { controller = "AuthenticationUsers", action = "RecoverPass" , number =""}
            );

            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
          );
        }
    }
}
