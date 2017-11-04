using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MostValuedCustomer
{
    class MostValuedCustomer
    {
        static void Main()
        {
            Dictionary<string,double> products = new Dictionary<string, double>();
            Dictionary<string,List<String>> customersAndTheirProducts = new Dictionary<string, List<string>>();
            Dictionary<string, double> customerSpendedMoneyTotal = new Dictionary<string, double>();
            string input = Console.ReadLine();
            while (input != "Shop is open")
            {
                string[] inputTokens = input.Split(' ');
                string productName = inputTokens[0];
                double price = double.Parse(inputTokens[1]);
                products[productName] = price;
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "Print")
            {
                if (input == "Discount")
                {
                    var productsDiscounted = products.OrderByDescending(p => p.Value).Take(3)
                        .ToDictionary(p => p.Key, p => p.Value * 0.9);
                    foreach (var p in productsDiscounted)
                    {
                        products[p.Key] = p.Value;
                    }
                }
                else
                {
                    string[] inputTokens = input.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                    string custumerName = inputTokens[0];
                    List<string> productsToBuy = inputTokens[1]
                        .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (!customersAndTheirProducts.ContainsKey(custumerName))
                    {
                        customersAndTheirProducts.Add(custumerName, new List<string>());
                    }
                    if (!customerSpendedMoneyTotal.ContainsKey(custumerName))
                    {
                        customerSpendedMoneyTotal.Add(custumerName, 0.0);
                    }
                    foreach (var p in productsToBuy)
                    {
                        customersAndTheirProducts[custumerName].Add(p);
                        customerSpendedMoneyTotal[custumerName] += products[p];
                    }
                }
                
                input = Console.ReadLine();
            }
            string first= customerSpendedMoneyTotal.OrderByDescending(x => x.Value).First().Key;
            Console.WriteLine($"Biggest spender: {first}");
            Console.WriteLine("^Products bought:");
            List<string> productsOfFirst = customersAndTheirProducts[first];
            double sum = 0.0;
            var sortedProducts = products.OrderByDescending(x => x.Value);
            foreach (var p in sortedProducts)
            {
                if (productsOfFirst.Contains(p.Key))
                {
                    Console.WriteLine($"^^^{p.Key}: {products[p.Key]:F2}");
                }
                foreach (var pf in productsOfFirst)
                {
                    if (pf == p.Key)
                    {
                        sum += products[p.Key];
                    }
                }
            }
            Console.WriteLine($"Total: {sum:F2}");
        }
    }
}
