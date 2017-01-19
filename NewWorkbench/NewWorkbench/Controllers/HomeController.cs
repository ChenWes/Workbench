using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NewWorkbench.Service.ServiceImp;

namespace NewWorkbench.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = CommonLibrary.ConfigHelper.GetAppSettings("SystemTitle");
            ViewBag.Version = CommonLibrary.ConfigHelper.GetAppSettings("SystemVersion");
            ViewBag.CompanyName = CommonLibrary.ConfigHelper.GetAppSettings("CompanyName");
            ViewBag.CompanyUrl = CommonLibrary.ConfigHelper.GetAppSettings("CompanyUrl");
            ViewBag.HelpEmail = CommonLibrary.ConfigHelper.GetAppSettings("HelpEmail");

            //ViewData["Module"] = new ModuleManage().GetModule(this.CurrentUser.Id, this.CurrentUser.Permissions, this.CurrentUser.System_Id);

            return View();
        }
    }
}
