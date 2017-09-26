using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _6.FishStatistics
{
    class FishStatistics
    {
        public static void Main()
        {
            string fishPattern = @"(?<tail>>*)<(?<body>\(+)(?<status>['\-x])>";
            string input = Console.ReadLine();
            MatchCollection fishes = Regex.Matches(input, fishPattern);
            int fishCounter = fishes.Count;
            if (fishCounter < 1)
            {
                Console.WriteLine("No fish found."); 
                return;
            }
            else
            {
                fishCounter = 1;
            }
            foreach (Match fish in fishes)
            {
                Console.WriteLine($"Fish {fishCounter}: {fish.Value}");
                string tail = GetTail(fish.Groups["tail"].Value);
                string body = GetBody(fish.Groups["body"].Value);
                string status = GetStatus(fish.Groups["status"].Value);
                Console.WriteLine(tail);
                Console.WriteLine(body);
                Console.WriteLine(status);

                fishCounter++;
            }
        }

        static string GetTail(string tail)
        {
            string type;
            if (tail.Length > 5)
            {
                type = "Long";
            }
            else if (tail.Length > 1 && tail.Length<= 5)
            {
                type = "Medium";
            }
            else if(tail.Length ==1)
            {
                type = "Short";
            }
            else
            {
                type = "None";
            }
            int tailLongCm = 0;
            if (type != "None")
            {
                tailLongCm = tail.Length * 2;
                return string.Format($"  Tail type: {type} ({tailLongCm} cm)");
            }
            return string.Format($"  Tail type: {type}");
        }

        static string GetBody(string body)
        {
            string type;
            if (body.Length > 10)
            {
                type = "Long";
            }
            else if (body.Length > 5 && body.Length<= 10)
            {
                type = "Medium";
            }
            else
            {
                type = "Short";
            }
            int bodyLongCm = body.Length * 2;
            
                return string.Format($"  Body type: {type} ({bodyLongCm} cm)");
        }

        static string GetStatus(string status)
        {
            if (status == "\'")
            {
                return "  Status: Awake";
            }
            if (status == "-")
            {
                return "  Status: Asleep";
            }
            return "  Status: Dead";
        }
    }
}
