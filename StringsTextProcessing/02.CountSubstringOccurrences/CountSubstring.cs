using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CountSubstringOccurrences
{
    class CountSubstring
    {
        static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string wordToSearch = Console.ReadLine().ToLower();
            int counter = 0;
            int index = text.IndexOf(wordToSearch);
            while (index != -1)
            {
                counter++;
                index = text.IndexOf(wordToSearch, index + 1);
            }
            Console.WriteLine(counter);
        }
    }
}
