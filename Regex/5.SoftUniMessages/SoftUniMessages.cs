using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _5.SoftUniMessages
{
    class SoftUniMessages
    {
        public static void Main()
        {
            string pattern = @"^\d+(?<message>[A-Za-z]+)[^A-Za-z]+$";
            Regex validMessage = new Regex(pattern);

            string input = Console.ReadLine();
            while (input != "Decrypt!")
            {
                int validLength = int.Parse(Console.ReadLine());
                if (validMessage.IsMatch(input))
                {
                    Match allMessage = validMessage.Match(input);
                    string textMessage = allMessage.Groups["message"].Value;
                    if (textMessage.Length == validLength)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (char.IsDigit(input[i]))
                            {
                                int index = int.Parse(input[i].ToString());
                                if (index < textMessage.Length)
                                {
                                    sb.Append(textMessage[index]);
                                }
                            }
                        }
                        Console.WriteLine($"{textMessage} = {sb.ToString()}");
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
