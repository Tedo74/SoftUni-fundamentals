using System;
using System.Linq;

namespace _02.RotateAndSum
{
    public class RotateAndSum
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());
            int[] sum = new int[arr.Length];
            for (int i = 0; i < rotations; i++)
            {
                RotateArray(arr);
                for (int j = 0; j < arr.Length; j++)
                {
                    sum[j] = arr[j] + sum[j];
                }
            }
            Console.WriteLine(string.Join(" ", sum));
        }

        public static void RotateArray(int[] arr)
        {
            int last = arr[arr.Length - 1];
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                arr[i + 1] = arr[i];
            }
            arr[0] = last;
        }
    }
}
