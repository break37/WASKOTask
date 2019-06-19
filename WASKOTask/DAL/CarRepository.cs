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

        private List<Car> carsBuffer;
        
        public CarRepository()
        {
            carsBuffer = new List<Car>();
        }

        #region Functional functions
        public void AddRecord(Car car)
        {
            carsBuffer.Add(car);
        }

        public void SaveRecords(string path)
        {
            string fileContent = "";

            foreach (Car car in carsBuffer)
            {
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder();
                //create command, and add records to database
            }

            File.WriteAllText(path, fileContent);
        }
        #endregion

        #region Display functions
        public void ShowAllRecords()
        {
            List<Car> carsToShow = new List<Car>();

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

                Console.WriteLine(String.Format("{0, -15} {1, -15} {2, -4}", "Producent", "Model", "Pojemność"));
                foreach (Car car in carsToShow)
                {
                    Console.Write(car.ToString());
                }
            }
        }
        #endregion
    }
}
