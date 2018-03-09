using System;
using System.Numerics;

namespace _13.AnonymousDownsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int sitesDown = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());
            decimal totalLoss = 0m;

            for (int i = 0; i < sitesDown; i++)
            {
                string[] sitesData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string siteName = sitesData[0];
                decimal sitesVisited = decimal.Parse(sitesData[1]);
                decimal pricePerVisit = decimal.Parse(sitesData[2]);
                decimal currentLoss = pricePerVisit * sitesVisited;
                totalLoss += currentLoss;

                Console.WriteLine(siteName);

            }

            Console.WriteLine($"Total Loss: {totalLoss:F20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(securityKey, sitesDown)}");
        }
    }
}
