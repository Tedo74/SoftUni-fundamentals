using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Largest3Numbers
{
    class Largest3Numbers
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            nums = nums.OrderByDescending(n => n).Take(3).ToList();
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
