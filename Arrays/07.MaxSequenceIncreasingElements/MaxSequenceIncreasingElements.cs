using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MaxSequenceIncreasingElements
{
    public class MaxSequenceIncreasingElements
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int maxLength = 0;
            int length = 1;
            int index = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] < arr[i])
                {
                    length++;
                }
                else
                {
                    length = 1;
                }
                if (maxLength < length)
                {
                    maxLength = length;
                    index = i;
                }
            }
            int[] result = arr.Skip(index + 1 - maxLength).Take(maxLength).ToArray();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
