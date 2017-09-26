using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _8.Commits
{
    class Commit
    {
        public string HashCommit { get; set; }
        public string Message { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; }

        public Commit(string commit, string message, int add, int del)
        {
            this.HashCommit = commit;
            this.Message = message;
            this.Additions = add;
            this.Deletions = del;
        }

        public override string ToString()
        {
            string toPrint = string.Format
                ($"commit {this.HashCommit}: {this.Message} ({this.Additions} additions, {this.Deletions} deletions)");
            return toPrint;
        }
    }
    class Commits
    {
        public static void Main()
        {
            var data = new SortedDictionary<string, SortedDictionary<string, List<Commit>>>();
            string pattern =
                @"^https:\/\/github\.com\/(?<name>[A-Za-z0-9\-]+)\/(?<repo>[A-Za-z\-_]+)\/commit\/(?<commitHash>[0-9a-f]{40}),(?<message>[^\n]+),(?<additions>[0-9]+),(?<deletions>[0-9]+)$";
            Regex urlPattern = new Regex(pattern);
            string input = Console.ReadLine();
            while (input != "git push")
            {
                if (urlPattern.IsMatch(input))
                {
                    Match match = urlPattern.Match(input);
                    string user = match.Groups["name"].Value;
                    string repo = match.Groups["repo"].Value;
                    string hashCommit = match.Groups["commitHash"].Value;
                    string message = match.Groups["message"].Value;
                    int additions = int.Parse(match.Groups["additions"].Value);
                    int deletions = int.Parse(match.Groups["deletions"].Value);

                    Commit commit = new Commit(hashCommit, message, additions, deletions);
                    if (!data.ContainsKey(user))
                    {
                        data.Add(user, new SortedDictionary<string, List<Commit>>());
                    }
                    if (!data[user].ContainsKey(repo))
                    {
                        data[user].Add(repo, new List<Commit>());
                    }
                    data[user][repo].Add(commit);
                }

                input = Console.ReadLine();
            }
            foreach (var d in data)
            {
                string user = d.Key;
                var commitsData = d.Value;
                Console.WriteLine($"{user}:");
                foreach (var cd in commitsData)
                {
                    string repo = cd.Key;
                    Console.WriteLine($"  {repo}:");
                    List<Commit> commits = cd.Value;
                    foreach (var c in commits)
                    {
                        Console.WriteLine($"    {c}");
                    }
                    int totalAditions = commits.Sum(a => a.Additions);
                    int totalDeletions = commits.Sum(del => del.Deletions);
                    Console.WriteLine($"    Total: {totalAditions} additions, {totalDeletions} deletions");
                }
            }
        }
    }
}
