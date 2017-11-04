using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SocialMediaPosts
{
    class SocialMediaPosts
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> postLikesDislikes = new Dictionary<string, int[]>();
            Dictionary<string, Dictionary<string, string>> postComments = new Dictionary<string, Dictionary<string, string>>();
            string read = Console.ReadLine();
            while (read != "drop the media")
            {
                string[] input = read.Split(' ');
                switch (input[0])
                {
                    case "post":
                        {
                            postLikesDislikes.Add(input[1], new[] { 0, 0 });
                            break;
                        }
                    case "comment":
                        {
                            if (!postComments.ContainsKey(input[1]))
                            {
                                postComments.Add(input[1], new Dictionary<string, string>());
                            }
                            postComments[input[1]].Add(input[2], string.Join(" ",input.Skip(3)));
                            break;
                        }
                    case "like":
                        {
                            postLikesDislikes[input[1]][0]++;
                            break;
                        }
                    case "dislike":
                        {
                            postLikesDislikes[input[1]][1]++;
                            break;
                        }
                }

                read = Console.ReadLine();
            }
            foreach (var p in postLikesDislikes)
            {
                string post = p.Key;
                int[] likesDislikes = p.Value;
                Console.WriteLine($"Post: {post} | Likes: {likesDislikes[0]} | Dislikes: {likesDislikes[1]}");
                Console.WriteLine("Comments:");
                if (postComments.ContainsKey(post))
                {
                    Dictionary<string, string> nameComment = postComments[post];
                    foreach (var c in nameComment)
                    {
                        Console.WriteLine($"*  {c.Key}: {c.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("None");
                }
            }
        }
    }
}
