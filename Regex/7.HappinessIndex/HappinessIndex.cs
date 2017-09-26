using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _7.HappinessIndex
{
    class HappinessIndex
    {
        public static void Main()
        {
            string happinesPattern = @"([\(*c\[][:;])|([:;][\)D*\]\}])";
            string sadPattern = @"([:;][\(\[\{c])|([D\)\]]:)|];";
            Regex happy = new Regex(happinesPattern);
            Regex sad = new Regex(sadPattern);
            string input = Console.ReadLine();
            int happyCount = happy.Matches(input).Count;
            int sadCount = sad.Matches(input).Count;
            double happinesIndex = Math.Round((double)happyCount / sadCount, 2);
            Console.WriteLine($"Happiness index: {happinesIndex:F2} {Emoticon(happinesIndex)}");
            Console.WriteLine($"[Happy count: {happyCount}, Sad count: {sadCount}]");
        }

        static string Emoticon(double index)
        {
            if (index >= 2)
            {
                return ":D";
            }
            else if (index > 1)
            {
                return ":)";
            }
            else if (index == 1)
            {
                return ":|";
            }
            return ":(";
        }
    }
}
