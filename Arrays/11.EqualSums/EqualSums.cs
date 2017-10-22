using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EqualSums
{
    public class EqualSums
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int index = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                for (int j = 0; j < i; j++)
                {
                    leftSum += arr[j];
                }
                for (int j = i + 1; j < arr.Length; j++)
                {
                    rightSum += arr[j];
                }
                if (rightSum == leftSum)
                {
                    index = i;
                    break;
                }
            }
            if (index > -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
