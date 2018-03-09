using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Exam4
{
    class StarEnigma
    {
        static void Main(string[] args)
        {
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            int n = int.Parse(Console.ReadLine());
            string keyPattern = @"[starSTAR]";
            Regex keyRegex = new Regex(keyPattern);
            string messagePattern = @"(@[A-Za-z]+)[^@\-!:>]*(:[0-9]+)[^@\-!:>]*!([AD])![^@\-!:>]*->([0-9]+)";
            Regex messageRegex = new Regex(messagePattern);

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                if (!keyRegex.IsMatch(keyPattern))
                {
                    continue;
                }
                int key = keyRegex.Matches(message).Count;
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < message.Length; j++)
                {
                    sb.Append((char)(message[j] - key));
                }

                string newMesage = sb.ToString();
                
                MatchCollection m = messageRegex.Matches(newMesage);
                foreach (Match match in m)
                {
                    string planet = match.Groups[1].Value.Remove(0,1);
                   // string population = match.Groups[2].Value.Remove(0, 1);
                    string attackOrDistroy = match.Groups[3].Value;
                    if (attackOrDistroy == "A")
                    {
                        attacked.Add(planet);
                    }
                    else if(attackOrDistroy == "D")
                    {
                        destroyed.Add(planet);
                    }
                    //string soliders = match.Groups[4].Value;
                }
            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var planet in attacked.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (var planet in destroyed.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
