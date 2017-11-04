using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CitiesByContinentCountry
{
    class ContinetsCountriesCities
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,List<string>>> geography = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] geo = Console.ReadLine().Split(' ').ToArray();
                string continent = geo[0];
                string country = geo[1];
                string city = geo[2];
                if (!geography.ContainsKey(continent))
                {
                    geography.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!geography[continent].ContainsKey(country))
                {
                    geography[continent].Add(country, new List<string>());
                }
                geography[continent][country].Add(city);
            }
            foreach (var continent in geography)
            {
                Console.WriteLine(continent.Key+":");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ",country.Value)}");
                }
            }
        }
    }
}
