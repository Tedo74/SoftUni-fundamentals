using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DiamondProblem
{
    class DiamondProblem
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int diamondStartIndex = -1;
            int diamondEndIndex;
            bool isFound = false;
            while ((diamondStartIndex = input.IndexOf('<', diamondStartIndex + 1)) > -1
                && (diamondEndIndex = input.IndexOf('>', diamondStartIndex + 1)) > -1)
            {
                string diamond = input.Substring(diamondStartIndex + 1, diamondEndIndex - diamondStartIndex - 1);
                isFound = true;
                int carats = GetCarats(diamond);
                Console.WriteLine($"Found {carats} carat diamond");
            }
            if (!isFound)
            {
                Console.WriteLine("Better luck next time");
            }
        }

        private static int GetCarats(string diamond)
        {
            int sum = 0;
            foreach (var letter in diamond)
            {
                if (char.IsDigit(letter))
                {
                    sum += int.Parse(letter.ToString());
                }
            }
            return sum;
        }
    }
}
