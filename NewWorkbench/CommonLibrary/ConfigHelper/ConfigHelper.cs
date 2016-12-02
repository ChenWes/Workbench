using System.Configuration;

namespace NewWorkbench.CommonLibrary
{
    /// <summary>
    /// 系统配置文件帮助类
    /// </summary>
    public static class ConfigHelper
    {
        /// <summary>
        /// 获取配置值
        /// </summary>
        /// <param name="pi_keys"></param>
        /// <returns></returns>
        public static string GetAppSettings(string pi_keys)
        {
            string l_getValue = string.Empty;
            {
                l_getValue = ConfigurationManager.AppSettings[pi_keys];
            }
            return l_getValue;
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="pi_connectionName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string pi_connectionName)
        {
            string l_getValue = string.Empty;
            {
                l_getValue = ConfigurationManager.ConnectionStrings[pi_connectionName].ConnectionString;
            }
            return l_getValue;
        }
    }
}
