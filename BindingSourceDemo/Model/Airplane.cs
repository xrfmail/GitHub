using System.Collections.Generic;

namespace BindingSourceDemo.Model
{
    public class Airplane
    {
        #region Private fields
        private static int _lastID = 0;
        private int _id;
        private int _fuelKg;
        private string _model;
        private List<Passenger> _passengers = new List<Passenger>();
        #endregion

        #region Public properties
        public int ID
        {
            get { return _id; }
        }
        public int FuelLeftKg
        {
            get { return _fuelKg; }
            set { _fuelKg = value; }
        }
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public List<Passenger> Passengers
        {
            get { return _passengers; }
        }
        #endregion

        #region Constructors
        public Airplane()
        {
            _id = ++_lastID;
        }
        public Airplane(string model, int fuelKg)
        {
            _id = ++_lastID;
            _model = model;
            _fuelKg = fuelKg;
        }
        #endregion
    }
}
