using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _52.SoftUniKaraoke
{
    class SoftUniKaraoke
    {
        static void Main(string[] args)
        {
            List<string> participiants = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();

            List<string> songs = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();

            Dictionary<string, HashSet<string>> awarded = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "dawn")
                {
                    break;
                }
                string[] stage = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string name = stage[0].Trim();
                string song = stage[1].Trim();
                string award = stage[2].Trim();
                if (participiants.Contains(name) && songs.Contains(song))
                {
                    if (!awarded.ContainsKey(name))
                    {
                        awarded.Add(name, new HashSet<string>());
                    }
                    awarded[name].Add(award);
                }
            }
            if (awarded.Count == 0)
            {
                Console.WriteLine($"No awards");
                return;
            }
            var orderedParticipiants = awarded.OrderByDescending(awards => awards.Value.Count).ThenBy(name => name.Key);
            foreach (var singer in orderedParticipiants)
            {
                Console.WriteLine($"{singer.Key}: {singer.Value.Count} awards");
                List < string > awards= singer.Value.OrderBy(name => name).ToList();
                foreach (string awardName in awards)
                {
                    Console.WriteLine($"--{awardName}");
                }
            }
        }
    }
}
