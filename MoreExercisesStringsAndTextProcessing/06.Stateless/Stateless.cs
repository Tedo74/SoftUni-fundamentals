using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Stateless
{
    class Stateless
    {
        static void Main()
        {
            string word;
            while (true)
            {
                word = Console.ReadLine();
                string fiction = Console.ReadLine();
                if (word == "collapse")
                {
                    break;
                }
                word = ColapsingWord(word, fiction);
                Console.WriteLine(word);
            }
        }

        private static string ColapsingWord(string word, string fiction)
        {
            while (fiction.Length >= 1 && word != string.Empty)
            {
                word = word.Replace(fiction, String.Empty);
                fiction = fiction.Remove(0, 1);
                if (fiction.Length > 0)
                {
                    fiction = fiction.Remove(fiction.Length - 1);
                }
            }
            if (word == string.Empty)
            {
                word = "(void)";
            }
            return word.Trim();
        }
    }
}
