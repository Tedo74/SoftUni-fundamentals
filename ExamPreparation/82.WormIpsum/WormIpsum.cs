using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _82.WormIpsum
{
    class WormIpsum
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex isValidSentence = new Regex(@"^[A-Z]+([^\.])*\.$");
            while (input != "Worm Ipsum")
            {
                if (isValidSentence.IsMatch(input))
                {
                    string sentece = WormSentence(input);
                    Console.WriteLine(sentece);
                }
                input = Console.ReadLine();
            }
        }

        private static string WormSentence(string input)
        {
            string[] wordsInSentence = input.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < wordsInSentence.Length; i++)
            {
                string word = wordsInSentence[i];
                string tempWord = new string(word.ToCharArray().Distinct().ToArray());
                if (word != tempWord)
                {
                    Dictionary<char, int> wordChars = new Dictionary<char, int>();
                    foreach (char c in word)
                    {
                        if (!wordChars.ContainsKey(c))
                        {
                            wordChars.Add(c, 0);
                        }
                        wordChars[c] += 1;
                    }
                    char max = wordChars.OrderByDescending(c => c.Value).First().Key;
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < word.Length; j++)
                    {
                        if (!char.IsPunctuation(word[j]))
                        {
                            sb.Append(max);
                        }
                        else
                        {
                            sb.Append(word[j]);
                        }
                    }
                    wordsInSentence[i] = sb.ToString();
                }
            }
            return string.Join(" ", wordsInSentence);
        }
    }
}
