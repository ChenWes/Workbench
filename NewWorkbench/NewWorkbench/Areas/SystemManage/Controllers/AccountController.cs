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

namespace NewWorkbench.Areas.SystemManage.Controllers
{
    public class AccountController : Controller
    {
        //验证码编码
        private readonly string mc_ValidateCode = "loginValidateCode";
        private readonly string mc_RemberMeCode = "cookie_rememberme";

        #region 声明容器

        CommonLibrary.Log.IExtLog log = CommonLibrary.Log.ExtLogManager.GetLogger("dblog");

        #endregion

        #region 基本视图
     
        public ActionResult Index()
        {
            SessionHelper.Remove(mc_ValidateCode);
            CookieHelper.ClearCookie(mc_RemberMeCode);            

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
                #region validate code

                var code = Request.Form["Code"];

                if (Session[mc_ValidateCode] != null)
                {
                    if (!string.IsNullOrEmpty(code) && code.ToLower() == Session[mc_ValidateCode].ToString().ToLower())
                    {
                        #region user login

                        //调用登录验证接口 返回用户实体类
                        var users = new UserManage().UserLogin(item.ACCOUNT.Trim(), item.PASSWORD.Trim());

                        if (users != null)
                        {
                            var account = new UserManage().GetAccountByUser(users);

                            CommonLibrary.SessionHelper.SetSession("CurrentUser", account);

                            #region check remeber
                            if (item.Remeberme)
                            {
                                //记录用户信息到Cookies
                                string cookievalue = "{\"id\":\"" + account.Id + "\",\"username\":\"" + account.LogName + "\",\"password\":\"" + account.PassWord + "\",\"ToKen\":\"" + Session.SessionID + "\"}";

                                CookieHelper.SetCookie(mc_RemberMeCode, new CommonLibrary.AESCrypt().Encrypt(cookievalue), null);
                            }
                            else
                            {
                                CookieHelper.ClearCookie(mc_RemberMeCode);
                            }

                            #endregion

                            users.LastLoginIP = Utils.GetIP();
                            new UserManage().Update(users);

                            #region lock
                            //是否锁定
                            if (users.ISCANLOGIN == 1)
                            {
                                json.Status = "N";
                                json.Msg = "用户已锁定，禁止登录，请联系管理员进行解锁";
                                log.Warn(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                                return Json(json);
                            }
                            #endregion

                            json.Status = "Y";
                            json.ReUrl = "/System/Home";
                            log.Info(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                        }
                        else
                        {
                            json.Status = "N";
                            json.Msg = "用户名或密码不正确";
                            log.Error(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                        }

                        #endregion
                    }
                    else
                    {
                        json.Status = "N";
                        json.Msg = "验证码不正确，请重新输入";
                    }
                }
                else
                {
                    json.Status = "N";
                    json.Msg = "验证码已过期，请刷新验证码";
                }

                #endregion
            }
            catch (Exception ex)
            {
                json.Status = "N";
                json.Msg = ex.Message;
                log.Info(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg, ex);
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoginOut()
        {
            SessionHelper.Remove("CurrentUser");
            SessionHelper.Delete("CurrentUser");

            return View("index");
        }

        #endregion

        #region 帮助方法

        public FileContentResult ValidateCode()
        {
            string code = "";
            System.IO.MemoryStream ms = new verify_code().Create(out code);
            Session[mc_ValidateCode] = code;
            Response.ClearContent();
            return File(ms.ToArray(), @"image/png");
        }

        #endregion

    }
}