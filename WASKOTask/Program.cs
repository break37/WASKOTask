using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WASKOTask
{
    class Program
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
                    cars.ShowAllRecords();
                    Console.WriteLine();
                    cars.SaveRecords(@"C:\Users\Hubert\Desktop\cars.txt");
                }
                //add a new record
                else if (oper == '2')
                {
                    //int controlSum = 0;

                    Console.WriteLine("Dodawanie nowego rekordu");
                    Console.WriteLine();

                    //Console.Write("Podaj producenta: ");
                    //string manufacturer = Console.ReadLine();
                    //if (IsValidManu(manufacturer))
                    //{
                    //    controlSum++;
                    //}

                    //Console.Write("Podaj model: ");
                    //string model = Console.ReadLine();
                    //if (IsValidManu(model))
                    //{
                    //    controlSum++;
                    //}

                    //Console.Write("Podaj producenta: ");
                    //double capacity = Convert.ToDouble(Console.ReadLine());   
                    
                }
                //exit
                else if (oper == '3')
                {
                    Console.WriteLine("Wybrano wyjście");
                    continue;
                }
                //show non-existing option prompt
                else
                {
                    Console.WriteLine("Wybrano nieistniejącą opcję");
                }
            }
        }

        private static bool IsValidManu(string manufacturer)
        {
            //if first letter is capital
            if (manufacturer[0] >= 65 && manufacturer[0] <= 90)
                if (!manufacturer.Contains(" "))
                    return true;
            return false;
        }

        private static bool IsValidModel(string model)
        {
            //check model validity
            return false;
        }

    }
}
