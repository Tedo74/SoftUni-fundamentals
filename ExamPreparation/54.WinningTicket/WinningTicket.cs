using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _54.WinningTicket
{
    class WinningTicket
    {
        static void Main(string[] args)
        {
            string[] tikets = Console.ReadLine().Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Trim()).ToArray();
            if (tikets.Any())
            {
                foreach (var t in tikets)
                {
                    if (!IsValid(t))
                    {
                        Console.WriteLine("invalid ticket");
                        continue;
                    }
                    CheckTicket(t);
                }
            }
        }

        static bool IsValid(string ticket)
        {
            if (ticket.Length != 20)
            {
                return false;
            }
            return true;
        }

        static void CheckTicket(string ticket)
        {
            Regex ticketRegex = new Regex(@"([$@#^])\1{5,}");
            string leftPart = ticket.Substring(0, ticket.Length / 2);
            string rightPart = ticket.Substring(ticket.Length / 2 );
            Match left = ticketRegex.Match(leftPart);
            Match right = ticketRegex.Match(rightPart);
            if (left.Success && right.Success)
            {
                if (left.Value[0] == right.Value[0])
                {
                    int winLength = Math.Min(left.Length, right.Length);
                    char symb = left.Value[0];
                    if (winLength == 10)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {winLength}{symb} Jackpot!");
                        return;
                    }
                    if (winLength >5 && winLength < 10)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {winLength}{symb}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"ticket \"{ticket}\" - no match");
            }
        }
    }
}
