using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

//V0.0.0.1  20150826  DX  http://www.dotnetperls.com/backgroundworker

namespace TimerDemo
{
    public partial class FormTimerDemo : Form
    {
        public FormTimerDemo()
        {
            InitializeComponent();
        }
        int j = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {            
            textBox1.Text = textBox1.Text + DateTime.UtcNow.ToString() + j+"begin \r\n";
            long i=10000000000;
            while (i > 0)
            {
                i--;
            }
            textBox1.Text=textBox1.Text+DateTime.UtcNow.ToString()+j+"end \r\n";
            j++;
        }
        private static void threadtimer_Tick(object sender, EventArgs e)
        {
            long i = 10000000000;
            while (i > 0)
            {
                i--;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int intinwork,intport;
            ThreadPool.GetMaxThreads(out intinwork, out intport);
            MessageBox.Show("Max->the number of inwork thread:" + intinwork.ToString() + "; the number of portthread:" + intport.ToString());
            ThreadPool.GetMinThreads(out intinwork, out intport);
            MessageBox.Show("Min->the number of inwork thread:" + intinwork.ToString() + "; the number of portthread:" + intport.ToString());
        }
        static void DoWork()
        {
            //the event not call
            System.Windows.Forms.Timer threadtimer = new System.Windows.Forms.Timer();
            threadtimer.Interval = 1000;
            threadtimer.Tick += new System.EventHandler(threadtimer_Tick);
            threadtimer.Enabled = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(DoWork);
            t.Start();

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SafeTimer.Init();
            UnSafeTimer.Init();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //ThreadingUnSafeTimer.Init(100000,true);
            ThreadingSafeTimer.Init();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //
            // e.Argument always contains whatever was sent to the background worker
            // in RunWorkerAsync. We can simply cast it to its original type.
            //
            TestObject argumentTest = e.Argument as TestObject;

            //
            // Boring....
            //
            Thread.Sleep(10000);

            argumentTest.OneValue = 6;
            argumentTest.TwoValue = 3;

            //
            // Now, return the values we generated in this method.
            // ... Use e.Result.
            //
            e.Result = argumentTest;

        }
        /// <summary>
        /// The test class for our example.
        /// </summary>
        class TestObject
        {
            public int OneValue { get; set; }
            public int TwoValue { get; set; }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //
            // Example argument object
            //
            TestObject test = new TestObject
            {
                OneValue = 5,
                TwoValue = 4
            };
            //
            // Send argument to our worker thread
            //
            backgroundWorker1.RunWorkerAsync(test);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //
            // Receive the result from DoWork, and display it.
            //
            TestObject test = e.Result as TestObject;
            textBox1.Text = test.OneValue.ToString() + " " + test.TwoValue.ToString();
            //
            // Will display "6 3" in title Text (in this example)
            //
        }

    }
}
