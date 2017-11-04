using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RegisteredUsers
{
    class RegUsers
    {
        static void Main()
        {
            Dictionary<string, DateTime> users = new Dictionary<string, DateTime>();
            
            int count = 0;
            while (true)
            {
                count++;
                string[] input = Console.ReadLine().Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "end")
                {
                    break;
                }
                string user = input[0];
                DateTime dateOfRegistration = DateTime.ParseExact(input[1], "dd/MM/yyyy", null);
                users[user] = dateOfRegistration;
            }
            //int toSkip = users.Count - 5;
            Dictionary<string, DateTime> result = users.Reverse().OrderBy(d => d.Value).Take(5).OrderByDescending(d => d.Value)
                .ToDictionary(d => d.Key, d => d.Value);
            
            foreach (var u in result)
            {
                Console.WriteLine($"{u.Key}");
            }
        }
    }
}
