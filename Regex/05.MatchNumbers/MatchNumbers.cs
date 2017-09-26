using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.MatchNumbers
{
    class MatchNumbers
    {
        static void Main()
        {
            string pattern = @"(^|(?<=\s))-?[\d]+(\.\d+)?($|(?=\s))";
            string numbers = Console.ReadLine();
            List<string> matchedNumbers = Regex.Matches(numbers, pattern).Cast<Match>().Select(n => n.Value.Trim()).ToList();
            Console.WriteLine(string.Join(" ", matchedNumbers));
        }
    }
}
