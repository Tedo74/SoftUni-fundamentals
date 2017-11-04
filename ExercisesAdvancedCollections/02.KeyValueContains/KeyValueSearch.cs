using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.KeyValueContains
{
    class KeyValueSearch
    {
        static void Main(string[] args)
        {
            string keyToSearch = Console.ReadLine();
            string valToSearch = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,List<string>> keysAndValues = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] keyValue = Console.ReadLine().Split(new string[]{ " => " }, StringSplitOptions.RemoveEmptyEntries);
                string key = keyValue[0];
                List<string> values = keyValue[1].Split(';').ToList();
                keysAndValues.Add(key,values);
            }
            foreach (var data in keysAndValues)
            {
                if (data.Key.Contains(keyToSearch))
                {
                    Console.WriteLine($"{data.Key}:");
                    foreach (string s in data.Value)
                    {
                        if (s.Contains(valToSearch))
                        {
                            Console.WriteLine($"-{s}");
                        }
                    }
                }
            }
        }
    }
}
