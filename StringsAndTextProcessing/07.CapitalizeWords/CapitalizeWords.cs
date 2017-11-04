using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CapitalizeWords
{
    class CapitalizeWords
    {
        static void Main()
        {
            List<string> words = new List<string>();
            char[] delimeter = new char[]
                {' ', ',', '.', '!', '?', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', ';', ':'};
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split(delimeter,StringSplitOptions.RemoveEmptyEntries);
                foreach (var t in tokens)
                {
                    string repaired = Repair(t);
                    words.Add(repaired);
                }
                Console.WriteLine(string.Join(", ", words));
                words.Clear();
                input = Console.ReadLine();
            }
        }

        static string Repair(string word)
        {
            StringBuilder newWord = new StringBuilder(word);
                newWord[0] = char.ToUpper(newWord[0]);
                for (int i = 1; i < newWord.Length; i++)
                {
                    newWord[i] = char.ToLower(newWord[i]);
                }
            return newWord.ToString();
        }
    }
}
