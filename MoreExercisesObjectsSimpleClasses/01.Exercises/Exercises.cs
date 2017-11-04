using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Exercises
{
    class Exercises
    {
        static void Main(string[] args)
        {
            List<Learn> exercises = new List<Learn>();
            string input = Console.ReadLine();
            while (input != "go go go")
            {
                List<string> inputs = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string topic = inputs[0];
                string courseName = inputs[1];
                string judgeLink = inputs[2];
                List<string> tasks = inputs[3].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                Learn l = new Learn(topic, courseName, judgeLink, tasks);
                exercises.Add(l);
                input = Console.ReadLine();
            }
            foreach (var e in exercises)
            {
                Console.WriteLine($"Exercises: {e.Topic}");
                Console.WriteLine($"Problems for exercises and homework for the \"{e.CourseName}\" course @ SoftUni.");
                Console.WriteLine($"Check your solutions here: {e.JudgeLink}");
                int count = 0;
                foreach (var problem in e.Problems)
                {
                    count++;
                    Console.WriteLine($"{count}. {problem}");
                }
            }
        }
    }

    class Learn
    {
        public string Topic { get; set; }
        public string CourseName { get; set; }
        public string JudgeLink { get; set; }
        public List<string> Problems { get; set; }

        public Learn(string topic, string courseName, string judgeLink, List<string> tasks)
        {
            this.Topic = topic;
            this.CourseName = courseName;
            this.JudgeLink = judgeLink;
            this.Problems = tasks;
        }
    }
}
