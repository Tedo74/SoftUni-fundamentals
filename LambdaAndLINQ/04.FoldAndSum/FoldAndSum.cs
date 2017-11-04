using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FoldAndSum
{
    class FoldAndSum
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int k = numbers.Count / 4;
            List<int> left = numbers.Take(k).Reverse().ToList();
            List<int> right = numbers.Skip(k * 3).Reverse().ToList();
            List<int> bottom = numbers.Skip(k).Take(2 * k).ToList();
            List<int> top = left.Concat(right).ToList();
            for (int i = 0; i < bottom.Count; i++)
            {
                bottom[i] += top[i];
            }
            Console.WriteLine(string.Join(" ", bottom));
        }
    }
}
