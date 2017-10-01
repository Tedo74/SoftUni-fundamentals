using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _93.Regexmon
{
    class Regexmon
    {
        static void Main(string[] args)
        {
            List<string> matches = new List<string>();
            string bojomonPattern = @"[A-za-z]+-[A-Za-z]+";
            Regex bojomonRegex = new Regex(bojomonPattern);
            string didimonPattern = @"[^A-Za-z\-]+";
            Regex didimonRegex = new Regex(didimonPattern);
            string input = Console.ReadLine();
            int count = 1;
            while (input.Any())
            {
                if (count % 2 != 0 && didimonRegex.IsMatch(input))
                {
                    Match didimon = didimonRegex.Match(input);
                    matches.Add(didimon.Value);
                    int index = didimon.Index;
                    int length = didimon.Value.Length;
                    int cutInput = index + length;
                    input = input.Remove(0, cutInput);
                    count++;
                }
                else
                {
                    break;
                }
                if (count % 2 == 0 && bojomonRegex.IsMatch(input))
                {
                    Match bojomon = bojomonRegex.Match(input);
                    matches.Add(bojomon.Value);
                    int index = bojomon.Index;
                    int length = bojomon.Value.Length;
                    int cutInput = index + length;
                    input = input.Remove(0, cutInput);
                    count++;
                }
                else
                {
                    break;
                }
            }
            foreach (string result in matches)
            {
                Console.WriteLine(result);
            }
        }
    }
}
