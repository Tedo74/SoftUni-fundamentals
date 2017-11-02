using System;
using System.Linq;

namespace _16.SumReversedNumbers
{
    public class SumReversedNumbers
    {
        public static void Main()
        {
            Console.WriteLine(Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(new string(n.Reverse().ToArray())))
                .ToArray()
                .Sum());
        }
    }
}
