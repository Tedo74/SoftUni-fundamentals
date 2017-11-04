using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.LINQuistics
{
    class LINQuistics
    {
        static void Main()
        {
            Dictionary<string, List<string>> collections = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "exit")
            {
                string[] inputTokens = input.Split(new char[] { '.', '(', ')' },
                    StringSplitOptions.RemoveEmptyEntries);
                int number;
                if (inputTokens.Length > 1)
                {
                    string collection = inputTokens[0];
                    List<string> methods = inputTokens.Skip(1).ToList();
                    if (!collections.ContainsKey(collection))
                    {
                        collections.Add(collection, new List<string>());
                    }
                    foreach (var m in methods)
                    {
                        string method = m;
                        if (method[method.Length - 2] == '(' && method[method.Length - 1] == ')')
                        {
                            method = method.Remove(method.Length - 2);
                        }
                        if (!collections[collection].Contains(method))
                        {
                            collections[collection].Add(method);
                        }
                    }
                }
                else if (int.TryParse(inputTokens[0], out number))
                {
                    if (collections.Count > 0)
                    {
                        var mostMethods = collections.OrderByDescending(m => m.Value.Count).First();
                        var toPrint = mostMethods.Value.OrderBy(m => m.Length).Take(number);
                        foreach (var print in toPrint.OrderBy(l => l.Length))
                        {
                            Console.WriteLine($"* {print}");
                        }
                    }
                }
                else
                {
                    if (collections.ContainsKey(inputTokens[0]))
                    {
                        var orderedMethods = collections[inputTokens[0]].OrderByDescending(m => m.Length).
                            ThenByDescending(m => m.Distinct().Count()).Distinct();
                        foreach (var om in orderedMethods)
                        {
                            Console.WriteLine($"* {om}");
                        }
                    }
                }

                input = Console.ReadLine();
            }
            string[] endInput = Console.ReadLine().Split(' ').ToArray();
            string methodSearch = endInput[0];
            string where = endInput[1];

            var allToPrint = collections.Where(l => l.Value.Contains(methodSearch)).
                OrderByDescending(l => l.Value.Count).
                ThenByDescending(d => d.Value.OrderBy(m => m.Length).First().Length);

            foreach (var c in allToPrint)
            {
                Console.WriteLine(c.Key);
                if (where == "all")
                {
                    var orderedMethods = c.Value.OrderByDescending(m => m.Length);
                    foreach (var m in orderedMethods)
                    {
                        Console.WriteLine($"* {m}");
                    }
                }
            }
        }
    }
}
