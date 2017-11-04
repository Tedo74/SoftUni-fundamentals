using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.JSONStringify
{
    class JSONStringify
    {
        static void Main()
        {
            List<string> students = new List<string>();
            string inputAll = Console.ReadLine();
            while (inputAll != "stringify")
            {
                string[] input = inputAll.Split(new char[] { ':', '-', '>', ',' },
                    StringSplitOptions.RemoveEmptyEntries);

                string name = input[0].Trim();
                string age = input[1].Trim();
                List<string> grades = new List<string>();
                for (int i = 2; i < input.Length; i++)
                {
                    grades.Add(input[i].Trim());
                }
                students.Add(string.Format("{{name:\"{0}\",age:{1},grades:[{2}]}}", name, age, string.Join(", ", grades)));

                inputAll = Console.ReadLine();
            }
            Console.WriteLine("["+string.Join(",", students)+"]");
        }
    }
}
