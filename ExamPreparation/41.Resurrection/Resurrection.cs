using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _41.Resurrection
{
    class Resurrection
    {
        static void Main(string[] args)
        {
            int numberOfPhoenixes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPhoenixes; i++)
            {
                long length = long.Parse(Console.ReadLine());
                decimal bodyWidth = decimal.Parse(Console.ReadLine());
                decimal wingLength = decimal.Parse(Console.ReadLine());
                Console.WriteLine(GetYears(length, bodyWidth, wingLength));
            }
        }
        public static decimal GetYears(long length, decimal width, decimal wingLength)
        {
            decimal years = (decimal)(length * length) * (width + (2 * wingLength));
            return years;
        }
    }
}
