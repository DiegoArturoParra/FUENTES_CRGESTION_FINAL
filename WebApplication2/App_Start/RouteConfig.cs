using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace service_zumall
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //esta wada es config, aca defines los endpoint de los servicios
            // tus vistas de tu proyecto como son?
            // son formularios y esta en capas
            // te muestro aqui
            // y tu no me deberias decir que informacion es la que necesitaran tus formularios?
            // para la app? si xD pero no se supone q tu sabes mas q yo del negocio Xd
            // Si pero no recuerdo bien que formularios se iban hacer =)tssssss ya eso lo vemos lo principal es q entiedeas esta wada
            // Aqui esta!
            // son aspx? 
            // SI ta q eres clasico xD
            // siempre me compro mis jeans clasicos
            // gil... ya mira 
        }
    }
}
