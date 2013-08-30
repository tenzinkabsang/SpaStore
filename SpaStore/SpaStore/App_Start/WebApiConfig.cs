using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SpaStore
{
    public static class WebApiConfig
    {
        public static string ControllerOnly = "ApiControllerOnly";
        public static string ControllerAndId = "ApiControllerAndId";
        public static string ControllerAction = "ApiControllerAction";
        public static string ControllerActionId = "ApiControllerActionId";

        public static void Register(HttpConfiguration config)
        {
            //config.EnableCors();

            // api/products
            config.Routes.MapHttpRoute(
                name: ControllerOnly,
                routeTemplate: "api/{controller}"
                );

           
            // api/products/4
            config.Routes.MapHttpRoute(
                name: ControllerAndId,
                routeTemplate: "api/{controller}/{id}",
                defaults: null,
                constraints: new { id = @"^\d+$" } // all digits
                );

            //// api/products/getproductWithCategory/4
            //config.Routes.MapHttpRoute(
            //   name: ControllerActionId,
            //   routeTemplate: "api/{controller}/{action}/{id}"
            //   );


            // custom actions - api/products/soccer
            config.Routes.MapHttpRoute(
                name: ControllerAction,
                routeTemplate: "api/{controller}/{action}"
                );

          

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
