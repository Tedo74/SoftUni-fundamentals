using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ValueOfString
{
    class ValueOfString
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();
            Console.WriteLine("The total sum is: "+ SumOfLetters(input, command));
        }

        private static int SumOfLetters(string input, string command)
        {
            int sum = 0;
            foreach (var letter in input)
            {
                if (command == "LOWERCASE" && char.IsLower(letter) && char.IsLetter(letter))
                {
                    sum += letter;
                }
                else if (command == "UPPERCASE" && char.IsUpper(letter) && char.IsLetter(letter))
                {
                    sum += letter;
                }
            }
            return sum;
        }
    }
}
