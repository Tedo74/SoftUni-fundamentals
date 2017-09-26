using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2.WordEncounter
{
    class WordEncounter
    {
        public static void Main()
        {
            List<string> result = new List<string>();
            string filter = Console.ReadLine();
            char letter = filter[0];
            int counter = int.Parse(filter.Substring(1));
            string input = Console.ReadLine();

            while (input != "end")
            {
                string pattern1 = @"(^[A-Z]).*([!\.?]$)";
                Match sentence = Regex.Match(input, pattern1);
                string validSentence = sentence.Groups[0].Value;
                string pattern2 = @"\w+";
                MatchCollection words = Regex.Matches(validSentence, pattern2);
                foreach (Match word in words)
                {
                    if (checkWord(word.Value, letter, counter))
                    {
                        result.Add(word.Value);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", result));
        }

        static bool checkWord(string s, char filter, int countLetter)
        {
            int cnt = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == filter)
                {
                    cnt++;
                }
            }
            if (cnt >= countLetter)
            {
                return true;
            }
            return false;
        }
    }
}
