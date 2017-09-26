using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4.GroceryShop
{
    class GroceryShop
    {
        public static void Main()
        {
            Dictionary<string, double> products = new Dictionary<string, double>();
            string input = Console.ReadLine();
            while (input != "bill")
            {
                string pattern = @"\b([A-Z][a-z]*):(\d+\.\d{2}$)";
                Regex regeRege = new Regex(pattern);
                if (regeRege.IsMatch(input))
                {
                    Match validProduct = regeRege.Match(input);
                    string name = validProduct.Groups[1].Value;
                    double price = double.Parse(validProduct.Groups[2].Value);
                    products[name] = price;
                }
                input = Console.ReadLine();
            }
            foreach (var product in products.OrderByDescending(p => p.Value))
            {
                Console.WriteLine($"{product.Key} costs {product.Value:F2}");
            }
        }
    }
}
