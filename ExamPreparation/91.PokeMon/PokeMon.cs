using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _91.PokeMon
{
    class PokeMon
    {
        static void Main(string[] args)
        {
            int poketPower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustFactor = int.Parse(Console.ReadLine());
            int reachedTargets = 0;
            int halfPower = poketPower / 2;
            while (poketPower >= distance)
            {
                poketPower = poketPower - distance;
                reachedTargets++;
                if (poketPower == halfPower && poketPower !=0 && exhaustFactor !=0)
                {
                    poketPower = poketPower / exhaustFactor;
                }
            }
            Console.WriteLine(poketPower);
            Console.WriteLine(reachedTargets);
        }
    }
}
