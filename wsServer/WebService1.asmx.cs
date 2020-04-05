using log4net;
using Sys;
using SysActiveX.Std;
using SysObject.Std;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;
using SysDBHelper = Sys.MysqlHelperE;

//https://www.cnblogs.com/mychuizi/p/4209458.html  类继承System.Web.Services.Protocols.SoapHeader
//V0.0.0.1  20190815    DX  add some more functions and test running
//V0.0.0.2  20190906    DX  add ZUPLoadObject

namespace wsServer
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private ILog DxLog = log4net.LogManager.GetLogger("wsServer");

        public string ss = "HiHi";

        public WebService1()
        {
            ss += "ini";
            Profile.LoadProfile();
            SysDBHelper.UpdateConnectString(Profile.G_HostIp, Profile.G_Database, Profile.G_User, Profile.G_Password);
            DxLog.Info(ss);
        }
        /// <summary>
        ///  重点是这个类是继承System.Web.Services.Protocols.SoapHeader 这是关键。加密就全靠这个了
        /// </summary>
        public class MySoapHeader : System.Web.Services.Protocols.SoapHeader
        {
            #region
            /// <summary>
            /// 用户名
            /// </summary>
            private string _name;
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            /// <summary>
            /// 秘密
            /// </summary>
            private string _password;
            public string Password
            {
                get { return _password; }
                set { _password = value; }
            }
            #endregion

            /// <summary>
            /// 无参数的构造函数
            /// </summary>
            public MySoapHeader()
            {
            }
            /// <summary>
            /// 带参数的构造函数
            /// </summary>
            /// <param name="Name">参数用户名</param>
            /// <param name="Password">参数秘密</param>
            public MySoapHeader(string Name, string Password)
            {
                this.Name = Name;
                this.Password = Password;
            }
        }
        
        public MySoapHeader _MySoapHeader;// 定义一个变量
        [WebMethod(Description = "验证权限", CacheDuration = 0, BufferResponse = true)]
        [System.Web.Services.Protocols.SoapHeader("_MySoapHeader")]
        public string HelloWorld()
        {
            MySoapHeader aa = new MySoapHeader();
            PropertyInfo p = aa.GetType().GetProperty("Password");
            p.SetValue(aa, "123456", null);
            if (_MySoapHeader.Name == "KG" && _MySoapHeader.Password == "123456")
                return ss+"Hello World";
            return "faild";
        }

        [WebMethod(Description ="求和的方法")]
        public double addition(double i,double j)
        {
            return i + j;
        }

        [WebMethod(Description = "ZUPGetProperty")]
        public string ZUPGetProperty(string strINTID, string strPropertyName, bool boWithDeleted = false)
        {
            DxLog.Info("Call method ZUPGetProperty");
            return DxActiveX.ZUPGetProperty(strINTID, strPropertyName, boWithDeleted);
        }

        [WebMethod(Description = "ZUPSetProperty")]
        public bool ZUPSetProperty(string strINTID, string strPropertyName, Object strPropertyValue, string strOBJNameList = null, bool boKeepDeleted = true)
        {
            return DxActiveX.ZUPSetProperty(strINTID, strPropertyName, strPropertyValue, strOBJNameList, boKeepDeleted);
        }

        [WebMethod(Description = "ZUPGetObjectClassID")]
        public string ZUPGetObjectClassID(string strINTID)
        {
            return DxActiveX.ZUPGetObjectClassID(strINTID);
        }

        [WebMethod(Description = "ZUPGetClassName")]
        public string ZUPGetClassName(string strClassID, bool boName = false)
        {
            return DxActiveX.ZUPGetClassName(strClassID, boName);
        }

        [WebMethod(Description = "ZUPGetClassID")]
        public string ZUPGetClassID(string strClassName)
        {
            return DxActiveX.ZUPGetClassID(strClassName);
        }
        [WebMethod(Description = "ZUPNewObject")]
        public string ZUPNewObject(string strClassName)
        {
            return DxActiveX.ZUPNewObject(strClassName);
        }
        [WebMethod(Description = "ZUPDeleteObject")]
        public bool ZUPDeleteObject(string strINTID, bool boPhyDel = false)
        {
            return DxActiveX.ZUPDeleteObject(strINTID, boPhyDel);
        }
        [WebMethod(Description = "ZUPLoadObject")]
        public string ZUPLoadObject(string strINTID)
        {           
            return SerializeHelper.ToString(DxActiveX.ZUPLoadObject(strINTID));
        }

    }
}
