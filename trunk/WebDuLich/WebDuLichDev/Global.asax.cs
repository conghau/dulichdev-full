using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebDuLichDev.Models;
using WebMatrix.WebData;

namespace WebDuLichDev
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static int pageDefault = 1;
        public static int pageSizeDefault = 10;
        //them vo day ne :P
        public static string countryCode = "VN";
        //private static SimpleMembershipInitializer _initializer;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            log4net.Config.XmlConfigurator.Configure();

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
         

        }
        //public class SimpleMembershipInitializer
        //{
        //    public SimpleMembershipInitializer()
        //    {
        //        using (var context = new UsersContext())
        //            context.UserProfiles.Find(1);

        //        if (!WebSecurity.Initialized)
        //        {
        //            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        //            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "webpages_OAuthMembership", "UserId", "UserName", autoCreateTables: true);
        //        }
        //    }
        //}
    }
}