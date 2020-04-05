using Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//V0.0.0.1  20190213    DX make file for AndronConfig

namespace wsServer
{
    public class Profile
    {
        public static void LoadProfile()
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory;
            _file = new IniFile(strPath + "wsServerConfig.ini");
            G_HostIp = _file.ReadString("wsServerConfig", "HostIp", "dx-pc");
            G_Database = _file.ReadString("wsServerConfig", "Database", "showroom");
            G_User = _file.ReadString("wsServerConfig", "User", "ZUPUser");
            G_Password = _file.ReadString("wsServerConfig", "Password ", "ZUPUser");
            G_DBType = int.Parse(_file.ReadString("wsServerConfig", "DBType ", "0"));
        }

        public static void SaveProfile()
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory;
            _file = new IniFile(strPath + "wsServerConfig.ini");
            _file.WriteString("wsServerConfig", "HostIp", G_HostIp);      
            _file.WriteString("wsServerConfig", "Database", G_Database);      
            _file.WriteString("wsServerConfig", "User", G_User);     
            _file.WriteString("wsServerConfig", "Password", G_Password);
            _file.WriteString("wsServerConfig", "DBType", G_DBType.ToString());
        }

        private static IniFile _file;//内置了一个对象
        public static string G_HostIp = "";
        public static string G_Database = "";
        public static string G_User = "";
        public static string G_Password = "";
        public static int G_DBType = 0;
    }
}
