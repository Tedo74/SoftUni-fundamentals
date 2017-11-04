using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StringDecryption
{
    class StringDecryption
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numbersSkip = input[0];
            int numbersTake = input[1];
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            numbers = numbers.Where(n => n >= 65 && n <= 90).Skip(numbersSkip).Take(numbersTake).ToList();
            Console.WriteLine(string.Join("",numbers.Select(x =>(char)x)).ToCharArray());
            
        }
    }
}
