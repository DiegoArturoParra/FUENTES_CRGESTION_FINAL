﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using System.Web.Routing;

namespace service_zumall
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
