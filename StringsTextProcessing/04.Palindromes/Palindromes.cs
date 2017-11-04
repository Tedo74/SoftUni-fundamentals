using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Palindromes
{
    class Palindromes
    {
        static void Main()
        {
            SortedSet<string> input = new SortedSet<string>(Console.ReadLine()
                .Split(new char[] { ' ', '!', '?', '.', ',' }, StringSplitOptions.RemoveEmptyEntries));
            List<string> result = new List<string>();
            foreach (var word in input)
            {
                if (isPalindrom(word))
                {
                    result.Add(word);
                }
            }
            Console.WriteLine(string.Join(", ", result));
        }

        static bool isPalindrom(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
