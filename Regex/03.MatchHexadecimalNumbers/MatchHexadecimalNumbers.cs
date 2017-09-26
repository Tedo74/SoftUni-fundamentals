using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.MatchHexadecimalNumbers
{
    class MatchHexadecimalNumbers
    {
        static void Main()
        {
            string pattern = @"(0x)?[0-9A-F]+\b";
            string hex = Console.ReadLine();
            List<Match> matches = Regex.Matches(hex, pattern).Cast<Match>().ToList();
            Console.WriteLine(string.Join(" ", matches));
        }
    }
}
