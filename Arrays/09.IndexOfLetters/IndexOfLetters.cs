using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.IndexOfLetters
{
    public class IndexOfLetters
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                int index = current - 97;
                Console.WriteLine($"{current} -> {index}");
            }
        }
    }
}
