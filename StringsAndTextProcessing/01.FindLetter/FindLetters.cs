using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FindLetter
{
    class FindLetters
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string[] letterIndex = Console.ReadLine().Split(' ');
            string letter = letterIndex[0];
            int indexToFind = int.Parse(letterIndex[1]);
            int cnt = 0;
            int result = 0;
            int index = -1;
            while (cnt < indexToFind)
            {
                result = text.IndexOf(letter, index+1);
                index = result;
                cnt++;
            }
            if (index == -1)
            {
                Console.WriteLine($"Find the letter yourself!");
            }
            else
            {
                Console.WriteLine(result);
            }
        }
    }
}
