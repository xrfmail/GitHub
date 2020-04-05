using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace PortScaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            button1.Enabled = false;
            Program.Scan(this.textBox1, txtHost.Text, txtPortRange.Text, button1);
        }

        public class Program
        {
            //已扫描端口数目
            internal static int scannedCount = 0;

            internal static int runningThreadCount = 0;

            internal static List<int> openedPorts = new List<int>();
            internal static List<int> closedPorts = new List<int>();

            static int startPort = 1;
            static int endPort = 500;

            static int maxThread = 100;


            public static void Scan(System.Windows.Forms.TextBox aTextBox, string aHost, string aPortRange, Button aButton)
            {
                openedPorts.Clear();
                closedPorts.Clear();
                scannedCount = 0;
                runningThreadCount = 0;
                startPort = 0;
                endPort = 0;

                string host = aHost;
                string portRange = aPortRange;
                startPort = int.Parse(portRange.Split('-')[0].Trim());
                endPort = int.Parse(portRange.Split('-')[1].Trim());

                for (int port = startPort; port < endPort; port++)
                {
                    Scanner scanner = new Scanner(host, port);
                    Thread thread = new Thread(new ThreadStart(scanner.Scan));
                    thread.Name = port.ToString();
                    thread.IsBackground = true;
                    thread.Start();

                    runningThreadCount++;
                    Thread.Sleep(10);

                    //循环，直到某个线程工作完毕才启动另一新线程，也可以叫做推拉窗技术
                    while (runningThreadCount >= maxThread) ;
                }
                //空循环，直到所有端口扫描完毕
                while (scannedCount + 1 <= (endPort - startPort))
                {
                    Thread.Sleep(10);
                    Console.WriteLine();
                }
                

                //输出结果
                aTextBox.Clear();
                aTextBox.Text = "Scan for host:"+host+" has been completed, \r\n total "+(endPort - startPort)+" ports scanned, \n opened ports:"+openedPorts.Count;
                foreach (int port in openedPorts)
                {
                    aTextBox.Text=aTextBox.Text+"\r\nport:"+port.ToString().PadLeft(6)+" is open";
                }
                foreach (int port in closedPorts)
                {
                    aTextBox.Text = aTextBox.Text + "\r\nport:" + port.ToString().PadLeft(6) + " is closed";
                }
                aButton.Enabled = true;
            }
        }

        class Scanner
        {
            string m_host;
            int m_port;

            public Scanner(string host, int port)
            {
                m_host = host;
                m_port = port;
            }
            public void Scan()
            {
                TcpClient tc = new TcpClient();
                tc.SendTimeout = tc.ReceiveTimeout = 2000;

                try
                {
                    tc.Connect(m_host, m_port);
                    if (tc.Connected)
                    {
                        Program.openedPorts.Add(m_port);
                    }
                }
                catch
                {
                    Program.closedPorts.Add(m_port);
                }
                finally
                {
                    tc.Close();
                    tc = null;
                    Program.scannedCount++;
                    Program.runningThreadCount--;
                }
            }
        }
    }
}
