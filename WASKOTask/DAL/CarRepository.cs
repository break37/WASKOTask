using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WASKOTask.DAL
{
    class CarRepository
    {
        #region MySQL queries
        private const string SELECT_ALL_CARS = "SELECT * FROM cars";
        #endregion

        #region MySQL error messages
        private const string CONNECTION_REFUSED = "Nie mozna nawiazac polaczenia z baza danych";
        private const string QUERY_ERROR = "Nie udalo sie wykonac polecenia";
        #endregion

        private CarsBuffer buffer;
        
        public CarRepository()
        {
            buffer = new CarsBuffer();
            StartAutoAdd();
        }

        #region Functions
        public void AddToBuffer(Car car)
        {
            buffer.AddRecord(car);
        }

        public void SaveRecords()
        {
            foreach (Car car in buffer.Cars.ToList()) //ToList() prevent from collection modified
            {
                try
                { 
                    using (MySqlConnection connection = DBConnection.Instance.Connection)
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand())
                        {
                            command.Connection = connection;
                            command.CommandText = "INSERT INTO cars (manufacturer, model, capacity) VALUES (@manu, @model, @capa)";
                            command.Parameters.Add(new MySqlParameter("@manu", car.Manufacturer));
                            command.Parameters.Add(new MySqlParameter("@model", car.Model));
                            command.Parameters.Add(new MySqlParameter("@capa", car.Capacity));
                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                    buffer.Clear();
                }
                catch (MySqlException)
                {
                    Console.WriteLine(CONNECTION_REFUSED);
                }
            }
        }

        public List<Car> GetAllRecords()
        {
            List<Car> carsToShow = new List<Car>();
            try
            {
                using (MySqlConnection connection = DBConnection.Instance.Connection)
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(SELECT_ALL_CARS, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        carsToShow.Add(new Car(reader));
                    }

                    connection.Close();
                }
            }
            catch (MySqlException)
            {
                Console.WriteLine(CONNECTION_REFUSED);
            }
            catch (Exception)
            {
                Console.WriteLine(QUERY_ERROR);
            }

            return carsToShow;
        }

        private void StartAutoAdd()
        {
            Task saveBuffer = new Task(
                new Action(() =>
                {
                    for ( ; ; )
                    {
                        if (!buffer.IsEmpty())
                        {
                            SaveRecords();
                            buffer.Clear();
                            System.Threading.Thread.Sleep(30000);
                        }
                    }
                })
            );
            saveBuffer.Start(); 
        }
        #endregion
    }
}
