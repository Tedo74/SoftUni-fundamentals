using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.SoftUniCoffeeOrders
{
    class SoftUniCoffeeOrders
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal totalPrice = 0;
            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                string dateRead = Console.ReadLine();
                DateTime date = DateTime.ParseExact(dateRead, "d/M/yyyy", CultureInfo.InvariantCulture);
                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                decimal count = decimal.Parse(Console.ReadLine());
                decimal price = daysInMonth * pricePerCapsule * count;
                Console.WriteLine($"The price for the coffee is: ${price:F2}");
                totalPrice += price;
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
