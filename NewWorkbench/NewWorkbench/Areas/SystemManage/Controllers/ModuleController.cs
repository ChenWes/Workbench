using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NewWorkbench.Controllers;
using NewWorkbench.Service.ServiceImp;
using NewWorkbench.CommonLibrary.Enums;

namespace NewWorkbench.Areas.SystemManage.Controllers
{
    public class ModuleController : BaseController
    {
        [UserAuthorizeAttribute(ModuleAlias = "Module", OperaAction = "View")]
        public ActionResult Index()
        {
            string systems = Request.QueryString["System"];
            ViewBag.Search = base.keywords;
            ViewData["System"] = systems;

            ViewData["Systemlist"] = new Service.ServiceImp.SystemManage().LoadSystemInfo(CurrentUser.System_Id);            

            return View(BindList(systems));
        }

        [UserAuthorizeAttribute(ModuleAlias = "Module", OperaAction = "Detail")]
        public ActionResult Detail(int? id)
        {
            try
            {
                var _entity = new Domain.SYS_MODULE()
                 {
                     ISSHOW = 1,
                     MODULEPATH = "",
                     MODULETYPE = 1
                 };

                //父模块
                string parentId = Request.QueryString["parentId"];
                if (!string.IsNullOrEmpty(parentId))
                {
                    _entity.PARENTID = int.Parse(parentId);
                }
                else
                {
                    _entity.PARENTID = 0;
                }

                //所属系统
                string sys = Request.QueryString["sys"];
                if (!string.IsNullOrEmpty(sys))
                {
                    _entity.FK_BELONGSYSTEM = sys;
                }

                //详情
                if (id != null && id > 0)
                {
                    _entity =new Service.ServiceImp.ModuleManage().Get(p => p.ID == id);
                }

                //页面类型
                ViewData["ModuleType"] = Enum.GetNames(typeof(enumModuleType));

                //加载用户可操作的系统
                ViewData["Systemlist"] =new Service.ServiceImp.SystemManage().LoadSystemInfo(CurrentUser.System_Id);


                ViewData["Modules"] = BindList(_entity.FK_BELONGSYSTEM);

                return View(_entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [UserAuthorizeAttribute(ModuleAlias = "Module", OperaAction = "Add,Edit")]
        public ActionResult Save(Domain.SYS_MODULE entity)
        {

            bool isEdit = false;
            var json = new CommonLibrary.JsonHelper() { Msg = "保存成功", Status = "n" };

            try
            {
                if (entity == null)
                {
                    json.Msg = "未找到需要保存的模块";
                    return Json(json);
                }

                //验证
                if (!CommonLibrary.RegexHelper.IsMatch(entity.ALIAS, @"^[A-Za-z0-9]{1,20}$"))
                {
                    json.Msg = "模块别名只能以字母数字组成，长度不能超过20个字符";
                    return Json(json);
                }

                //级别加1，一级模块默认0
                if (entity.PARENTID <= 0)
                {
                    entity.LEVELS = 0;
                }
                else
                {
                    entity.LEVELS = new Service.ServiceImp.ModuleManage().Get(p => p.ID == entity.PARENTID).LEVELS + 1;
                }

                //添加
                if (entity.ID <= 0)
                {
                    entity.CREATEDATE = DateTime.Now;
                    entity.CREATEUSER = this.CurrentUser.Name;
                    entity.UPDATEDATE = DateTime.Now;
                    entity.UPDATEUSER = this.CurrentUser.Name;
                }
                else //修改
                {
                    entity.UPDATEDATE = DateTime.Now;
                    entity.UPDATEUSER = this.CurrentUser.Name;
                    isEdit = true;
                }

                //模块别名同系统下不能重复
                if (new Service.ServiceImp.ModuleManage().IsExist(p => p.FK_BELONGSYSTEM == entity.FK_BELONGSYSTEM && p.ALIAS == entity.ALIAS && p.ID != entity.ID))
                {
                    json.Msg = "同系统下模块别名不能重复";
                    return Json(json);
                }

                //判断同一个父模块下，是否重名 
                if (!new Service.ServiceImp.ModuleManage().IsExist(p => p.PARENTID == entity.PARENTID && p.FK_BELONGSYSTEM == entity.FK_BELONGSYSTEM && p.NAME == entity.NAME && p.ID != entity.ID))
                {

                    if (new Service.ServiceImp.ModuleManage().SaveOrUpdate(entity, isEdit))
                    {

                        json.Status = "y";
                    }
                    else
                    {
                        json.Msg = "保存失败";
                    }

                    //如果模块修改成功，我们变更下级模块的级别
                    if (isEdit)
                        new Service.ServiceImp.ModuleManage().MoreModifyModule(entity.ID, entity.LEVELS);
                }
                else
                {
                    json.Msg = "模块" + entity.NAME + "已存在，不能重复添加";
                }


            }
            catch (Exception e)
            {
                json.Msg = "保存模块发生内部错误！";
                WriteLog(CommonLibrary.Enums.enumOperator.None, "保存模块：", e);
            }

            return Json(json);
        }

        [UserAuthorizeAttribute(ModuleAlias = "Module", OperaAction = "Remove")]
        public ActionResult Delete(string idList)
        {
            CommonLibrary.JsonHelper json = new CommonLibrary.JsonHelper() { Msg = "删除模块成功", ReUrl = "", Status = "n" };

            try
            {
                if (!string.IsNullOrEmpty(idList))
                {
                    var idlist1 = idList.Trim(',').Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(p => int.Parse(p)).ToList();

                    //判断权限里面有没有
                    if (!new Service.ServiceImp.PermissionManage().IsExist(p => idlist1.Any(e => e == p.MODULEID)))
                    {
                        //存在子模块与否
                        if (!new Service.ServiceImp.ModuleManage().IsExist(p => idlist1.Any(e => e == p.PARENTID)))
                        {
                            new Service.ServiceImp.ModuleManage().Delete(p => idlist1.Any(e => e == p.ID));
                            json.Status = "y";
                        }
                        else
                        {
                            json.Msg = "该模块下有子模块，不能删除";
                        }
                    }
                    else
                    {
                        json.Msg = "该模块下有权限节点，不能删除";
                    }

                }
                else
                {
                    json.Msg = "未找到要删除的模块";
                }
                WriteLog(CommonLibrary.Enums.enumOperator.Remove, "删除模块，结果：" + json.Msg, CommonLibrary.Enums.enumLog4net.WARN);
            }
            catch (Exception e)
            {
                json.Msg = "删除模块发生内部错误！";
                WriteLog(CommonLibrary.Enums.enumOperator.Remove, "删除模块：", e);
            }
            return Json(json);
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
                query = query.Where(p => this.CurrentUser.System_Id.Any(e => e == p.FK_BELONGSYSTEM));
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
                    ISSHOW = p.ISSHOW==1 ? "显示" : "隐藏",
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