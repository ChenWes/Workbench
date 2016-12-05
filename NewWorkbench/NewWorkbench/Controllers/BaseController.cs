using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NewWorkbench.Service.ServiceImp;
using NewWorkbench.Service;
using NewWorkbench.CommonLibrary;
using NewWorkbench.CommonLibrary.Enums;
using NewWorkbench.CommonLibrary.Log;


namespace NewWorkbench.Controllers
{
    public class BaseController : Controller
    {
        #region 公用变量

        /// <summary>
        /// 查询关键词
        /// </summary>
        public string keywords { get; set; }

        /// <summary>
        /// 视图传递的分页页码
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 视图传递的分页条数
        /// </summary>
        public int pagesize { get; set; }

        /// <summary>
        /// 用户容器，公用
        /// </summary>
        //public IUserManage UserManage = Spring.Context.Support.ContextRegistry.GetContext().GetObject("Service.User") as IUserManage;

        #endregion

        #region 用户对象

        public string EmailDomain = CommonLibrary.ConfigHelper.GetAppSettings("EmailDomain");// ConfigurationManager.AppSettings["EmailDomain"];
        protected IExtLog _log = ExtLogManager.GetLogger("dblog");

        /// <summary>
        /// 获取当前用户对象
        /// </summary>
        public Account CurrentUser
        {
            get
            {
                //从Session中获取用户对象
                if (SessionHelper.GetSession("CurrentUser") != null)
                {
                    return SessionHelper.GetSession("CurrentUser") as Account;
                }

                //Session过期 通过Cookies中的信息 重新获取用户对象 并存储于Session中
                var account =new UserManage().GetAccountByCookie();
                SessionHelper.SetSession("CurrentUser", account);
                return account;
            }
        }

        #endregion

        #region 公共方法

        public void WriteLog(enumOperator action, string message, enumLog4net logLevel)
        {
            switch (logLevel)
            {
                case enumLog4net.INFO:
                    _log.Info(Utils.GetIP(), CurrentUser.Name, Request.Url.ToString(), action.ToString(), message);
                    return;
                case enumLog4net.WARN:
                    _log.Warn(Utils.GetIP(), CurrentUser.Name, Request.Url.ToString(), action.ToString(), message);
                    return;
                default:
                    _log.Error(Utils.GetIP(), CurrentUser.Name, Request.Url.ToString(), action.ToString(), message);
                    return;
            }
        }

        public void WriteLog(enumOperator action, string message, Exception e)
        {
            _log.Fatal(Utils.GetIP(), CurrentUser.Name, Request.Url.ToString(), action.ToString(), message + e.Message, e);
        }

        #endregion

        #region 权限验证方法

        /// <summary>
        /// 所有的页面，进入至系统后，都会调用该方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            #region 登录用户验证

            //1、判断Session对象是否存在
            if (filterContext.HttpContext.Session == null)
            {
                filterContext.HttpContext.Response.Write(
                        " <script type='text/javascript'> alert('~登录已过期，请重新登录');window.top.location='/system/account'; </script>");
                filterContext.RequestContext.HttpContext.Response.End();
                filterContext.Result = new EmptyResult();
                return;
            }

            //2、登录验证
            if (this.CurrentUser == null)
            {
                filterContext.HttpContext.Response.Write(
                    " <script type='text/javascript'> alert('登录已过期，请重新登录'); window.top.location='/system/account';</script>");
                filterContext.RequestContext.HttpContext.Response.End();
                filterContext.Result = new EmptyResult();
                return;
            }

            #endregion

            #region 公共Get变量

            //分页页码
            object p = filterContext.HttpContext.Request["page"];
            if (p == null || p.ToString() == "") { page = 1; } else { page = int.Parse(p.ToString()); }

            //搜索关键词
            string search = filterContext.HttpContext.Request.QueryString["Search"];

            if (!string.IsNullOrEmpty(search)) { keywords = search; }

            //显示分页条数
            string size = filterContext.HttpContext.Request.QueryString["example_length"];

            if (!string.IsNullOrEmpty(size) && System.Text.RegularExpressions.Regex.IsMatch(size.ToString(), @"^\d+$")) { pagesize = int.Parse(size.ToString()); } else { pagesize = 10; }

            #endregion
        }

        #endregion
    }
}