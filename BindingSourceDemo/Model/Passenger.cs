using System;
using System.Collections.Generic;
using System.Text;
using BindingSourceDemo.Utility;

namespace BindingSourceDemo.Model
{
    public class Passenger
    {
        #region Private fields
        private static int _lastID = 0;
        private int _id;
        private string _name;
        #endregion

        #region Public properties
        public int ID 
        { 
            get { return _id; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region Constructors
        public Passenger(string name)
        {
            _id = ++_lastID;
            _name = name;
        }
        #endregion
    }
}
