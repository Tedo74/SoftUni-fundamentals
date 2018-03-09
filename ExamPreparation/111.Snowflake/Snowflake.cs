using System;
using System.Text.RegularExpressions;

namespace _11.Snowflake
{
    public class Snowflake
    {
        public static void Main()
        {
            string surfacepattern = @"^[^A-Za-z0-9]+$";
            string mantlePattern = @"^[0-9_]+$";
            string allPattern = @"^[^A-Za-z0-9]+[0-9_]+(?<core>[A-Za-z]+)[0-9_]+[^A-Za-z0-9]+$";

            string surface = Console.ReadLine();
            string mantle = Console.ReadLine();
            string all = Console.ReadLine();
            string mantle2 = Console.ReadLine();
            string surface2 = Console.ReadLine();
            
            Regex surfaceRegex = new Regex(surfacepattern);
            if (!surfaceRegex.IsMatch(surface) || !surfaceRegex.IsMatch(surface2))
            {
                Console.WriteLine("Invalid");
                return;
            }
            Regex mantleRegex = new Regex(mantlePattern);
            if (!mantleRegex.IsMatch(mantle) || !mantleRegex.IsMatch(mantle2))
            {
                Console.WriteLine("Invalid");
                return;
            }
            Regex allRegex = new Regex(allPattern);
            if (!allRegex.IsMatch(all))
            {
                Console.WriteLine("Invalid");
                return;
            }
            else
            {
                Match result = allRegex.Match(all);
                Console.WriteLine("Valid");
                Console.WriteLine(result.Groups["core"].Value.Length);
            }
        }
    }
}
