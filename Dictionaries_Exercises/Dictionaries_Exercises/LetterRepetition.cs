using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries_Exercises
{
    class LetterRepetition
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Dictionary<char, int> letter = new Dictionary<char, int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (!letter.ContainsKey(word[i]))
                {
                    letter.Add(word[i],1);
                }
                else
                {
                    letter[word[i]]++;
                }
            }
            foreach (char item in letter.Keys)
            {
                Console.WriteLine($"{item} -> {letter[item]}");
            }
        }
    }
}
