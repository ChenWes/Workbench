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
            ViewData["Contacts"] = Contacts();

            return View(CurrentUser);
        }

        private object Contacts()
        {
            var obj = from m in
                          (from m in new DepartmentManage().LoadAll(m => m.BUSINESSLEVEL == 1)
                           orderby m.SHOWORDER
                           select m).ToList()
                      select new
                      {
                          ID = m.ID,
                          DepartName = m.NAME,
                          UserList = GetDepartUsers(m.ID)
                      };
            return CommonLibrary.JsonConverter.JsonClass(obj);
        }

        private object GetDepartUsers(string departId)
        {
            List<string> departs = (from p in getAllChildrenDeptIds(departId) // DepartmentManage.LoadAll(p => p.PARENTID == departId)
                                    orderby p.SHOWORDER
                                    select p.ID).ToList();

            departs.Add(departId); //加上顶层id，否则在顶层部门用户不显示
            var users = new  UserManage().LoadListAll(p => p.ID != CurrentUser.Id && departs.Any(e => e == p.DPTID))
                .OrderBy(p => p.LEVELS).ThenBy(p => p.CREATEDATE);
            var ret = users
                .Select(p =>
                {
                    return new
                    {
                        ID = p.ID,
                        FaceImg = (string.IsNullOrEmpty(p.FACE_IMG) ? ("/Pro/Project/User_Default_Avatat?name=" + p.NAME.Substring(0, 1)) : p.FACE_IMG),
                        NAME = p.NAME,
                        InsideEmail = p.ACCOUNT + base.EmailDomain,
                        LEVELS = p.LEVELS,
                        ConnectId = ((new  UserOnlineManage().LoadAll(m => m.FK_UserId == p.ID).FirstOrDefault() == null) ? "" : new UserOnlineManage().LoadAll(m => m.FK_UserId == p.ID).FirstOrDefault().ConnectId),
                        IsOnline = (new UserOnlineManage().LoadAll(m => m.FK_UserId == p.ID).FirstOrDefault() != null && new UserOnlineManage().LoadAll(m => m.FK_UserId == p.ID).FirstOrDefault().IsOnline)
                    };
                })
                .OrderBy(p => p.IsOnline);
            return ret.ToList();
        }

        private List<Domain.SYS_DEPARTMENT> getAllChildrenDeptIds(string topDeptId)
        {
            List<Domain.SYS_DEPARTMENT> ret = new List<Domain.SYS_DEPARTMENT>();

            var depts =new DepartmentManage().LoadAll(p => p.PARENTID == topDeptId);
            ret.AddRange(depts);

            depts.ToList().ForEach(d =>
            {
                ret.AddRange(getAllChildrenDeptIds(d.ID));
            });

            return ret;
        }
	}
}