using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NewWorkbench.Service.ServiceImp;

namespace NewWorkbench.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Workbench";
            ViewBag.Version = CommonLibrary.ConfigHelper.GetAppSettings("SystemVersion");

            ViewData["Module"] = new ModuleManage().GetModule(this.CurrentUser.Id, this.CurrentUser.Permissions, this.CurrentUser.System_Id);

            return View();
        }
    }
}
