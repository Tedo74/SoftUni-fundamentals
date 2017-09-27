using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _74.Nsa
{
    class Nsa
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> spyesByCountries = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "quit")
                {
                 break;   
                }
                string[] spyData = input.Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                string country = spyData[0];
                string name = spyData[1];
                int days = int.Parse(spyData[2]);

                if (!country.All(char.IsLetterOrDigit) || ! name.All(char.IsLetterOrDigit))
                {
                    continue;
                }
                if (!spyesByCountries.ContainsKey(country))
                {
                   spyesByCountries.Add(country, new Dictionary<string, int>()); 
                }
                if (!spyesByCountries[country].ContainsKey(name))
                {
                    spyesByCountries[country].Add(name, 0);
                }
                spyesByCountries[country][name] = days;
            }
            var orderedSpies = spyesByCountries.OrderByDescending(s => s.Value.Count);
            foreach (var s in orderedSpies)
            {
                Console.WriteLine($"Country: {s.Key}");
                foreach (var spy in s.Value.OrderByDescending(spy => spy.Value))
                {
                    Console.WriteLine($"**{spy.Key} : {spy.Value}");
                }
            }
        }
    }
}
