using PluginInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//V0.0.0.1  20150902  DX  create

namespace PluginA
{
    public class PluginB : IPlugin
    {
        public string Show()
        {
            return "插件B";
        }
    }
}
