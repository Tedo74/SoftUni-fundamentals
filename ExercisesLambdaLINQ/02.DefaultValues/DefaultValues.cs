using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DefaultValues
{
    class DefaultValues
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "end")
                {
                    break;
                }
                data[input[0]] = input[1];
            }
            string defaultValue = Console.ReadLine();

            var nonReplacedData = data.Where(n => n.Value != "null").ToDictionary(n => n.Key, n => n.Value);

            var replacedData = data.Where(n => n.Value == "null")
                .Select(n => new KeyValuePair<string, string>(n.Key, defaultValue))
                .ToDictionary(n => n.Key, n => n.Value);

            foreach (var d in nonReplacedData.OrderByDescending(n => n.Value.Length))
            {
                Console.WriteLine($"{d.Key} <-> {d.Value}");
            }
            foreach (var d in replacedData)
            {
                Console.WriteLine($"{d.Key} <-> {d.Value}");
            }
        }
    }
}
