using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Git.Todolist.Core;

namespace Git.Todolist.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //private void defaultInit()
        //{
        //    OperatorModel operatorModel = new OperatorModel();
        //    operatorModel.UserId = "1";
        //    operatorModel.UserCode = "test";
        //    operatorModel.UserName = "test";
        //    operatorModel.CompanyId = "1";
        //    operatorModel.DepartmentId = "1";
        //    operatorModel.RoleId = "1";
        //    operatorModel.LoginIPAddress = Net.Ip;
        //    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
        //    operatorModel.LoginTime = DateTime.Now;
        //    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
        //    operatorModel.IsSystem = true;
        //    //}
        //    //else
        //    //{
        //    //    operatorModel.IsSystem = false;
        //    //}
        //    OperatorProvider.Provider.AddCurrent(operatorModel);
        //}
    }
}
