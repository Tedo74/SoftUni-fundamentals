using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SalesReport
{
    class SalesReport
    {
        static void Main()
        {
            List<Sale> sales = new List<Sale>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                sales.Add(new Sale(Console.ReadLine()));
            }
            List<string> towns = sales.Select(s => s.Town).Distinct().OrderBy(t => t).ToList();
            foreach (var town in towns)
            {
                double currentSum = sales.Where(s => s.Town == town).Select(s => s.Price * s.Quantity).Sum();
                Console.WriteLine($"{town} -> {currentSum:F2}");
            }
        }
    }

    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }

        public Sale(string s)
        {
            string[] input = s.Split(' ');
            this.Town = input[0];
            this.Product = input[1];
            this.Price = double.Parse(input[2]);
            this.Quantity = double.Parse(input[3]);
        }
    }
}
