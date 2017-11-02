using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CountNumbers
{
    class CountNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int maxNumber = numbers.Max();
            int[] result = new int[maxNumber + 1];
            for (int i = 0; i < numbers.Length; i++)
            {
                result[numbers[i]]++;
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != 0)
                {
                    Console.WriteLine($"{i} -> {result[i]}");
                }
            }
        }
    }
}
