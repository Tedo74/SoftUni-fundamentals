using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SplitByWordCasing
{
    class SplitByWordCasing
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(new char[] { ' ', ',', ';', ':', '.', '!', '(', ')', '\"', '\'', '\\', '/', '[', ']' },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> lowerCase = new List<string>();
            List<string> upperCase = new List<string>();
            List<string> mixedCase = new List<string>();
            foreach (string word in input)
            {
                if (word.All(c => char.IsUpper(c)))
                {
                    upperCase.Add(word);
                }
                else if(word.All(c => char.IsLower(c)))
                {
                    lowerCase.Add(word);
                }
                else
                {
                    mixedCase.Add(word);
                }
            }
            Console.WriteLine($"Lower-case: "+string.Join(", ", lowerCase));
            Console.WriteLine($"Mixed-case: " +string.Join(", ", mixedCase));
            Console.WriteLine($"Upper-case: " +string.Join(", ", upperCase));
        }
    }
}
