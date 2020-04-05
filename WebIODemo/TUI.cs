using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Sys;

//V0.0.0.1  20120509    DX  Create the code and here is the example for WebIO



namespace WebIODemo
{
    public class TUI
    {
        private FormBase200 f1;
        private const int MAXIO = 11;
        private bool boConect;
        private string strConnect;
        private string strbtConnect;
        private Socket TCP_client;
        private Thread receivethread;
        private Thread statethread;

        public TUI(FormBase200 f, bool aboConect, string astrConnect, string astrbtConnect, Socket aTCP_client, Thread areceivethread, Thread astatethread)
        {
            f1 = f;
            boConect = aboConect;
            strConnect = astrConnect;
            strbtConnect = astrbtConnect;
            TCP_client = aTCP_client;
            receivethread = areceivethread;
            statethread = astatethread;
        }
        //# Thread for connection State controll
        //TCP_client.Connected  boConect
        //toolStripStatusLabel1.Text strConnect  
        //
        public void th_statecontrol()
        {
            while (true)
            {
                if (TCP_client.Connected)
                {
                    //socketconnected = true;
                    //if (strConnect != "connected")
                    //    f1.UpdateUI("connected", "toolStripStatusLabel1");
                    if (strbtConnect != "disconnect")
                        f1.UpdateUI("disconnect", "bt_connect");
                    f1.UpdateUI("true", "gb_outputs");
                    //# enable controls
                    f1.UpdateUI("true", "gb_inputs");
                    f1.UpdateUI("true", "gb_counter");
                    f1.UpdateUI("true", "gb_getset");
                }
                else
                {
                    //if (strConnect!= "no connection")
                    //    f1.UpdateUI("no connection", "toolStripStatusLabel1");
                    if (strbtConnect != "connect")
                        f1.UpdateUI("connect", "bt_connect");
                    //f1.UpdateUI("false", "socketconnected");                   
                    f1.UpdateUI("false", "gb_outputs");
                    //# disable controls
                    f1.UpdateUI("false", "gb_inputs");                  
                    f1.UpdateUI("false", "gb_counter");
                    f1.UpdateUI("false", "gb_getset");
                }
                Thread.Sleep(1000);
            }
            
        }
        //# thread for receive data from socket
        public void th_readdata()
        {
            int indexcount = 0;
            //int positioncount = 0;
            int positionindex = 0;
            byte[] receivebytes = new byte[1025];
            int receivebytescount = 0;
            string receivestring = null;
            int hexvalue = 0;
            while (true)
            {
                if (TCP_client.Connected)
                {
                    try
                    {
                        receivebytescount = TCP_client.Receive(receivebytes);
                        //# on error
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            receivethread.Abort();
                            //# stop thread for receive data
                            statethread.Abort();
                            //# stop thread for connection control
                        }
                        catch (Exception ext)
                        {
                        }
                        TCP_client.Close();
                        //f1.UpdateUI("false", "socketconnected");
                        //# disable controls
                        f1.UpdateUI("false", "gb_outputs");
                        f1.UpdateUI("false", "gb_inputs");
                        f1.UpdateUI("false", "gb_counter");
                        f1.UpdateUI("false", "gb_getset");
                        //if (strConnect != "no connection")
                        //    f1.UpdateUI("no connection", "toolStripStatusLabel1");
                    }
                }
                //output?input?counter?->ON?OFF
                if (receivebytescount != 0)
                {
                    receivestring = System.Text.Encoding.ASCII.GetString(receivebytes, 0, receivebytescount);
                    //# receive output state
                    if (receivestring.IndexOf("output") != -1)
                    {
                        positionindex = receivestring.LastIndexOf(";");
                        //# single output ON  
                        if (receivestring.IndexOf("ON") != -1)
                        {
                            if (Regex.IsMatch(receivestring.Substring(positionindex - 1, 2).Trim(), @"^((\d+)|-|.)?([1-9]\d+|\d)((\.\d+)|(\.))?$ "))
                            {
                                f1.UpdateUI("true", "cb_output" + receivestring.Substring(positionindex - 1, 2));
                                //# outputs 10 + 11
                            }
                            else
                            {
                                f1.UpdateUI("true", "cb_output" + receivestring.Substring(positionindex-1, 1));
                                //# outputs 0 - 9
                            }
                            //# single output ON
                        }
                        else if (receivestring.IndexOf("OFF") != -1)
                        {
                            
                            if (Regex.IsMatch(receivestring.Substring(positionindex - 1, 2).Trim(), @"^((\d+)|-|.)?([1-9]\d+|\d)((\.\d+)|(\.))?$ "))
                            {
                                f1.UpdateUI("false", "cb_output" + receivestring.Substring(positionindex - 1, 2));
                                //# outputs 10 + 11
                            }
                            else
                            {
                                f1.UpdateUI("false", "cb_output" + receivestring.Substring(positionindex-1, 1));
                                //# outputs 0 - 9
                            }
                        }
                        else
                        {
                            hexvalue = int.Parse(receivestring.Substring(receivestring.Length - 4, 4), System.Globalization.NumberStyles.HexNumber);
                            //# all outputs
                            for (indexcount = 0; indexcount <= MAXIO; indexcount++)
                            {
                                if ((hexvalue & int.Parse(Math.Pow(2, indexcount).ToString())) == Math.Pow(2, indexcount))
                                {
                                    f1.UpdateUI("true", "cb_output" + indexcount.ToString());
                                }
                                else
                                {
                                    f1.UpdateUI("false", "cb_output" + indexcount.ToString());
                                }
                            }
                        }
                    }
                    else if (receivestring.IndexOf("input") != -1)
                    {
                        //# receive output state
                        positionindex = receivestring.LastIndexOf(";");
                        //# single input ON
                        if (receivestring.IndexOf("ON") != -1)
                        {

                            if (Regex.IsMatch(receivestring.Substring(positionindex - 1, 2).Trim(), @"^((\d+)|-|.)?([1-9]\d+|\d)((\.\d+)|(\.))?$ "))
                            {
                                f1.UpdateUI("true", "cb_input" + receivestring.Substring(positionindex - 1, 2));
                                //# input 10 + 11
                            }
                            else
                            {
                                f1.UpdateUI("true", "cb_input" + receivestring.Substring(positionindex-1, 1));
                                //# input 0 - 9
                            }
                            //# single input ON
                        }
                        else if (receivestring.IndexOf("OFF") != -1)
                        {
                            if (Regex.IsMatch(receivestring.Substring(positionindex - 1, 2).Trim(), @"^((\d+)|-|.)?([1-9]\d+|\d)((\.\d+)|(\.))?$ "))
                            {
                                f1.UpdateUI("false", "cb_input" + receivestring.Substring(positionindex - 1, 2));
                                //# input 10 + 11
                            }
                            else
                            {
                                f1.UpdateUI("false", "cb_input" + receivestring.Substring(positionindex-1, 1));
                                //# input 0 - 9
                            }
                        }
                        else
                        {
                            hexvalue = int.Parse(receivestring.Substring(receivestring.Length - 4, 4), System.Globalization.NumberStyles.HexNumber);
                            //# all input
                            for (indexcount = 0; indexcount <= MAXIO; indexcount++)
                            {
                                if ((hexvalue & int.Parse(Math.Pow(2, indexcount).ToString())) == Math.Pow(2, indexcount))
                                {
                                    f1.UpdateUI("true", "cb_input" + indexcount.ToString());
                                }
                                else
                                {
                                    f1.UpdateUI("false", "cb_input" + indexcount.ToString());
                                }
                            }
                        }
                    }
                    else if (receivestring.IndexOf("counter") != -1)
                    {                        
                        //# receive counter state
                        positionindex = receivestring.LastIndexOf(";");
                        //Here must be checked:receivestring.Substring(positionindex - 1, 2)=0;
                        if (Regex.IsMatch(receivestring.Substring(positionindex - 1, 2).Trim(), @"^((\d+)|-|.)?([1-9]\d+|\d)((\.\d+)|(\.))?$ "))
                        {
                            f1.UpdateUI(receivestring.Substring( positionindex+1), "tb_counter" + receivestring.Substring(positionindex - 1, 2));
                            //# counter 10 + 11
                        }
                        else
                        {
                            f1.UpdateUI(receivestring.Substring(positionindex+1), "tb_counter" + receivestring.Substring(positionindex-1, 1));
                            //# counter 0 - 9
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
