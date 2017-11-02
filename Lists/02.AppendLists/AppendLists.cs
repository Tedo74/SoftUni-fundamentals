using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AppendLists
{
    public class AppendLists
    {
        public static void Main()
        {
            List<List<int>> all = new List<List<int>>();
            List<string> input = Console.ReadLine()
                .Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            for (int i = 0; i < input.Count; i++)
            {
                all.Add(input[i].Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList());
            }
            all.Reverse();
            List<int> result = new List<int>();
            for (int i = 0; i < all.Count; i++)
            {
                result = result.Concat(all[i]).ToList();
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
