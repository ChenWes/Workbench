using System.Configuration;

namespace NewWorkbench.CommonLibrary
{
    public static class ConfigHelper
    {
        public static string GetAppSettings(string pi_keys)
        {
            string l_getValue = string.Empty;
            {
                l_getValue = ConfigurationManager.AppSettings[pi_keys];
            }
            return l_getValue;
        }

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
