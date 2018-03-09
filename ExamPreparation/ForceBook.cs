using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace E3
{
    public class ForceBook
    {
        public static void Main()
        {
            var forces = new Dictionary<string, SortedSet<string>>();
            Dictionary<string, string> userByForces = new Dictionary<string, string>();

            string input = Console.ReadLine();
            string pattern1 = @"(.+?) (\|) (.+)";
            string pattern2 = @"(.+?) (\->) (.+)";
            Regex p1 = new Regex(pattern1);
            Regex p2 = new Regex(pattern2);

            while (input != "Lumpawaroo")
            {


                if (p1.IsMatch(input))
                {
                    MatchCollection m = p1.Matches(input);
                    string side = string.Empty;
                    string user = string.Empty;

                    foreach (Match match in m)
                    {
                        side = match.Groups[1].Value;
                        user = match.Groups[3].Value;
                    }

                    if (!userByForces.ContainsKey(user))
                    {
                        userByForces[user] = side;

                        if (!forces.ContainsKey(side))
                        {
                            forces.Add(side, new SortedSet<string>());
                        }
                        forces[side].Add(user);
                    }

                }

                else if (p2.IsMatch(input))
                {
                    MatchCollection m = p2.Matches(input);
                    string side = string.Empty;
                    string user = string.Empty;

                    foreach (Match match in m)
                    {
                        side = match.Groups[3].Value;
                        user = match.Groups[1].Value;
                    }

                    if (!userByForces.ContainsKey(user))
                    {
                        Console.WriteLine($"{user} joins the {side} side!");
                        userByForces[user] = side;
                        if (!forces.ContainsKey(side))
                        {
                            forces.Add(side, new SortedSet<string>());
                        }
                        forces[side].Add(user);
                    }
                    else
                    {
                        string oldSide = userByForces[user];
                        if (oldSide != side)
                        {
                            forces[userByForces[user]].Remove(user);
                            if (!forces.ContainsKey(side))
                            {
                                forces.Add(side, new SortedSet<string>());
                            }
                            forces[side].Add(user);
                            userByForces[user] = side;
                            Console.WriteLine($"{user} joins the {side} side!");
                        }
                    }
                }

                input = Console.ReadLine();
            }

            var orderedForces = forces.OrderByDescending(f => f.Value.Count).ThenBy(name => name.Key);
            foreach (var force in orderedForces)
            {
                if (force.Value.Any())
                {
                    Console.WriteLine($"Side: {force.Key}, Members: {force.Value.Count}");
                    foreach (var name in force.Value)
                    {
                        Console.WriteLine($"! {name}");
                    }
                }
            }
        }
    }
}
