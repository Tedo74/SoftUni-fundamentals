using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.MatchPhoneNumber
{
    class MatchPhoneNumber
    {
        static void Main()
        {
            string pattern = @"\+359([ -])2\1\d{3}\1\d{4}\b";
            string phones = Console.ReadLine();
            MatchCollection matchedPhones = Regex.Matches(phones, pattern);
            string[] phonesInSofia = matchedPhones.Cast<Match>().Select(a => a.Value.Trim()).ToArray();
            Console.WriteLine(string.Join(", ", phonesInSofia));
        }
    }
}
