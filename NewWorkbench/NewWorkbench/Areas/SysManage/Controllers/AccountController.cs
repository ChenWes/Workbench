using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewWorkbench.CommonLibrary;
using NewWorkbench.Service;
using NewWorkbench.Service.ServiceImp;
using NewWorkbench.Service.IService;
using NewWorkbench.Domain;


using NewWorkbench.Models;

namespace NewWorkbench.Areas.SysManage.Controllers
{
    public class AccountController : Controller
    {
        #region 声明容器

        //IUserManage UserManage { get; set; }

        CommonLibrary.Log.IExtLog log = CommonLibrary.Log.ExtLogManager.GetLogger("dblog");

        #endregion

        #region 基本视图

        public ActionResult Index()
        {
            ViewBag.Title = "Login - " + CommonLibrary.ConfigHelper.GetAppSettings("SystemTitle");

            return View();
        }

        /// <summary>
        /// 登录验证
        /// add yuangang by 2016-05-16
        /// </summary>
        [ValidateAntiForgeryToken]
        public ActionResult Login(Domain.SYS_USER item)
        {
            var json = new JsonHelper() { Msg = "登录成功", Status = "Y" };

            try
            {
                //调用登录验证接口 返回用户实体类
                var users =new UserManage().UserLogin(item.ACCOUNT.Trim(), item.PASSWORD.Trim());

                if (users != null)
                {
                    //是否锁定
                    if (users.ISCANLOGIN == 1)
                    {
                        json.Msg = "用户已锁定，禁止登录，请联系管理员进行解锁";
                        log.Warn(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                        return Json(json);
                    }

                    json.Status = "Y";
                    log.Info(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                }
                else
                {
                    json.Msg = "用户名或密码不正确";
                    log.Error(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                }

            }
            catch (Exception ex)
            {
                json.Msg = ex.Message;
                log.Info(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg, ex);
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 帮助方法

        public FileContentResult ValidateCode()
        {
            string code = "";
            System.IO.MemoryStream ms = new verify_code().Create(out code);
            Session["gif"] = code;
            Response.ClearContent();
            return File(ms.ToArray(), @"image/png");
        }

        #endregion

    }
}