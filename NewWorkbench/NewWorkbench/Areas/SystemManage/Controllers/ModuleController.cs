﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NewWorkbench.Controllers;
using NewWorkbench.Service.ServiceImp;

namespace NewWorkbench.Areas.SystemManage.Controllers
{
    public class ModuleController : BaseController
    {
        //
        // GET: /Module/
        [UserAuthorizeAttribute(ModuleAlias = "Module", OperaAction = "View")]
        public ActionResult Index()
        {
            string systems = Request.QueryString["System"];
            ViewBag.Search = base.keywords;
            ViewData["System"] = systems;

            ViewData["Systemlist"] = new Service.ServiceImp.SystemManage().LoadSystemInfo(CurrentUser.System_Id);

            return View(BindList(systems));
        }

        private object BindList(string systems)
        {
            //预加载所有模块（二级缓存）
            var query = new ModuleManage().LoadAll(null);

            //系统ID
            if (!string.IsNullOrEmpty(systems))
            {
                query = query.Where(p => p.FK_BELONGSYSTEM == systems);
            }
            else
            {
                //选择全部 查询所有用户所属系统的模块
                //query = query.Where(p => this.CurrentUser.System_Id.any(e => e == p.FK_BELONGSYSTEM));
            }

            //递归排序（无分页）
            var entity = new ModuleManage().RecursiveModule(query.ToList())
                .Select(p => new
                {
                    p.ID,
                    MODULENAME = GetModuleName(p.NAME, p.LEVELS),
                    p.ALIAS,
                    p.MODULEPATH,
                    p.SHOWORDER,
                    p.ICON,
                    MODULETYPE = ((CommonLibrary.Enums.enumModuleType)p.MODULETYPE).ToString(),
                    p.NAME,
                    SYSNAME = p.SYS_SYSTEM.NAME,
                    p.FK_BELONGSYSTEM
                });
            if (!string.IsNullOrEmpty(base.keywords))
            {
                entity = entity.Where(p => p.NAME.Contains(keywords));
            }

            return CommonLibrary.JsonConverter.JsonClass(entity);
        }

        private object GetModuleName(string name, decimal? level)
        {
            if (level > 0)
            {
                string nbsp = "&nbsp;&nbsp;";
                for (int i = 0; i < level; i++)
                {
                    nbsp += "&nbsp;&nbsp;";
                }
                name = nbsp + "  |--" + name;
            }
            return name;
        }
	}
}