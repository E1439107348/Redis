using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //配置log4
            string filelog = HttpContext.Current.Server.MapPath("log4net.config").Replace("UI", "RedisHelper");
            FileInfo configFile = new FileInfo(filelog);
            log4net.Config.XmlConfigurator.Configure(configFile);

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
