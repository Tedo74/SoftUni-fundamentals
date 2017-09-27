using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _23.RageQuit
{
    class RageQuit
    {
        public static void Main()
        {
            HashSet<char> uniques = new HashSet<char>();
            //List<string> toPrint = new List<string>();
            string pattern = @"(?<text>\D+)(?<number>\d+)";
            Regex gamer = new Regex(pattern);
            string input = Console.ReadLine();
            MatchCollection words = gamer.Matches(input);
            StringBuilder toPrint = new StringBuilder();
            foreach (Match m in words)
            {
                string text = m.Groups["text"].Value.ToUpper();
                int repeat = int.Parse(m.Groups["number"].Value);
                if (repeat > 0)
                {
                    foreach (char c in text)
                    {
                        uniques.Add(c);
                    }
                }
                for (int i = 0; i < repeat; i++)
                {
                    toPrint.Append(text);
                }

            }
            Console.WriteLine($"Unique symbols used: {uniques.Count}");
            Console.WriteLine(toPrint);
        }
    }
}
