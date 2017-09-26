using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.HornetComm
{
    class HornetComm
    {
        public static void Main()
        {
            List<string> privates = new List<string>();
            List<string> broadcasts = new List<string>();
            string privatePattern = @"^(?<code>[0-9]+) \<\-\> (?<message>[A-Za-z0-9]+)$";
            Regex privateMessage = new Regex(privatePattern);
            string broadcastPattern = @"^(?<message>[^0-9]+) \<\-\> (?<freq>[A-Za-z0-9]+)$";
            Regex broadcast = new Regex(broadcastPattern);

            string input = Console.ReadLine();
            while (input != "Hornet is Green")
            {
                if (privateMessage.IsMatch(input))
                {
                    Match privateMatch = privateMessage.Match(input);
                    char[] code = privateMatch.Groups["code"].Value.ToCharArray();
                    string reversedCode = new string(code.Reverse().ToArray());
                    string message = privateMatch.Groups["message"].Value;
                    privates.Add(string.Format($"{reversedCode} -> {message}"));
                }
                if (broadcast.IsMatch(input))
                {
                    Match broadcastMatch = broadcast.Match(input);
                    string message = broadcastMatch.Groups["message"].Value;
                    string freq = broadcastMatch.Groups["freq"].Value;
                    freq = SwapUpperLowerLetters(freq);
                    broadcasts.Add(string.Format($"{freq} -> {message}"));
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Broadcasts:");
            if (!broadcasts.Any())
            {
                Console.WriteLine("None"); 
            }
            else
            {
                foreach (var b in broadcasts)
                {
                    Console.WriteLine(b);
                }
            }
            Console.WriteLine("Messages:");
            if (!privates.Any())
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var p in privates)
                {
                    Console.WriteLine(p);
                }
            }
        }

        static string SwapUpperLowerLetters(string s)
        {
            StringBuilder reversed = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLower(s[i]))
                {
                     char c = char.ToUpper(s[i]);
                    reversed.Append(c);
                }
                else if (char.IsUpper(s[i]))
                {
                    char c = char.ToLower(s[i]);
                    reversed.Append(c);
                }
                else
                {
                    reversed.Append(s[i]);
                }
            }
            return reversed.ToString();
        }
    }
}
