using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.MatchDates
{
    class MatchDates
    {
        static void Main()
        {
            Regex pattern = new Regex(@"(?<day>\d{2})([-\.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b");
            string dates = Console.ReadLine();
            MatchCollection matchedDates = pattern.Matches(dates);
           
            foreach (Match d in matchedDates)
            {
                string day = d.Groups["day"].Value;
                string month = d.Groups["month"].Value;
                string year = d.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
