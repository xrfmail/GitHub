using Sys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

//V0.0.0.1  20150720    DX  http://www.cnblogs.com/Xavierr/archive/2011/12/12/2284891.html
//V0.0.0.2  20190125    DX  add GetPropertyName and use GetPropertyName<MyData>(p => p.Name) instead of "Name"

namespace BindingDemo
{
    public partial class FormBindingText : FormBase200
    {
        Student SA,SB,SC;
        Teacher T1, T2;
        private BindingSource bsStudent;  //For Airplanes
        private BindingSource bsTeacher;  //For Passengers

        private static string EscapeSqlLike(string s_)
        {
            StringBuilder s = new StringBuilder(s_);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '\'')
                {
                    s.Insert(i++, '\'');
                    continue;
                }
                if (s[i] == '[' || s[i] == '*' || s[i] == '?')
                {
                    s.Insert(i++, '[');
                    s.Insert(++i, ']');
                }
            }
            return s.ToString();
        }

        public FormBindingText()
        {
            InitializeComponent();
            IniData();
        }

        public void IniData()
        {
            SA = new Student("tommy", 18, "xx");
            SB= new Student("jason", 19, "xx");
            SC = new Student("suny", 20, "xx");
            T1 = new Teacher("Eike", 59);
            T2 = new Teacher("Peter", 60);
            T1.Student.Add(SA);
            T1.Student.Add(SB);
            T2.Student.Add(SC);

            bsStudent = new BindingSource();
            bsTeacher = new BindingSource();

            bsTeacher.Add(T1);
            bsTeacher.Add(T2);
            bsStudent.DataSource = bsTeacher;
            bsStudent.DataMember = "Student";

            dgvTeacher.DataSource = bsTeacher;
            dgvTeacher.AutoGenerateColumns = true;
            lstStudent.DataSource = bsStudent;
            lstStudent.DisplayMember = "Name";

            ((BindingList<Teacher>)bsTeacher.List).AllowNew = true;
            ((BindingList<Teacher>)bsTeacher.List).AllowRemove = true;

            bsStudent.ListChanged += new ListChangedEventHandler(bsStudent_ListChanged);

            txtCurrentTeacher.DataBindings.Add("Text", bsTeacher, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            txtCurrentStudent.DataBindings.Add("Text", bsStudent, "Name", false, DataSourceUpdateMode.OnPropertyChanged);

            textBox1.DataBindings.Add("Text", SA, GetPropertyName<Student>(p => p.Name), false, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", SA, GetPropertyName<Student>(p => p.Name), false, DataSourceUpdateMode.Never);
        }

        private void txtStudentNameFilter_TextChanged(object sender, EventArgs e)
        {
            //不起作用
            try
            {
                // assuming bs is your BindingSource and txt is a TextBox
                bsStudent.Filter = string.Format("Name like '*{0}*'", EscapeSqlLike(txtStudentNameFilter.Text));
                //bsP.Filter = txtPassengerFilter.Text;
                txtStudentNameFilter.BackColor = SystemColors.Window;
            }
            catch (InvalidExpressionException)
            {
                txtStudentNameFilter.BackColor = Color.Pink;
            }
        }

        private void txtTeacherNameFilter_TextChanged(object sender, EventArgs e)
        {
            //不起作用
            try
            {
                // assuming bs is your BindingSource and txt is a TextBox
                bsTeacher.Filter = string.Format("Name like '*{0}*'", EscapeSqlLike(txtTeacherNameFilter.Text));
                //bsP.Filter = txtPassengerFilter.Text;
                //dgvTeacher.Refresh();    没作用
                txtTeacherNameFilter.BackColor = SystemColors.Window;
            }
            catch (InvalidExpressionException)
            {
                txtTeacherNameFilter.BackColor = Color.Pink;
            }
        }

        private void btnXmlSerialize_Click(object sender, EventArgs e)
        {
            SA = new Student("tommy", 18, "xx");
            SB = new Student("jason", 19, "xx");
            SC = new Student("suny", 20, "xx");
            T1 = new Teacher("Eike", 59);
            T2 = new Teacher("Peter", 60);
            T1.Student.Add(SA);
            T1.Student.Add(SB);
            T2.Student.Add(SC);

            T1.Print();//print the object before XmlSerialize
            T1.XmlSerialize();
            T1.Print();
            T1.Name = "Test";
            T1 = (Teacher)T1.XmlUnSerialize();
            T1.Print();

            string aa = SerializeHelper.ConvertToString(SerializeHelper.SerializeToXml(T1));
            Console.WriteLine(aa);
        }

        public static T XmlDataToModel<T>(String xmlData)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlData);

            XmlElement element = xmlDoc.DocumentElement;

            T objModel = System.Activator.CreateInstance<T>();
            foreach (XmlNode childNode in element.ChildNodes)
            {
                PropertyInfo pi = objModel.GetType().GetProperty(childNode.Name);
                if (pi == null) continue;
                if (!String.IsNullOrEmpty(childNode.InnerXml.Trim()))
                    pi.SetValue(objModel, childNode.InnerXml, null);
            }

            return objModel;
        }

        private void btnObjFromXml_Click(object sender, EventArgs e)
        {

        }

        private void bsStudent_ListChanged(object sender, ListChangedEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.ListChangedType == ListChangedType.Reset)
            {
                //do something....
            }
        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            SA.Name = "David Xie";
        }

        private void btnChangeBack_Click(object sender, EventArgs e)
        {
            SA.Name = "David";
        }
    }
}
