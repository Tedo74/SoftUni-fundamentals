using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _42.Icarus
{
    class Icarus
    {
        static void Main(string[] args)
        {
            int damage = 1;
            int[] plane = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int startPosition = int.Parse(Console.ReadLine());
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Supernova")
                {
                    break;
                }
                string[] commands = input.Split(' ');
                string direction = commands[0];
                int steps = int.Parse(commands[1]);
                int position = startPosition;
                if (direction == "right")
                {
                    while (steps > 0)
                    {
                        position++;
                        if (position > plane.Length - 1)
                        {
                            position = 0;
                            damage++;
                        }
                        plane[position] = plane[position] - damage;
                        steps--;
                    }
                }
                else if (direction == "left")
                {
                    while (steps > 0)
                    {
                        position--;
                        if (position < 0)
                        {
                            position = plane.Length - 1;
                            damage++;
                        }
                        plane[position] = plane[position] - damage;
                        steps--;
                    }
                }
                startPosition = position;
            }
            Console.WriteLine(string.Join(" ", plane));
        }
    }
}
