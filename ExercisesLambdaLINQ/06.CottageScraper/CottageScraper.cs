using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CottageScraper
{
    class CottageScraper
    {
        static void Main()
        {
            List<KeyValuePair<string, int>> woods = new List<KeyValuePair<string, int>>();
            string input = Console.ReadLine();
            while (input != "chop chop")
            {
                string[] inputTokens = input.Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                string wood = inputTokens[0];
                int height = int.Parse(inputTokens[1]);
                woods.Add(new KeyValuePair<string, int>(wood,height));
                input = Console.ReadLine();
            }
            string wantedWood = Console.ReadLine();
            int minHeight = int.Parse(Console.ReadLine());
            double pricePerMeterTree = Math.Round(woods.Average(w => w.Value), 2);
            double usedTreesSum = woods.Where(w => w.Key == wantedWood && w.Value >= minHeight).Sum(w => w.Value);
            double unusedTreesSum = woods.Where(w => w.Key != wantedWood || w.Value < minHeight).Sum(w => w.Value);
            double priceUsed = Math.Round(usedTreesSum * pricePerMeterTree, 2);
            double priceUnused = Math.Round(unusedTreesSum * pricePerMeterTree * 0.25, 2);
            double totalPrice = Math.Round(priceUnused + priceUsed, 2);

            Console.WriteLine("Price per meter: ${0:F2}", pricePerMeterTree);
            Console.WriteLine("Used logs price: ${0:F2}", priceUsed);
            Console.WriteLine("Unused logs price: ${0:F2}", priceUnused);
            Console.WriteLine("CottageScraper subtotal: ${0:F2}", totalPrice);
        }
    }
}
