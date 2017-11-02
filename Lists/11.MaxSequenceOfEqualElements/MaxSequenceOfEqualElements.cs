using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int counter = 1;
            int maxCount = 1;
            int n = numbers[0];
            for (int i = 0; i < numbers.Length -1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                    if (maxCount < counter)
                    {
                        maxCount = counter;
                        n = numbers[i];
                    }
                }
                else
                {
                    counter = 1;
                }
            }
            int[] result = new int[maxCount];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = n;
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
