using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    class ShoppingSpree
    {
        static void Main()
        {
            Dictionary<string,double> products = new Dictionary<string, double>();
            double budget = double.Parse(Console.ReadLine());
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input[0] == "end")
                {
                    break;
                }
                string product = input[0];
                double price = double.Parse(input[1]);
                if (!products.ContainsKey(product))
                {
                    products.Add(product, price);
                }
                else
                {
                    if (price < products[product])
                    {
                        products[product] = price;
                    }
                }
            }
            double sumOfAllProducts = products.Sum(s => s.Value);
            if (sumOfAllProducts > budget)
            {
                Console.WriteLine("Need more money... Just buy banichka");
            }
            else
            {
                foreach (var p in products.OrderByDescending(p => p.Value).ThenBy(name => name.Key.Length))
                {
                    Console.WriteLine("{0} costs {1:F2}",p.Key,p.Value);
                }
            }
        }
    }
}
