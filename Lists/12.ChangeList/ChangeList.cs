using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            bool stop = false;
            while (!stop)
            {
                string[] command = Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
                switch (command[0])
                {
                    case "Delete":
                        numbers.RemoveAll(n => n == int.Parse(command[1]));
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                    case "Odd":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 != 0)));
                        stop = true;
                        break;
                    case "Even":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 0)));
                        stop = true;
                        break;
                }
            }
        }
    }
}
