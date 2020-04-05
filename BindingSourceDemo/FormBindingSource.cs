using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//Add new namespace
using BindingSourceDemo.Model;
using System.Diagnostics;

namespace BindingSourceDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        BindingSource bsA = new BindingSource(); // Airplanes
        BindingSource bsP = new BindingSource(); // Passengers

        private void Form1_Load(object sender, EventArgs e)
        {
            bsP.ListChanged += new ListChangedEventHandler(bsP_ListChanged);

            // Create some example data.
            Airplane a1, a2, a3;
            bsA.Add(a1 = new Airplane("Boeing 747", 800));
            bsA.Add(a2 = new Airplane("Airbus A380", 1023));
            bsA.Add(a3 = new Airplane("Cessna 162", 67));
            a1.Passengers.Add(new Passenger("Joe Shmuck"));
            a1.Passengers.Add(new Passenger("Jack B. Nimble"));
            a1.Passengers.Add(new Passenger("Jib Jab"));
            a2.Passengers.Add(new Passenger("Jackie Tyler"));
            a2.Passengers.Add(new Passenger("Jane Doe"));
            a3.Passengers.Add(new Passenger("John Smith"));

            bsP.DataSource = bsA; // connect the two sources
            bsP.DataMember = "Passengers";

            // Set up data binding for the parent Airplanes
            grid.DataSource = bsA;
            grid.AutoGenerateColumns = true;
            txtModel.DataBindings.Add("Text", bsA, "Model");

            // Set up data binding for the child Passengers
            lstPassengers.DataSource = bsP;
            lstPassengers.DisplayMember = "Name";
            txtName.DataBindings.Add("Text", bsP, "Name");

            // Allow the user to add rows
            ((BindingList<Airplane>)bsA.List).AllowNew = true;
            ((BindingList<Airplane>)bsA.List).AllowRemove = true;
        }

        void bsP_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.Reset)
                txtName.Enabled = bsP.Current != null;
        }
    }
}
