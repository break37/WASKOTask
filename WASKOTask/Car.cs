using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WASKOTask
{
    class Car
    {
        #region Properties
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Capacity { get; set; }
        #endregion

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
        
        public override string ToString()
        {
            return String.Format("{0, -15} {1, -15} {2, -4}\n", Manufacturer, Model, Math.Round(Capacity, 1));
        }
    }
}

