using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.UserLogins
{
    class UserLogins
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> allUsers = new Dictionary<string, string>();
            do
            {
                string[] input = Console.ReadLine().Split(new char[]{' ','-','>'},StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[0] == "login")
                {
                    break;
                }
                string user = input[0];
                string password = input[1];
                allUsers[user] = password;
            } while (true);
            int loginsFiled = 0;
            do
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[0] == "end")
                {
                    break;
                }
                string user = input[0];
                string password = input[1];
                if (!allUsers.ContainsKey(user) || allUsers[user] != password)
                {
                    loginsFiled++;
                    Console.WriteLine($"{user}: login failed");
                }
                else
                {
                    Console.WriteLine($"{user}: logged in successfully");
                }
            } while (true);
            Console.WriteLine($"unsuccessful login attempts: {loginsFiled}");
        }
    }
}
