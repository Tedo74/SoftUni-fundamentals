using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.LambadaExpressions
{
    class LambadaExpressions
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, string>> lambadas = new Dictionary<string, Dictionary<string, string>>();
            string input = Console.ReadLine();
            while (input != "lambada")
            {
                if (input == "dance")
                {
                    lambadas = lambadas.ToDictionary(x => x.Key,
                        x => x.Value.ToDictionary(zx => x.Key, zx => zx.Key + "." + zx.Value));

                }
                else
                {
                    string[] inputTokens = input.Split(new string[] { " => ", "." }, StringSplitOptions.RemoveEmptyEntries);
                    string selector = inputTokens[0];
                    string selectorObj = inputTokens[1];
                    string property = inputTokens[2];
                    if (!lambadas.ContainsKey(selector))
                    {
                        lambadas.Add(selector, new Dictionary<string, string>());
                    }
                    lambadas[selector][selectorObj] = property;
                }

                input = Console.ReadLine();
            }
            foreach (var l in lambadas)
            {
                foreach (var l2 in l.Value)
                {
                    Console.WriteLine($"{l.Key} => {l2.Key}.{l2.Value}");

                }
            }
        }
    }
}
