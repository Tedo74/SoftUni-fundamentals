using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DeserializeString
{
    class DeserializeString
    {
        static void Main()
        {
            SortedDictionary<int, char> wordChars = new SortedDictionary<int, char>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split(':');
                char @char = tokens[0].First();
                int[] indexes = tokens[1].Split('/').Select(n => int.Parse(n)).ToArray();
                foreach (var i in indexes)
                {
                    wordChars.Add(i, @char);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(wordChars.Values.ToArray());
        }
    }
}
