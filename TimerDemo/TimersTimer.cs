using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

//V0.0.0.1  20150814    DX create
//http://www.cnblogs.com/xia520pi/archive/2011/10/09/2204184.html

namespace TimerDemo
{
    class SafeTimer
    {
        static int i = 0;
        static System.Timers.Timer timer;
        static bool flag = true;
        static object mylock = new object();
        public static void Init()
        {
            timer = new System.Timers.Timer(10);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }
        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Thread.CurrentThread.IsBackground = false;
            //keep the exactly sequence of the threads
            lock (mylock)
            {
                if (!flag)
                {
                    return;
                }
                i++;
                Console.WriteLine("Now:" + i.ToString());
                if (i == 80)
                {
                    timer.Stop();
                    flag = false;
                }
            }
            Thread.Sleep(1000);//同UnSafeTimer
        }
    }

    class UnSafeTimer
    {
        static int i = 0; static System.Timers.Timer timer;
        static object mylock = new object();
        public static void Init()
        {
            timer = new System.Timers.Timer(10);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }
        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Thread.CurrentThread.IsBackground = false;
            int c;
            lock (mylock)
            {
                i++;
                c = i;
            }
            Console.WriteLine("Now:" + i.ToString());
            if (c == 80)
            {
                timer.Stop();
                //可应看到System.Timers.Timer 的叫停机制比System.Threading.Timer 好得多，就算在不安全的代码下
                //Timer 也最多多执行一两次（我在试验中发现有时会执行到81 或82），说明Stop 方法在设置Timer 的Enable
                //为false 后不仅让Timer 不再激发响应事件，还取消了线程池等待队列中等待获得线程的任务，至于那多
                //执行的一两次任务我个人认为是Stop 执行过程中会耗费一段时间才将Timer 的Enable 设置为false，这
                //段时间多余的一两个任务就获得了线程开始执行
            }
            Thread.Sleep(1000);
            //等待1000 毫秒模拟花时间的代码，注意：这里的等待时间直接决定了80(由于是不安全模式有时会是81
            //或82、83)个任务的执行时间，因为等待时间越短，每个任务就可以越快执行完，那么80 个任务中就有越
            //多的任务可以用到前面任务执行完后释放掉的线程，也就有越多的任务不必去线程池申请新的线程避免多
            //等待半秒钟的申请时间
        }
    }


}
