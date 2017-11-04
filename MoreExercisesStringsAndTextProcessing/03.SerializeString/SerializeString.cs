using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SerializeString
{
    class SerializeString
    {
        static void Main()
        {
            Dictionary<char,List<int>> serialized = new Dictionary<char, List<int>>();
            string word = Console.ReadLine();
            for (int i = 0; i < word.Length; i++)
            {
                if (!serialized.ContainsKey(word[i]))
                {
                   serialized.Add(word[i], new List<int>()); 
                }
                serialized[word[i]].Add(i);
            }
            foreach (var c in serialized)
            {
                List<int> indexes = c.Value;
                Console.WriteLine($"{c.Key}:{string.Join("/", indexes)}");
            }
        }
    }
}
