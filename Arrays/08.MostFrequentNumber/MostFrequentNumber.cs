using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MostFrequentNumber
{
    public class MostFrequentNumber
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine()
                         .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse)
                         .ToArray();
            
            int maxCount = 0;
            int winner = 0;
            bool isThereWinner = false;
            for (int i = 0; i < nums.Length; i++)
            {
                int number = nums[i];
                int count = 0;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (number == nums[j])
                    {
                        count++;
                    }
                    if (maxCount < count)
                    {
                        maxCount = count;
                        winner = number;
                        isThereWinner = true;
                    }
                }
            }
            if (isThereWinner)
            {
                Console.WriteLine(winner);
            }
            else
            {
                Console.WriteLine(nums[0]);
            }
        }
    }
}
