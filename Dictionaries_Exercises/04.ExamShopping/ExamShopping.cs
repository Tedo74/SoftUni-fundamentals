using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ExamShopping
{
    class ExamShopping
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> inventory = new Dictionary<string, int>();
            string[] input = Console.ReadLine().Split(' ').ToArray();
            while (input[0] != "shopping" && input[1] != "time")
            {
                if (input[0] == "stock")
                {
                    if (!inventory.ContainsKey(input[1]))
                    {
                        inventory.Add(input[1], int.Parse(input[2]));
                    }
                    else
                    {
                        inventory[input[1]] += int.Parse(input[2]);
                    }
                }

                input = Console.ReadLine().Split(' ').ToArray();
            }
            do
            {
                input = Console.ReadLine().Split(' ').ToArray();
                if (input[0] == "exam" && input[1] == "time")
                {
                    break;
                }
                if (input[0] == "buy")
                {
                    if (!inventory.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"{input[1]} doesn't exist");
                    }
                    else if(inventory[input[1]] == 0)
                    {
                        Console.WriteLine($"{input[1]} out of stock");
                    }
                    else if (inventory[input[1]] < int.Parse(input[2]))
                    {
                        inventory[input[1]] = 0;
                    }
                    else
                    {
                        inventory[input[1]] -= int.Parse(input[2]);
                    }
                }
            } while (true);
            foreach (KeyValuePair<string,int> item in inventory)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
        }
    }
}
