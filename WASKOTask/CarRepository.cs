using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WASKOTask
{
    class CarRepository
    {
        private List<Car> cars;
        
        public CarRepository()
        {
            cars = new List<Car>()
            {
                new Car("Audi", "A8", 2.4),
                new Car("Honda", "Civic", 1.4),
                new Car("Fiat", "Seicento", 0.9),
                new Car("Subaru", "Legacy", 1.2),
                new Car("Toyota", "Corolla", 1.3),
                new Car("Fiat", "Punto", 1.4),
                new Car("BMW", "Z3", 1.8),
            };
        }

        #region Functional functions
        public void AddRecord(Car car)
        {
            cars.Add(car);
        }

        public void SaveRecords(string path)
        {
            string fileContent = "";

            foreach (Car car in cars)
            {
                fileContent += car.ToString();
            }

            File.WriteAllText(path, fileContent);
        }
        #endregion

        #region Display functions
        public void ShowAllRecords()
        {
            Console.WriteLine(String.Format("{0, -15} {1, -10} {2, -4}", "Producent", "Model", "Pojemność"));

            foreach (Car car in cars)
            {
                Console.Write(car.ToString());
            }
        }
        #endregion
    }
}
