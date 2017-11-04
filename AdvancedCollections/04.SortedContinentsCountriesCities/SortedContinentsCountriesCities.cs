using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SortedContinentsCountriesCities
{
    class SortedContinentsCountriesCities
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> geography 
                = new SortedDictionary<string,SortedDictionary<string,SortedSet<string>>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] geo = Console.ReadLine().Split(' ').ToArray();
                string continent = geo[0];
                string country = geo[1];
                string city = geo[2];
                if (!geography.ContainsKey(continent))
                {
                    geography.Add(continent, new SortedDictionary<string, SortedSet<string>>());
                }
                if (!geography[continent].ContainsKey(country))
                {
                    geography[continent].Add(country,new SortedSet<string>());
                }
                geography[continent][country].Add(city);
            }
            foreach (var continent in geography)
            {
                Console.WriteLine(continent.Key + ":");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
