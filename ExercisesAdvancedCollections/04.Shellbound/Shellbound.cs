using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Shellbound
{
    class Shellbound
    {
        static void Main(string[] args)
        {
            Dictionary<string,HashSet<int>> allShells = new Dictionary<string, HashSet<int>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');
                if (input[0] == "Aggregate")
                {
                    break;
                }
                string region = input[0];
                int shellSize = int.Parse(input[1]);
                if (!allShells.ContainsKey(region))
                {
                    allShells.Add(region, new HashSet<int>());
                }
                allShells[region].Add(shellSize);
            }
            foreach (var region in allShells)
            {
                int sum = region.Value.Sum();
                int average = sum - (int)(sum / region.Value.Count);
                Console.WriteLine($"{region.Key} -> {string.Join(", ", region.Value)} ({average})");
            }
        }
    }
}
