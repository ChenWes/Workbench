using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NewWorkbench.Controllers;
using NewWorkbench.Service.ServiceImp;

namespace NewWorkbench.Areas.SystemManage.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /SystemManage/Home/
        public ActionResult Index()
        {
            ViewBag.Title = CommonLibrary.ConfigHelper.GetAppSettings("SystemTitle");
            ViewBag.Version = CommonLibrary.ConfigHelper.GetAppSettings("SystemVersion");
            ViewBag.CompanyName = CommonLibrary.ConfigHelper.GetAppSettings("CompanyName");
            ViewBag.CompanyUrl = CommonLibrary.ConfigHelper.GetAppSettings("CompanyUrl");
            ViewBag.HelpEmail = CommonLibrary.ConfigHelper.GetAppSettings("HelpEmail");

            ViewBag.Account = this.CurrentUser.Name;
            ViewBag.AccountImg = "/Content/img/profile_small.jpg";

            ViewData["Module"] = new ModuleManage().GetModule(CurrentUser.Id, CurrentUser.Permissions, CurrentUser.System_Id);


            return View();
        }   
             
	}
}