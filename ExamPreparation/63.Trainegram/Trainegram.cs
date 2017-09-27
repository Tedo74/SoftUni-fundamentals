using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _63.Trainegram
{
    class Trainegram
    {
        static void Main(string[] args)
        {
            List<string> trains = new List<string>();
            string input = Console.ReadLine();
            string pattern = @"^(<\[[^A-Za-z0-9]*?\]\.)+(\.\[[A-Za-z0-9]*?\]\.)*$";
            Regex trainRegex = new Regex(pattern);
            while (input != "Traincode!")
            {
                if (trainRegex.IsMatch(input))
                {
                    trains.Add(input);
                }
                input = Console.ReadLine();
            }
            foreach (var train in trains)
            {
                Console.WriteLine(train);
            }
        }
    }
}
