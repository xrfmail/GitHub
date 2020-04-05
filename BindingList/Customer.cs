﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BindingList
{
    public class Customer : INotifyPropertyChanged
    {
        private string _customerName;
        private string _phoneNumber;

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (_customerName != value)
                {
                    _customerName = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("CustomerName"));
                }
            }
        }


        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PhoneNumber"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
