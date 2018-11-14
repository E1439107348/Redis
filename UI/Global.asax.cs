using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UI.App_Start;

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

            // 调用Autofac.dll进行控制反转和依赖注入的操作
            AutoFacConfig.Register();
        }
    }
}
