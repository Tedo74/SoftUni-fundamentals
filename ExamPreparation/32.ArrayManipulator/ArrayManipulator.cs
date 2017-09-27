using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32.ArrayManipulator
{
    class ArrayManipulator
    {
        public static void Main()
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split(' ');
                switch (command[0])
                {
                    case "exchange":
                        long index = long.Parse(command[1]);
                        if (index >= 0 && index <= nums.Count - 1)
                        {
                            nums = Exchange(nums, (int)index);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "max":
                        int maxIndex = GetMaxIndex(nums, command[1]);
                        if (maxIndex >= 0)
                        {
                            Console.WriteLine($"{maxIndex}");
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                        break;

                    case "min":
                        int minIndex = GetMinIndex(nums, command[1]);
                        if (minIndex >= 0)
                        {
                            Console.WriteLine($"{minIndex}");
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                        break;

                    case "first":
                        int count = int.Parse(command[1]);
                        PrintFirstsElements(nums, count, command[2]);
                        break;

                    case "last":
                        int countLast = int.Parse(command[1]);
                        PrintLastsElements(nums, countLast, command[2]);
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }
       

        private static void PrintLastsElements(List<int> nums, int count, string command)
        {
            List<int> numsToPrint = new List<int>();
            if (command == "odd")
            {
                numsToPrint = nums.Where(n => n % 2 != 0).Reverse().ToList();
            }
            else
            {
                numsToPrint = nums.Where(n => n % 2 == 0).Reverse().ToList();
            }
            if (nums.Count < count)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (!numsToPrint.Any())
            {
                Console.WriteLine("[]");
                return;
            }
            
            numsToPrint = numsToPrint.Take(count).Reverse().ToList();
            Console.WriteLine($"[{string.Join(", ", numsToPrint)}]");
        }

        private static void PrintFirstsElements(List<int> nums, int count, string command)
        {
            List<int> numsToPrint = new List<int>();
            if (command == "odd")
            {
                numsToPrint = nums.Where(n => n % 2 != 0).ToList();
            }
            else
            {
                numsToPrint = nums.Where(n => n % 2 == 0).ToList();
            }
            if (nums.Count < count)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (!numsToPrint.Any())
            {
                Console.WriteLine("[]");
                return;
            }
            
            Console.WriteLine($"[{string.Join(", ", numsToPrint.Take(count))}]");
        }

        private static int GetMaxIndex(List<int> nums, string command)
        {
            if (command == "odd")
            {
                if (nums.Any(n => n % 2 != 0))
                {
                    int maxOdd = nums.Where(n => n % 2 != 0).Max();
                    return nums.LastIndexOf(maxOdd);
                }
            }
            else // command = even
            {
                if (nums.Any(n => n % 2 == 0))
                {
                    int maxEven = nums.Where(n => n % 2 == 0).Max();
                    return nums.LastIndexOf(maxEven);
                }
            }
            return -1;
        }

        private static int GetMinIndex(List<int> nums, string command)
        {
            if (command == "odd")
            {
                if (nums.Any(n => n % 2 != 0))
                {
                    int minOdd = nums.Where(n => n % 2 != 0).Min();
                    return nums.LastIndexOf(minOdd);
                }
            }
            else // command = even
            {
                if (nums.Any(n => n % 2 == 0))
                {
                    int minEven = nums.Where(n => n % 2 == 0).Min();
                    return nums.LastIndexOf(minEven);
                }
            }
            return -1;
        }

        private static List<int> Exchange(List<int> nums, int index)
        {
            List<int> nums2 = nums.Skip(index + 1).ToList();
            nums2.AddRange(nums.Take(index + 1));
            return nums2;
        }
    }
}
