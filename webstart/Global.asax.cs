using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Hosting;

using platform;
using account.core;
using money.core;

namespace webstart
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            if (!mInit)
            {
                _runInit();
            }
            else
            {
                LogService logService_ =
                    __singleton<LogService>._instance();
                logService_._logWarn(@"Application_Start have inited");
            }

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            if (!mStart)
            {
                _runStart();
            }
            else
            {
                LogService logService_ =
                    __singleton<LogService>._instance();
                logService_._logWarn(@"Application_Start have started");
            }
        }

        protected void Application_End()
        {
            InitService initService_ = 
                __singleton<InitService>._instance();
            initService_._runExit();
        }

        void _runPreinit()
        {
            string systemPath_ = HostingEnvironment.MapPath(@"~");
            InitService initService_ = 
                __singleton<InitService>._instance();
            initService_._runPreinit();

            AccountService accountService_ =
                __singleton<AccountService>._instance();
            accountService_._runInit();

            MoneyService moneyService_ =
                __singleton<MoneyService>._instance();
            moneyService_._runInit();
        }

        void _runStart()
        {
            AccountService accountService_ =
                __singleton<AccountService>._instance();
            accountService_._runStart();
        }

        bool mInit = false;
        bool mStart = false;
    }
}
