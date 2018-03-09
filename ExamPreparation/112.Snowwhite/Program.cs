using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Snowwhite
{
    public class Dwarf
    {
        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Physics { get; set; }
        public string UniqueName { get; set; }

        public Dwarf(string name, string color, int physics)
        {
            this.Name = name;
            this.HatColor = color;
            this.Physics = physics;
            this.UniqueName = name + color;

        }
    }
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Dwarf> dwarfs = new Dictionary<string, Dwarf>();
            Dictionary<string, int> colors = new Dictionary<string, int>();

            while (input != "Once upon a time")
            {
                string[] dwarfData = input
                    .Split(new string[] {" <:> "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = dwarfData[0];
                string hatColor = dwarfData[1];
                int physics = int.Parse(dwarfData[2]);

                Dwarf currentDwarf = new Dwarf(name, hatColor, physics);

                if (!dwarfs.ContainsKey(currentDwarf.UniqueName))
                {
                    dwarfs.Add(currentDwarf.UniqueName, currentDwarf);

                    if (!colors.ContainsKey(hatColor))
                    {
                        colors.Add(hatColor, 0);
                    }
                    colors[hatColor]++;

                }
                else
                {
                    int power = dwarfs[currentDwarf.UniqueName].Physics;
                    if (power < physics)
                    {
                        dwarfs[currentDwarf.UniqueName].Physics = physics;
                    }
                }

                input = Console.ReadLine();
            }

            var sortedDwarfs = dwarfs.OrderByDescending(d => d.Value.Physics)
                .ThenByDescending(c => colors[c.Value.HatColor]);

            foreach (var dwarf in sortedDwarfs)
            {
                Console.WriteLine($"({dwarf.Value.HatColor}) {dwarf.Value.Name} <-> {dwarf.Value.Physics}");
            }
        }
    }
}
