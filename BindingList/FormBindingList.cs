using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//https://www.cnblogs.com/guofeiji/p/5277834.html  C#-INotifyPropertyChanged(解决数据绑定的界面刷新问题)

namespace BindingList
{
    public partial class FormBindingList : Form
    {
        private BindingList<Customer> customers = new BindingList<Customer>();
        public FormBindingList()
        {
            InitializeComponent();
            customers.Add(new Customer() { CustomerName = "张三", PhoneNumber = "010-5263" });
            customers.Add(new Customer() { CustomerName = "李四", PhoneNumber = "010-8823" });
            dataGridView1.DataSource = customers;
        }
        
        private void btnChangeValue_Click(object sender, EventArgs e)
        {
            customers[0].CustomerName = "王五";
        }
    }
}
