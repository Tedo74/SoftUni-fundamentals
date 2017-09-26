using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.BoomingCannon
{
    class BoomingCannon
    {
        public static void Main()
        {
            List<string> result = new List<string>();
            int[] shootParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int distance = shootParameters[0];
            int countToDestroy = shootParameters[1];
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"(?<=\\<<<)\w+");
            MatchCollection targets = pattern.Matches(input);
            foreach (Match t in targets)
            {
                string target = new string(t.Value.Skip(distance).Take(countToDestroy).ToArray());
                if (target == String.Empty)
                {
                    continue;
                }
                result.Add(target);
            }
            Console.WriteLine(string.Join(@"/\",result));
        }
    }
}
