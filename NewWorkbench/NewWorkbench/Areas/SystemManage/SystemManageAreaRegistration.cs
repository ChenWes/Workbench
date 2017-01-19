using System.Web.Mvc;

namespace NewWorkbench.Areas.SysManage
{
    public class SysManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SystemManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SysManage_default",
                "System/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "NewWorkbench.Areas.SystemManage.Controllers" }
            );
        }
    }
}