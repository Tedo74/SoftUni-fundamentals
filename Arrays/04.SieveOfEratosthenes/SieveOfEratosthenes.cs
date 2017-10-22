using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SieveOfEratosthenes
{
    public class SieveOfEratosthenes
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool[] primes = new bool[n + 1].Select(b => b = true).ToArray();
            primes[0] = false;
            primes[1] = false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (primes[i])
                {
                    for (int j = i * i; j < primes.Length; j+= i)
                    {
                        primes[j] = false;
                    }
                }
            }
            List<int> result = new List<int>();
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
