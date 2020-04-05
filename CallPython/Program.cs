using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;

//V0.0.0.1   DX  20200324    001H Call python function

namespace CallPython
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ScriptRuntimeSetup setup = Python.CreateRuntimeSetup(null);
                ScriptRuntime runtime = new ScriptRuntime(setup);
                ScriptEngine engine = Python.GetEngine(runtime);

                var paths = engine.GetSearchPaths();
                paths.Add(@"C:\Program Files\IronPython 2.7\lib");
                engine.SetSearchPaths(paths);
                ScriptSource source = engine.CreateScriptSourceFromFile(@"D:\VsCodeDemo\pythonfile\EagleXml.py");
                ScriptScope scope = engine.CreateScope();
                List<String> argv = new List<String>();
                //Do some stuff and fill argv
                argv.Add(".");
                argv.Add(@"D:\VsCodeDemo\pythonfile\MEHOW-0.xml");
                engine.GetSysModule().SetVariable("argv", argv);
                source.Execute(scope);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}
