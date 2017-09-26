using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Hornet_Assault
{
    class HornetAssault
    {
        public static void Main()
        {
            List<long> beehives = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            List<long> hornets = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

            for (int i = 0; i < beehives.Count; i++)
            {
                if (!hornets.Any())
                {
                    break;
                }
                long hornetsPower = hornets.Sum();

                if (hornetsPower > beehives[i])
                {
                    beehives.RemoveAt(i);
                    i--;
                }
                else if (hornetsPower < beehives[i])
                {
                    beehives[i] = beehives[i] - hornetsPower;
                    hornets.RemoveAt(0);
                }
                else // hornets equals bees
                {
                    hornets.RemoveAt(0);
                    beehives.RemoveAt(i);
                    i--;
                }
            }
            if (beehives.Any())
            {
                Console.WriteLine(string.Join(" ", beehives));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}
