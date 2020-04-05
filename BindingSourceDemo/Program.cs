using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BindingSourceDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (MessageBox.Show("Use Object Mode, Click \"OK\";\r\nUse DataSet Mode, Click \"Cancel\"", "Infomation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Application.Run(new Form1());
            else
                Application.Run(new FormDataSet());
        }
    }
}
