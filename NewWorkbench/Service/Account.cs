using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWorkbench.Service
{
    /// <summary>
    /// 通用用户登录类，简单信息
    /// </summary>
    public class Account
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 登录的用户名
        /// </summary>
        public string LogName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string Face_Img { get; set; }

        /// <summary>
        /// 用户主部门
        /// </summary>
        public Domain.SYS_DEPARTMENT DptInfo { get; set; }

        /// <summary>
        /// 用户所在部门集合
        /// </summary>
        public List<Domain.SYS_DEPARTMENT> Dpt { get; set; }

        /// <summary>
        /// 权限集合
        /// </summary>
        public List<Domain.SYS_PERMISSION> Permissions { get; set; }

        /// <summary>
        /// 角色的集合
        /// </summary>
        public List<Domain.SYS_ROLE> Roles { get; set; }

        /// <summary>
        /// 用户岗位集合
        /// </summary>
        public List<Domain.SYS_POST_USER> PostUser { get; set; }

        /// <summary>
        /// 用户可操作的模块集合
        /// </summary>
        public List<Domain.SYS_MODULE> Modules { get; set; }


        /// <summary>
        /// 用户拥有权限系统的列表
        /// 一个用户可能拥有多个系统的权限，也全部放在这里
        /// </summary>
        public List<string> System_Id { get; set; }

        #endregion
    }
}
