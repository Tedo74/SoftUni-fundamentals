using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Snowman
{
    public class Snowman
    {
        public static void Main()
        {
            List<int> snowmans = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (snowmans.Count > 1)
            {
                for (int i = 0; i < snowmans.Count; i++)
                {

                    if (snowmans.Count(x => x != -1) == 1)
                    {
                        break;
                    }
                    if (snowmans[i] == -1)
                    {
                        continue;
                    }

                    int attacker = i;
                    int target = snowmans[i] % snowmans.Count;
                    
                    int difference = Math.Abs(attacker - target);
                    if (difference == 0)
                    {
                        //suicide
                        snowmans[attacker] = -1;
                        Console.WriteLine($"{attacker} performed harakiri");
                    }
                    else if (difference % 2 == 0)
                    {
                        // attacker wins
                        snowmans[target] = -1;
                        Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                    }
                    else
                    {
                        // target wins
                        snowmans[attacker] = -1;
                        Console.WriteLine($"{attacker} x {target} -> {target} wins");
                    }
                }

                snowmans = snowmans.Where(x => x != -1).ToList();
            }
        }
    }
}
