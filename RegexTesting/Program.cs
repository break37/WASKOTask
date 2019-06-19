using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegexTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                const string NAME_PATTERN = @"([0-9]\.[0-9])";
                Console.Write("Type something to test: ");
                string textToCheck = Console.ReadLine().Trim();
                Match match = Regex.Match(textToCheck, NAME_PATTERN);

                if (match.Success)
                    Console.WriteLine("Pattern matched");
                else Console.WriteLine("Patternt not matched");
            }
        }
    }
}
