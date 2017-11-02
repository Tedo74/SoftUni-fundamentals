using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string input = Console.ReadLine();
            while (input != "print")
            {
                string[] command = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                switch (command[0])
                {
                    case "add":
                        numbers.Insert(int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "addMany":
                        numbers.InsertRange(int.Parse(command[1]), command.Skip(2).Select(int.Parse).ToArray());
                        break;
                    case "contains":
                        Console.WriteLine(numbers.IndexOf(int.Parse(command[1])));
                        break;
                    case "remove":
                        numbers.RemoveAt(int.Parse(command[1]));
                        break;
                    case "shift":
                        int n = int.Parse(command[1]);
                        n = n % numbers.Count;
                        List<int> temp = numbers.Take(n).ToList();
                        numbers.RemoveRange(0, n);
                        numbers.AddRange(temp);
                        break;
                    case "sumPairs":
                        List<int> result = new List<int>();
                        if (numbers.Count % 2 != 0)
                        {
                            numbers.Add(0);
                        }
                        for (int i = 0; i < numbers.Count; i += 2)
                        {
                            int first = numbers[i];
                            int second = numbers[i + 1];
                            result.Add(first + second);
                        }
                        numbers = result;
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
    }
}
