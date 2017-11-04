using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Websites
{
    class Websites
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<Website> websites = new List<Website>();
            while (input != "end")
            {
                string[] inputTokens = input.Split(new string[] {" | ", ","}, StringSplitOptions.RemoveEmptyEntries);
                string host = inputTokens[0];
                string domain = inputTokens[1];
                Website web = new Website(host, domain);
                for (int i = 2; i <inputTokens.Length; i++)
                {
                    web.Queries.Add(inputTokens[i]);
                }
                websites.Add(web);
                input = Console.ReadLine();
            }
            foreach (var site in websites)
            {
                Console.Write($"https://www.{site.Host}.{site.Domain}");
                if (site.Queries.Any())
                {
                    var queries = site.Queries.Select(s => "[" + s + "]");
                    Console.WriteLine($"/query?={string.Join("&",queries)}");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }

    class Website
    {
        public string Host { set; get; }
        public string Domain { set; get; }
        public List<string> Queries { set; get; }
        public Website(string host, string domain)
        {
            this.Domain = domain;
            this.Host = host;
            this.Queries = new List<string>();
        }
    }
}
