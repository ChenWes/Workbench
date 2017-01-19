using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewWorkbench.Service.IService;
using System.Data.Common;

using System.Data.SqlClient;

namespace NewWorkbench.Service.ServiceImp
{
    /// <summary>
    /// Service 授权模块关系处理类
    /// add yuangang by 2016-05-19
    /// </summary>
    public class PermissionManage : RepositoryBase<Domain.SYS_PERMISSION>, IService.IPermissionManage
    {
        /// <summary>
        /// 根据系统ID获取所有模块的权限ID集合
        /// </summary>
        public List<int> GetPermissionIdBySysId(string sysId)
        {
            try
            {
                string sql = "select p.id from sys_permission p where exists(select 1 from sys_module t where t.fk_belongsystem=@sysid and t.id=p.moduleid)";
                DbParameter para = new SqlParameter("@sysid", sysId);
                return this.SelectBySql<int>(sql, para);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }


    /// <summary>
    /// 权限去重，非常重要
    /// add yuangang by 2015-08-03
    /// </summary>
    public class PermissionDistinct : IEqualityComparer<Domain.SYS_PERMISSION>
    {
        public bool Equals(Domain.SYS_PERMISSION x, Domain.SYS_PERMISSION y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(Domain.SYS_PERMISSION obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
