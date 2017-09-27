using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _83.Wormhole
{
    class Wormhole
    {
        static void Main(string[] args)
        {
            int[] space = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int count = 0;
            int steps = 0;
            while (true)
            {
                if (space[count] == 0)
                {
                    count++;
                    steps++;
                }
                else
                {
                    int temp = count;
                    count = space[count];
                    space[temp] = 0;
                }
                if (count > space.Length -1)
                {
                   break; 
                }
            }
            Console.WriteLine(steps);
        }
    }
}
