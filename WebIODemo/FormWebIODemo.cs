using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sys;

//V0.0.0.1  20120509    DX  Create the code and here is the example for WebIO


namespace WebIODemo
{
    public partial class FormWebIODemo : FormBase200
    {
        private const int MAXIO = 11;
        //***** dim controls with index
        CheckBox[] cb_output = new CheckBox[MAXIO + 1];
        CheckBox[] cb_input = new CheckBox[MAXIO + 1];
        Button[] bt_readcounter = new Button[MAXIO + 1];
        Button[] bt_clearcounter = new Button[MAXIO + 1];

        TextBox[] tb_counter = new TextBox[MAXIO + 1];
        //***** dim thread and socket
        //ThreadStart recthread = new ThreadStart(th_readdata);
        //ThreadStart stathread = new ThreadStart(th_statecontrol);
        Thread receivethread;
        Thread statethread;
        Socket TCP_client;
        bool socketconnected;

        public FormWebIODemo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int indexcount = 0;
            //# create checkboxes with index for output control and visualisation
            for (indexcount = 0; indexcount <= MAXIO; indexcount++)
            {
                CheckBox cb = new CheckBox();
                cb.Name = "cb_output" + indexcount.ToString();
                cb.Left = 10;
                cb.Top = 15 + indexcount * 20;
                cb.Width = 75;
                cb.Text = "output " + indexcount.ToString();
                cb.Tag = indexcount;
                cb.Visible = true;
                cb.Click += outputclick;
                gb_outputs.Controls.Add(cb);
                cb.CreateControl();
            }
            //# create checkboxes with index for input visualisation
            for (indexcount = 0; indexcount <= MAXIO; indexcount++)
            {
                CheckBox cb = new CheckBox();
                cb.Name = "cb_input" + indexcount.ToString();
                cb.Left = 10;
                cb.Top = 15 + indexcount * 20;
                cb.Width = 75;
                cb.Text = "input " + indexcount.ToString();
                cb.Tag = indexcount;
                cb.Visible = true;
                cb.Enabled = false;
                gb_inputs.Controls.Add(cb);
                cb.CreateControl();
            }
            //# create Buttons with index for read counters 
            for (indexcount = 0; indexcount <= MAXIO; indexcount++)
            {
                Button bt = new Button();
                bt.Name = "bt_readcounter" + indexcount.ToString();
                bt.Left = 10;
                bt.Top = 15 + indexcount * 20;
                bt.Width = 50;
                bt.Height = 20;
                bt.Text = "read " + indexcount.ToString();
                bt.Tag = indexcount;
                bt.Visible = true;
                bt.Click += readcounterclick;
                gb_counter.Controls.Add(bt);
                bt.CreateControl();
            }
            //# create textboxes with index for visualize counters
            for (indexcount = 0; indexcount <= MAXIO; indexcount++)
            {
                TextBox tb = new TextBox();
                tb.Name = "tb_counter" + indexcount.ToString();
                tb.Left = 60;
                tb.Top = 15 + indexcount * 20;
                tb.Width = 50;
                tb.Text = "0";
                tb.Tag = indexcount;
                tb.Visible = true;
                tb.Enabled = false;
                gb_counter.Controls.Add(tb);
                tb.CreateControl();
            }
            //# create Buttons with index for clear counters 
            for (indexcount = 0; indexcount <= MAXIO; indexcount++)
            {
                Button bt = new Button();
                bt.Name = "bt_clearcounter" + indexcount.ToString();
                bt.Left = 110;
                bt.Top = 15 + indexcount * 20;
                bt.Width = 40;
                bt.Height = 20;
                bt.Text = "clear ";
                bt.Tag = indexcount;
                bt.Visible = true;
                bt.Click += clearcounterclick;
                gb_counter.Controls.Add(bt);
                bt.CreateControl();
            }

            socketconnected = false;
        }

        private void bt_connect_Click(object sender, EventArgs e)
        {
            if (socketconnected == false)
            {
                //# open TCP connection
                IPEndPoint webioep = new IPEndPoint(IPAddress.Parse(tb_ip.Text), int.Parse(tb_port.Text));
                if (!string.IsNullOrEmpty(tb_ip.Text) & !string.IsNullOrEmpty(tb_port.Text))
                {
                    //设置网络参数
                    TCP_client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    bt_connect.Enabled = false;
                    try
                    {
                        TCP_client.Connect(webioep);
                        //# on error
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bt_connect.Enabled = true;
                    }
                    //# create thread for connectionstate control
                    TUI tUI = new TUI(this, socketconnected, toolStripStatusLabel1.Text, bt_connect.Text, TCP_client, receivethread,statethread);
                    statethread = new Thread(tUI.th_statecontrol);                    
                    statethread.Start();
                    //# create thread for receive data from socket
                    receivethread = new Thread(tUI.th_readdata);                    
                    receivethread.Priority = ThreadPriority.Highest;
                    receivethread.Start();

                    if (toolStripStatusLabel1.Text != "connected")
                        toolStripStatusLabel1.Text = "connected";
                    if (bt_connect.Text != "disconnect")
                        bt_connect.Text = "disconnect";
                    socketconnected = true;
                    gb_outputs.Enabled = true;
                    //# enable controls
                    gb_inputs.Enabled = true;
                    gb_counter.Enabled = true;
                    gb_getset.Enabled = true;
                    bt_connect.Enabled = true;
                }
            }
            else
            {
                //# close TCP connection
                try
                {
                    receivethread.Abort();
                    //# stop thread for connectio control
                    statethread.Abort();
                    //# stop thread for receive data
                    TCP_client.Close();
                    //# close TCP connection
                }
                catch (Exception ex)
                {
                   
                }
                socketconnected = false;
                gb_outputs.Enabled = false;
                //# disable controls 
                gb_inputs.Enabled = false;
                gb_counter.Enabled = false;
                gb_getset.Enabled = false;
                if (toolStripStatusLabel1.Text != "no connection")
                    toolStripStatusLabel1.Text = "no connection";
                bt_connect.Text = "connect";
            }

        }

        private void bt_getoutputs_Click(object sender, EventArgs e)
        {
            byte[] senddata = null;
            senddata = System.Text.Encoding.ASCII.GetBytes("GET /output?PW=" + tb_password.Text + "&");
            try
            {
                TCP_client.Send(senddata);
                //# on error
            }
            catch (Exception ex)
            {
                socketconnected = true;
                bt_connect_Click(sender, e);
                MessageBox.Show(ex.Message, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bt_getinputs_Click(object sender, EventArgs e)
        {
            byte[] senddata = null;
            senddata = System.Text.Encoding.ASCII.GetBytes("GET /input?PW=" + tb_password.Text + "&");
            try
            {
                TCP_client.Send(senddata);
                //# on error
            }
            catch (Exception ex)
            {
                socketconnected = true;
                bt_connect_Click(sender, e);
                MessageBox.Show(ex.Message, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bt_getsingleinput_Click(object sender, EventArgs e)
        {
            byte[] senddata = null;
            senddata = System.Text.Encoding.ASCII.GetBytes("GET /input" + co_input.Text + "?PW=" + tb_password.Text + "&");
            try
            {
                TCP_client.Send(senddata);
                //# on error
            }
            catch (Exception ex)
            {
                socketconnected = true;
                bt_connect_Click(sender, e);
                MessageBox.Show(ex.Message, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bt_setoutputs_Click(object sender, EventArgs e)
        {
            byte[] senddata = null;
            senddata = System.Text.Encoding.ASCII.GetBytes("GET /outputaccess?PW=" + tb_password.Text + "&State=" + tb_setoutputs.Text + "&");
            try
            {
                TCP_client.Send(senddata);
                //# on error
            }
            catch (Exception ex)
            {
                socketconnected = true;
                bt_connect_Click(sender, e);
                MessageBox.Show(ex.Message, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bt_getsingleoutput_Click(object sender, EventArgs e)
        {
            byte[] senddata = null;
            senddata = System.Text.Encoding.ASCII.GetBytes("GET /output" + co_output.Text + "?PW=" + tb_password.Text + "&");
            try
            {
                TCP_client.Send(senddata);
                //# on error
            }
            catch (Exception ex)
            {
                socketconnected = true;
                bt_connect_Click(sender, e);
                MessageBox.Show(ex.Message, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //
        private void outputclick(object sender, System.EventArgs e)
        {
            int indexcount = 0;
            int outputvalue = 0;
            byte[] senddata = null;
            CheckBox ck = (CheckBox)sender;
            indexcount = int.Parse(ck.Tag.ToString());
            for (indexcount = 0; indexcount <= MAXIO; indexcount++)
            {
                CheckBox cb = (CheckBox)this.Controls.Find("cb_output" + indexcount.ToString(), true)[0];
                if (cb.Checked)
                {
                    outputvalue = outputvalue + int.Parse(Math.Pow(2, indexcount).ToString());
                }
                else
                {
                    outputvalue = outputvalue & int.Parse((0xfff - Math.Pow(2, indexcount)).ToString());
                }
            }
            senddata = System.Text.Encoding.ASCII.GetBytes("GET /outputaccess?PW=" + tb_password.Text + "&State=" + Convert.ToString(outputvalue,16) + "&");
            try
            {
                TCP_client.Send(senddata);
                //# on error
            }
            catch (Exception ex)
            {
                socketconnected = false;
                bt_connect_Click(sender, e);
                MessageBox.Show(ex.Message, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        private void readcounterclick(object sender, System.EventArgs e)
        {
            byte[] senddata = null;
            int indexcount = 0;
            Button bt = (Button)sender;
            indexcount = int.Parse(bt.Tag.ToString());
            senddata = System.Text.Encoding.ASCII.GetBytes("GET /counter" + indexcount.ToString().Trim() + "?PW=" + tb_password.Text + "&");
            try
            {
                TCP_client.Send(senddata);
                //# on error
            }
            catch (Exception ex)
            {
                socketconnected = false;
                bt_connect_Click(sender, e);
                MessageBox.Show(ex.Message, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void clearcounterclick(object sender, System.EventArgs e)
        {
            byte[] senddata = null;
            int indexcount = 0;
            Button bt = (Button)sender;
            indexcount = int.Parse(bt.Tag.ToString());
            senddata = System.Text.Encoding.ASCII.GetBytes("GET /counterclear" + indexcount.ToString().Trim() + "?PW=" + tb_password.Text + "&");
            try
            {
                TCP_client.Send(senddata);
                //# on error
            }
            catch (Exception ex)
            {
                socketconnected = false;
                bt_connect_Click(sender, e);
                MessageBox.Show(ex.Message, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormWebIODemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                receivethread.Abort();
                //# stop thread for connectio control
                statethread.Abort();
                //# stop thread for receive data
                TCP_client.Close();
                //# close TCP connection
            }
            catch (Exception ex)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

    }
}
