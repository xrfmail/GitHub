using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

//V0.0.0.1  20150814    DX create
//http://www.cnblogs.com/xia520pi/archive/2011/10/09/2204184.html

namespace TimerDemo
{
    class ThreadingUnSafeTimer
    {
        static int i = 0;
        static System.Threading.Timer timer;
        static object mylock = new object();
        static int sleep;
        static bool flag;
        public static Stopwatch sw = new Stopwatch();
        static void Excute(object obj)
        {
            Thread.CurrentThread.IsBackground = false;
            int c;
            lock (mylock)
            {
                i++;
                c = i;
            }
            if (c == 80)
            {
                timer.Dispose();
                //执行Dispose 后Timer 就不会再申请新的线程了,但是还是会给Timmer 已经激发的事件申请线程
                sw.Stop();
            }
            if (c < 80)
                Console.WriteLine("Now:" + c.ToString());
            else
            {
                Console.WriteLine("Now:" + c.ToString() + "-----------Timer 已经Dispose 耗时:"
                + sw.ElapsedMilliseconds.ToString() + "毫秒");
            }
            if (flag)
            {
                Thread.Sleep(sleep);//模拟花时间的代码
            }
            else
            {
                if (i <= 80)
                    Thread.Sleep(sleep);//前80 次模拟花时间的代码
            }
        }
        public static void Init(int p_sleep, bool p_flag)
        {
            sleep = p_sleep;
            flag = p_flag;
            timer = new System.Threading.Timer(Excute, null, 0, 10);
        }
    }
    class ThreadingSafeTimer
    {
        static int i = 0;
        static System.Threading.Timer timer;
        static bool flag = true;
        static object mylock = new object();
        static void Excute(object obj)
        {
            Thread.CurrentThread.IsBackground = false;
            lock (mylock)
            {
                if (!flag)
                {
                    return;
                }
                i++;
                if (i == 80)
                {
                    timer.Dispose();
                    flag = false;
                }
                Console.WriteLine("Now:" + i.ToString());
            }
            Thread.Sleep(1000);//模拟花时间的代码
        }
        public static void Init()
        {
            timer = new System.Threading.Timer(Excute, null, 0, 10);
        }
    }
}
