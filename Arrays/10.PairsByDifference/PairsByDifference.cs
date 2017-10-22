using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PairsByDifference
{
    public class PairsByDifference
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int number = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (Math.Abs(number - nums[j]) == n)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
