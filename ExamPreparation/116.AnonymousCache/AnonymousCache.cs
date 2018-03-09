using System;
using System.Collections.Generic;
using System.Linq;

namespace _16.AnonymousCache
{
    public class AnonymousCache
    {
        public static void Main()
        {
            var hackersData = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();

            while (input != "thetinggoesskrra")
            {
                string[] data = input.Split(" ->|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (data.Length > 1)
                {
                    string dataKey = data[0];
                    long dataValue = long.Parse(data[1]);
                    string dataSet = data[2];

                    if (!hackersData.ContainsKey(dataSet))
                    {
                        hackersData.Add(dataSet, new Dictionary<string, long>());
                    }

                    hackersData[dataSet][dataKey] = dataValue;
                }

                input = Console.ReadLine();
            }

            if (hackersData.Count > 1)
            {
                var sortedDataWithMaxValue = hackersData.OrderByDescending(x => x.Value.Sum(v => v.Value)).First();
                Console.WriteLine($"Data Set: {sortedDataWithMaxValue.Key}, Total Size: {sortedDataWithMaxValue.Value.Sum(d => d.Value)}");

                foreach (var innerData in sortedDataWithMaxValue.Value)
                {
                    Console.WriteLine($"$.{innerData.Key}");
                }
            }
        }
    }
}
