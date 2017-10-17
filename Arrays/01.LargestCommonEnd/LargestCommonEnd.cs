using System;
using System.Linq;

namespace _01.LargestCommonEnd
{
    public class LargestCommonEnd
    {
        public static void Main()
        {
            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');
            int leftEquals = Equals(arr1, arr2);
            Array.Reverse(arr1);
            arr2 = arr2.Reverse().ToArray();
            int rightEquals = Equals(arr1, arr2);
            int max = Math.Max(leftEquals, rightEquals);
            Console.WriteLine(max);
        }

        private static int Equals(string[] arr1, string[] arr2)
        {
            int firstArrLength = arr1.Length;
            int secondArrLength = arr2.Length;
            int n = Math.Min(firstArrLength, secondArrLength);
            int longuestEquals = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    longuestEquals++;
                }
                else
                {
                    break;
                }
            }
            return longuestEquals;
        }
    }
}
