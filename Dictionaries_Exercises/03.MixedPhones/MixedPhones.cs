using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MixedPhones
{
    class MixedPhones
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, long> phones = new SortedDictionary<string, long>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(new char[] {' ', ':'}, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Over")
                {
                    break;
                }
                if (isDigit(input[1]))
                {
                    phones[input[0]] = long.Parse(input[1]);
                }
                else
                {
                    phones[input[1]] = long.Parse(input[0]);
                }
            }
            foreach (KeyValuePair<string, long> item in phones)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

        static bool isDigit(string s)
        {
            long number;
            if (long.TryParse(s,out number))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
