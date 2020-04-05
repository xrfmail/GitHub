using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.ObjectModel;

//V0.0.0.1  20190125    DX  use Expression need .net>=3.0
//V0.0.0.2  20190217    DX  Serializable from https://docs.microsoft.com/zh-cn/dotnet/api/system.serializableattribute?redirectedfrom=MSDN&view=netframework-4.7.2
//V0.0.0.3  20190906    DX  testing ToString

namespace BindingDemo
{
    [Serializable()]
    public class BasicObject : INotifyPropertyChanged
    {
        [NonSerialized()]
        private static int _lastID = 0;
        //[NonSerialized()]
        private int _intid;
        [XmlAttribute("id")]
        public int INTID
        {
            get { return _intid; }
            set { _intid = value; }
        }

        //0=no change 1=new 2=modify 3=delete
        [NonSerialized()]
        private int _state=0;
        public int State
        {
            set {
                _state = value;
                OnStateChange(EventArgs.Empty);
            }
            get
            {
                return _state;              
            }
        }
        //[NonSerialized()]
        private string _name = string.Empty;
        [XmlElement("Name")]
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value) && value == _name)
                    return;

                _name = value;
                NotifyPropertyChanged(() => Name);              //add for binding
            }
        }

        public BasicObject()
        {

        }

        public BasicObject(string strName)
        {
            INTID = ++_lastID;
            Name = strName;
        }

        public void Post()
        {
            //save the object to somewhere then set the state to 0
            State = 0;
        }
        public virtual void Print()
        {
            Console.WriteLine("INTID = '{0}'", INTID);
            Console.WriteLine("State = '{0}'", State);
            Console.WriteLine("Name = '{0}'", Name);
        }
        public void XmlSerialize()
        {
            //Opens a file and serializes the object into it in binary format.
            Stream stream = File.Open(this.GetType().Name+INTID+".xml", FileMode.Create);
            //SoapFormatter formatter = new SoapFormatter();

            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, this);
            stream.Close();
        }
        public object XmlUnSerialize()
        {
            //Opens file "data.xml" and deserializes the object from it.
            Stream stream = File.Open(this.GetType().Name + INTID + ".xml", FileMode.Open);
            //SoapFormatter formatter = new SoapFormatter();

            BinaryFormatter formatter = new BinaryFormatter();
            object obj = Convert.ChangeType(formatter.Deserialize(stream),this.GetType());
            stream.Close();
            return obj;
        }

        #region Event for State Change
        public delegate void StateChangeHandler(object sender, EventArgs e);
        public event StateChangeHandler ChangeStateEvent;
        protected virtual void OnStateChange(EventArgs e)
        {
            if (ChangeStateEvent != null)
            {
                ChangeStateEvent(this, e);
            }
        }
        #endregion

        #region to and from string
        public override string ToString()
        {
            string strObj = "";
            foreach (PropertyInfo info in this.GetType().GetProperties())
            {
                if (info.GetValue(this, null) != null)
                {
                    strObj = strObj + info.Name + ":" + info.GetValue(this, null).ToString() + ";";
                }
            }
            strObj = strObj.TrimEnd();
            return strObj;
            //return base.ToString();
        }

        public void FromString(string strObj)
        {
            foreach (string str in strObj.Split(';'))
            {
                PropertyInfo info = this.GetType().GetProperty(str.Split(':')[0]);
                info.SetValue(this, str.Split(':')[1], null);
            }
        }
        #endregion

        #region property change
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged<T>(Expression<Func<T>> property)
        {
            if (PropertyChanged == null)
                return;

            var memberExpression = property.Body as MemberExpression;
            if (memberExpression == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
        }
        #endregion
    }

    [Serializable()]
    public class Person : BasicObject
    {
        private int _age;
        [XmlElement("Age")]
        public int Age
        {
            get { return _age; }
            set { _age = value; NotifyPropertyChanged(() => Age); }
        }
        public Person()
        {

        }
        public Person(string strName,int intAge) : base(strName)
        {
            Age = intAge;
        }

        public void SayHello(Person another)
        {  //构造方法重载同名的sayHello方法
            Console.WriteLine("Hello," + another.Name + "! My name is " + Name);
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Age = '{0}'", Age);
        }
    }

    [Serializable()]
    public class Student : Person
    {
        private string _school;
        public string School
        {
            get { return _school; }
            set { _school = value; NotifyPropertyChanged(() => School); }
        }

        public Student()
        {

        }
        public Student(string strName,int intAge,string strSchool) : base(strName, intAge)
        {
            School = strSchool;
        }
        public  void  SayHello(Student another)
        {  //构造方法重载同名的sayHello方法
            base.SayHello(another);
            Console.WriteLine("My school is " + School);
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("School = '{0}'", School);
        }
    }
    [Serializable()]
    [XmlRoot("Teacher")]
    public class Teacher : Person
    {
        public Teacher()
        {

        }
        public Teacher(string strName, int intAge) : base(strName, intAge)
        {
            _students = new List<Student>();
        }

        //[NonSerialized()]
        private List<Student> _students;

        [XmlArrayItem("Student", typeof(Student))]
        [XmlArray("Students")]
        public List<Student> Student
        {
            get { return _students; }
        }


    }
}
