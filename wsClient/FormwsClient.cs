using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wsClient
{
    public partial class FormwsClient : Form
    {
        public FormwsClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WeatherServiceTest.WeatherWebServiceSoapClient client = new WeatherServiceTest.WeatherWebServiceSoapClient();
            string[] province = client.getSupportProvince();
            for (int i = 0; i < province.Length; i++)
            {
                this.label1.Text += "\n" + province[i];
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            LocalServiceReference.WebService1SoapClient appclient = new LocalServiceReference.WebService1SoapClient();
            this.label2.Text += appclient.addition(9.00, 8.88);

            // soap 下面就是要传过过去用户名和密码
            LocalServiceReference.MySoapHeader my = new LocalServiceReference.MySoapHeader();
            my.Name = "KG";
            my.Password = "123456";
            /// my 做为一个参数传过去。
            this.label2.Text += appclient.HelloWorld(my);
        }
    }
}
