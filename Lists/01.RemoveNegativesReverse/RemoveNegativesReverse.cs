using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RemoveNegativesReverse
{
    public class RemoveNegativesReverse
    {
        public static void Main()
        {
            List<int> positiveNumbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n >= 0)
                .Reverse()
                .ToList();
            if (!positiveNumbers.Any())
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", positiveNumbers));
            }
        }
    }
}
