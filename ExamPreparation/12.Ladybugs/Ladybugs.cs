using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Ladybugs
{
    class Ladybugs
    {
        static void Main(string[] args)
        {
            int fildSize = int.Parse(Console.ReadLine());
            int[] ladybugsIndexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] field = new int[fildSize];
            foreach (int bug in ladybugsIndexes)
            {
                if (bug < field.Length && bug >= 0)
                {
                    field[bug] = 1;
                }
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                string[] commands = command.Split(' ');
                int position = int.Parse(commands[0]);
                string direction = commands[1];
                int flyLength = int.Parse(commands[2]);

                if (position < 0 || position >= field.Length)
                {
                    continue;
                }
                if (field[position] == 0)
                {
                    continue;
                }
                field[position] = 0;
               
                while (true)
                {
                    if (direction =="right")
                    {
                         position += flyLength;
                    }
                    else
                    {
                       position -= flyLength;
                    }
                    if (position < 0 || position >= field.Length)
                    {
                        break;
                    }
                    if (field[position] == 0)
                    {
                        field[position] = 1;
                        break;
                    }
                }

            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
