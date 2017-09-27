using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _34.CubicsMessages
{
    class CubicsMessages
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int messageLength = int.Parse(Console.ReadLine());
            
            while (input != "Over!")
            {
                string pattern = @"^(?<digitsBefore>\d+)(?<message>[a-zA-Z]{"+ messageLength +"})(?<postMessage>[^A-Za-z]+)?$";
                Regex readMessage = new Regex(pattern);
                if (!readMessage.IsMatch(input))
                {
                    input = Console.ReadLine();
                    if (input != "Over!")
                    {
                        messageLength = int.Parse(Console.ReadLine());
                    }
                    continue;
                }
                Match m = readMessage.Match(input);
                List<int> digits = m.Groups["digitsBefore"].Value.Select(n => int.Parse(n.ToString())).ToList();
                string message = m.Groups["message"].Value;
                string messageAfther = m.Groups["postMessage"].Value;

                if (messageAfther!= string.Empty && messageAfther.Any(n => char.IsDigit(n)))
                {
                    digits.AddRange(messageAfther.Where(n => char.IsDigit(n)).Select(n => int.Parse(n.ToString())).ToList());
                }
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < digits.Count; i++)
                {
                    int index = digits[i];
                    if (index >= 0 && index < message.Length)
                    {
                        sb.Append(message[index]);
                    }
                    else
                    {
                        sb.Append(' ');
                    }
                }
                Console.WriteLine($"{message} == {sb}");

                input = Console.ReadLine();
                if (input !="Over!")
                {
                    messageLength = int.Parse(Console.ReadLine());
                }
            }
        }
    }
}
