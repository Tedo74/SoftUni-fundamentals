using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _1.Cards
{
    class Cards
    {
        public static void Main()
        {
            List<string> goodCards = new List<string>();
            string input = Console.ReadLine();
            string pattern = @"(\d+|[JQKA])[SHCD]{1}";
            MatchCollection cards = Regex.Matches(input, pattern);
            foreach (Match card in cards)
            {
                int power = 0;
                if (int.TryParse(card.Groups[1].Value, out power))
                {
                    if (power < 2 || power > 10)
                    {
                        continue;
                    }
                }
                goodCards.Add(card.Value);
            }
            Console.WriteLine(string.Join(", ", goodCards));
        }
    }
}
