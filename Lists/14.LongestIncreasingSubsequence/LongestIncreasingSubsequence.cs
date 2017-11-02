using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.LongestIncreasingSubsequence
{
    public class LongestIncreasingSubsequence
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] len = new int[nums.Length];
            int[] prev = new int[nums.Length];
            int maxLen = 0;
            int lastIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                len[i] = 1;
                prev[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i] && len[j] + 1 > len[i])
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                    if (maxLen < len[i])
                    {
                        maxLen = len[i];
                        lastIndex = i;
                    }
                }
            }
            List<int> result = new List<int>();
            while (lastIndex > -1)
            {
                result.Add(nums[lastIndex]);
                lastIndex = prev[lastIndex];
            }
            result.Reverse();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
