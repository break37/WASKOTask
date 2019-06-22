using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace WASKOTask
{
    class Car
    {
        #region Properties
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Capacity { get; set; }
        #endregion

        public Car() { }

        public Car(string manufacturer, string model, double capacity)
        {
            Manufacturer = manufacturer;
            Model = model;
            Capacity = capacity;
        }

        public Car(MySqlDataReader reader)
        {
            Manufacturer = reader["manufacturer"].ToString();
            Model = reader["model"].ToString();
            Capacity = Convert.ToDouble(reader["capacity"]);
        }
        
        public bool isReadyToAdd()
        {
            if (!String.IsNullOrEmpty(Manufacturer) && !String.IsNullOrEmpty(Model) && !Double.IsNaN(Capacity))
                return true;
            return false;
        }

        public override string ToString()
        {
            return String.Format("{0, -15} {1, -15} {2, -9:0.0##}\n", Manufacturer, Model, Capacity);
        }
    }
}

