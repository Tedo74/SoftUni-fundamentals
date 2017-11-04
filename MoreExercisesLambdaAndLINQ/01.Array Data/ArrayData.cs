using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Array_Data
{
    class ArrayData
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();
            double average = numbers.Average();
            numbers = numbers.Where(x => x >= average).ToList();
            switch (command)
            {
                case "Min":
                    Console.WriteLine(numbers.Min());
                    break;
                case "Max":
                    Console.WriteLine(numbers.Max());
                    break;
                case "All":
                    Console.WriteLine(string.Join(" ", numbers.OrderBy(n => n)));
                    break;
            }
        }
    }
}
