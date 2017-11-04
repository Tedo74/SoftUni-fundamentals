using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Camping
{
    class Camping
    {
        static void Main()
        {
            Dictionary<string,Dictionary<string,int>> campers = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputTokens = input.Split(' ');
                string name = inputTokens[0];
                string camper = inputTokens[1];
                int nights = int.Parse(inputTokens[2]);
                if (!campers.ContainsKey(name))
                {
                    campers.Add(name, new Dictionary<string, int>());
                }
                campers[name][camper] = nights;
                input = Console.ReadLine();
            }
            var orderdCampers = campers.OrderByDescending(x => x.Value.Count).ThenBy(k=>k.Key.Length);
            foreach (var o in orderdCampers)
            {
                var campDict = o.Value;
                Console.WriteLine($"{o.Key}: {campDict.Count}");
                foreach (var camps in campDict)
                {
                    Console.WriteLine($"***{camps.Key}");
                }
                Console.WriteLine($"Total stay: {campDict.Sum(x => x.Value)} nights");
            }
        }
    }
}
