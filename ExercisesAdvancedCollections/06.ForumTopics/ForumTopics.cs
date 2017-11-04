using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ForumTopics
{
    class ForumTopics
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> topics = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "filter")
                {
                    break;
                }
                string topic = input[0];
                string[] tags = input[1].Split(new string[] {", "}, StringSplitOptions.None);
                if (!topics.ContainsKey(topic))
                {
                   topics.Add(topic,new HashSet<string>(tags)); 
                }
                else
                {
                    foreach (string tag in tags)
                    {
                        topics[topic].Add(tag);
                    }
                }
            }
            string[] tagsToCheck = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.None);
            foreach (KeyValuePair<string, HashSet<string>> t in topics)
            {
                string topic = t.Key;
                HashSet<string> tags = t.Value;
                if (checkTags(t.Value,tagsToCheck))
                {
                    string[] sharpTags = tags.Select(tag => "#" + tag).ToArray();
                    Console.WriteLine($"{topic} | {string.Join(", ",sharpTags)}");
                }
            }
        }

        static bool checkTags(HashSet<string> tags, string[] tagsToCheck)
        {
            foreach (string tagCheck in tagsToCheck)
            {
                if (!tags.Contains(tagCheck))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
