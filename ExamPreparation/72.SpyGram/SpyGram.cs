using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _72.SpyGram
{
    class Message
    {
        public string Sender { get; set; }
        public string MyMessage { get; set; }

        public Message(string sender, string validMessage)
        {
            this.Sender = sender;
            this.MyMessage = validMessage;
        }
    }
    class SpyGram
    {
        static void Main(string[] args)
        {
            List<Message> validMessages = new List<Message>();
            int[] keys = Console.ReadLine().Select(n => int.Parse(n.ToString())).ToArray();
            while (true)
            {
                string message = Console.ReadLine();
                if (message == "END")
                {
                    break;
                }
                if (GetSender(message) != string.Empty)
                {
                    int count = 0;
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < message.Length; i++)
                    {
                        char currentChar = (char)(message[i] + keys[count]);
                        sb.Append(currentChar);
                        if (count < keys.Length - 1)
                        {
                            count++;
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                    validMessages.Add(new Message(GetSender(message), sb.ToString()));
                }
            }
            if (validMessages.Any())
            {
                foreach (var message in validMessages.OrderBy(sender => sender.Sender))
                {
                    Console.WriteLine(message.MyMessage);
                }
            }
        }

        private static string GetSender(string message)
        {
            string pattern = @"^TO: ([A-Z]+); MESSAGE: .+?;$";
            Regex messageRegex = new Regex(pattern);
            if (messageRegex.IsMatch(message))
            {
                Match m = messageRegex.Match(message);
                string sender = m.Groups[1].Value;
                return sender;
            }
            return string.Empty;
        }
    }
}
