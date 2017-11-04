using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FlattenDictionary
{
    class FlattenDictionary
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, string>> data = new Dictionary<string, Dictionary<string, string>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputTokens = input.Split(' ');
                if (inputTokens[0] == "flatten")
                {
                    string keyToFlatten = inputTokens[1];
                    data[keyToFlatten] =
                        data[keyToFlatten].ToDictionary(r => r.Key + r.Value, r => "flattened");
                }
                else
                {
                    if (!data.ContainsKey(inputTokens[0]))
                    {
                        data.Add(inputTokens[0], new Dictionary<string, string>());
                    }
                    data[inputTokens[0]][inputTokens[1]] = inputTokens[2];
                }

                input = Console.ReadLine();
            }

            var orderedData = data
                .OrderByDescending(r => r.Key.Length)
                .ToDictionary(r => r.Key, r => r.Value);

            foreach (var item in orderedData)
            {
                
                var dictionaryTemp = item.Value;
                var notflattenData = dictionaryTemp.Where(d => d.Value != "flattened").OrderBy(d => d.Key.Length);
                var flattenData = dictionaryTemp.Where(d => d.Value == "flattened");

                int count = 0;
                Console.WriteLine($"{item.Key}");
                foreach (var nf in notflattenData)
                {
                    count++;
                    Console.WriteLine($"{count}. {nf.Key} - {nf.Value}");
                }
                foreach (var fd in flattenData)
                {
                    count++;
                    Console.WriteLine($"{count}. {fd.Key}");
                }
            }
        }
    }
}
