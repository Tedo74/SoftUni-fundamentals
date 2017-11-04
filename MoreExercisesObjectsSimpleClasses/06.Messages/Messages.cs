using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Messages
{
    class Messages
    {
        static void Main()
        {
            Dictionary<string,User> registredUsers = new Dictionary<string, User>();
            string input = Console.ReadLine();
            while (input != "exit")
            {
                string[] inputTokens = input.Split(' ');
                if (inputTokens[0] == "register")
                {
                    if (!registredUsers.ContainsKey(inputTokens[1]))
                    {
                        registredUsers[inputTokens[1]] = new User(inputTokens[1]);
                    }
                }
                else
                {
                    string senderName = inputTokens[0];
                    string recipientName = inputTokens[2];
                    if (registredUsers.ContainsKey(senderName) && registredUsers.ContainsKey(recipientName))
                    {
                        string message = string.Join(" ",inputTokens.Skip(3));
                        User sender = registredUsers[senderName];
                        User recipient = registredUsers[recipientName];
                        Message m = new Message(senderName, message, recipientName);
                       
                            sender.sendMessage(m, recipient);
                       
                        registredUsers[recipientName] = recipient;
                    } 
                }
                input = Console.ReadLine();
            }
            string[] names = Console.ReadLine().Split(' ');
            string firstName = names[0];
            string secondName = names[1];
            //if (registredUsers.ContainsKey(firstName) && registredUsers.ContainsKey(secondName))
            //{
                List<Message> firstUserSendMessages = registredUsers[secondName].Usermesages
                    .Where(s => s.Sender == firstName).ToList();
                List<Message> secondUserSendMessages = registredUsers[firstName].Usermesages
                    .Where(s => s.Sender == secondName).ToList();
                if (!firstUserSendMessages.Any() && !secondUserSendMessages.Any())
                {
                    Console.WriteLine("No messages");
                }
            int firstIndex = 0;
            int secondIndex = 0;
            while (firstIndex < firstUserSendMessages.Count && secondIndex < secondUserSendMessages.Count)
            {
                Message firstUser = firstUserSendMessages[firstIndex];
                Message secondUser = secondUserSendMessages[secondIndex];
                Console.WriteLine($"{firstUser.Sender}: {firstUser.Content}");
                Console.WriteLine($"{secondUser.Content} :{secondUser.Sender}");
                firstIndex++;
                secondIndex++;
            }
            while (firstIndex < firstUserSendMessages.Count)
            {
                Message firstUser = firstUserSendMessages[firstIndex];
                Console.WriteLine($"{firstUser.Sender}: {firstUser.Content}");
                firstIndex++;
            }
            while (secondIndex < secondUserSendMessages.Count)
            {
                Message secondUser = secondUserSendMessages[secondIndex];
                Console.WriteLine($"{secondUser.Content} :{secondUser.Sender}");
                secondIndex++;
            }
            // }

        }
    }

    class Message
    {
        public string Content { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }

        public Message(string sender, string message, string recipient)
        {
            this.Content = message;
            this.Sender = sender;
            this.Recipient = recipient;
        }
    }

    class User
    {
        public string Name { get; set; }
        public List<Message> Usermesages { get; set; }

        public User(string name)
        {
            this.Name = name;
            this.Usermesages = new List<Message>();
        }

        public void sendMessage(Message m, User recipient)
        {
            recipient.Usermesages.Add(m);
        }
    }
}
