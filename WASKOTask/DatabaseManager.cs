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
                Console.WriteLine("\n");

                //show all records
                if (oper == '1')
                {

                    Console.WriteLine(String.Format("{0, -15} {1, -15} {2, -4}", "Producent", "Model", "Pojemność"));
                    foreach (Car car in cars.GetAllRecords())
                    {
                        Console.Write(car.ToString());
                    }
                }
                //add a new record
                else if (oper == '2')
                {
                    Console.WriteLine("Dodawanie nowego rekordu\n");

                    Console.Write("Podaj producenta: ");
                    string manufacturer = Console.ReadLine();
                    Console.Write("Podaj model: ");
                    string model = Console.ReadLine();
                    Console.Write("Podaj pojemnosc: ");
                    string capacity = Console.ReadLine();
                    
                    //validate all attributes
                    if (CarValidator.isManufacturerValid(manufacturer) && CarValidator.isModelValid(model) && CarValidator.isCapacityValid(capacity))
                    {
                        cars.AddToBuffer(new Car(manufacturer, model, Convert.ToDouble(capacity.Replace(".",","), new CultureInfo("pl-PL"))));
                        Console.WriteLine("Rekord dodany do bufora.");
                    }
                    else Console.WriteLine("Nie mozna dodac rekordu. Nie wszystkie dane sa poprawne.");
                }
                //exit
                else if (oper == '3')
                {
                    continue;
                }
                //show non-existing option prompt
                else
                {
                    Console.WriteLine("Wybrano nieistniejącą opcję");
                }

                Console.WriteLine("\n");
            }
        }
    }
}
