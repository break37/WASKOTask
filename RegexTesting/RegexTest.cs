using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegexTesting
{
    class RegexTest
    {
        static void Main(string[] args)
        {
            while (true)
            {
                const string MANUFACTURER_PATTERN = @"^[A-z][a-z]*$";
                const string MODEL_PATTERN = @"^[A-z0-9]+$";
                const string CAPACITY_PATTERN = @"^[0-9]\.[0-9]$";
                Console.Write("Type something to test: ");
                string textToCheck = Console.ReadLine().Trim();
                Match match = Regex.Match(textToCheck, CAPACITY_PATTERN);
                if (match.Success)
                    Console.WriteLine("Pattern matched");
                else Console.WriteLine("Patternt not matched");
            }
        }
    }
}
