using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Textfilter
{
    class Textfilter
    {
        static void Main()
        {
            string[] bannedWords = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();
            foreach (var word in bannedWords)
            {
                string replace = new string('*', word.Length);
                text = text.Replace(word, replace);
            }
            Console.WriteLine(text);
        }
    }
}
