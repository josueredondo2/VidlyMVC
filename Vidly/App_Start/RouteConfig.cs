using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();//google it

            routes.MapRoute("MoviesByReleaseDate", //Nombre del mapRoute
                "movies/released/{year}/{month}",//Ruta por defecto
                new {controller ="Movies",action="ByReleaseDate" }, //action que llama
                //new { year = @"\d{4}" ,month = @"\d{2}"  });//Expresiones regulares que tienen condicion para el llamado
                new { year = @"2015|2016" ,month = @"\d{2}"  });//Expresiones regulares que tienen condicion para el llamado

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",//Aqui especifica el parametro por defecto que se envia
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
