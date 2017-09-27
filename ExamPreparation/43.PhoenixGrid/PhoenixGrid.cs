using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _43.PhoenixGrid
{
    class PhoenixGrid
    {
        static void Main(string[] args)
        {
            string pattern = @"^([^\s_]{3})((\.)[^\s_]{3})*$";
            Regex phoenix = new Regex(pattern);
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "ReadMe")
                {
                    break;
                }
                if (!phoenix.IsMatch(input))
                {
                    Console.WriteLine("NO");
                    continue;
                }
                else
                {
                    Match m = phoenix.Match(input);
                    string read = m.Value;
                    IsPalindrome(read);
                }
            }
        }

        private static void IsPalindrome(string read)
        {
            bool isPalindrome = true;
            for (int i = 0; i < read.Length / 2; i++)
            {
                if (read[i] != read[read.Length -1 -i])
                {
                    isPalindrome = false;
                    break;
                }
            }
            if (isPalindrome)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
