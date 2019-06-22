using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using WASKOTask.DAL;
using System.Globalization;

namespace WASKOTask
{
    class DatabaseManager
    {
        static void Main(string[] args)
        {
            CarRepository cars = new CarRepository();

            char oper = '0';

            //show main menu
            while (oper != '3')
            {
                Console.Write("Podaj operacje (1 - lista, 2 - dodawanie, 3 – wyjscie): ");
                oper = Console.ReadKey().KeyChar;
                Console.WriteLine();

                //show all records
                if (oper == '1')
                {
                    ShowCars(cars);
                }
                //add a new record
                else if (oper == '2')
                {
                    AddNewRecord(cars);
                }
                //exit
                else if (oper == '3')
                {
                    cars.SaveRecords();
                    continue;
                }
                //show non-existing option prompt
                else
                {
                    Console.WriteLine("Wybrano nieistniejącą opcję");
                }

                Console.WriteLine();
            }
        }

        private static void ShowCars(CarRepository source)
        {
            Console.WriteLine(String.Format("{0, -15} {1, -15} {2, -9}", "Producent", "Model", "Pojemność"));
            Console.WriteLine("-----------------------------------------");
            foreach (Car car in source.GetAllRecords())
            {
                Console.Write(car.ToString());
            }
        }

        private static void AddNewRecord(CarRepository destination)
        {
            Console.WriteLine("Dodawanie nowego rekordu");

            Console.Write("Podaj producenta: ");
            string manufacturer = Console.ReadLine();
            Console.Write("Podaj model: ");
            string model = Console.ReadLine();
            Console.Write("Podaj pojemnosc: ");
            string capacity = Console.ReadLine();

            //validate all attributes
            if (CarValidator.IsManufacturerValid(manufacturer) && CarValidator.IsModelValid(model) && CarValidator.IsCapacityValid(capacity))
            {
                destination.AddToBuffer(new Car(manufacturer, model, Convert.ToDouble(capacity.Replace(",", "."), new CultureInfo("en-US"))));
                Console.WriteLine("Rekord dodany do bufora.");
            }
            else Console.WriteLine("Nie mozna dodac rekordu. Nie wszystkie dane sa poprawne.");
        }
    }
}