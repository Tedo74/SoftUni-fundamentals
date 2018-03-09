using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _09.Snowballs
{
    public class Snowballs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger maxResult = 0;
            int snow = 0;
            int time = 0;
            int quality = 0;
            int[] max =new int[3];

            for (int i = 0; i < n; i++)
            {
                snow = int.Parse(Console.ReadLine());
                time = int.Parse(Console.ReadLine());
                quality = int.Parse(Console.ReadLine());
                if (time != 0)
                {
                    BigInteger result = BigInteger.Pow((snow / time), quality);
                    if (result > maxResult)
                    {
                        maxResult = result;
                        max[0] = snow;
                        max[1] = time;
                        max[2] = quality;
                    }
                }
            }

            Console.WriteLine($"{max[0]} : {max[1]} = {maxResult} ({max[2]})");
        }
    }
}
