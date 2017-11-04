using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Placeholders
{
    class Placeholders
    {
        static void Main()
        {
            string inputAll = Console.ReadLine();
            while (inputAll != "end")
            {
                string[] input = inputAll.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string text = input[0];
                string[] words = input[1].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < words.Length; i++)
                {
                    string placeholder = "{" + i + "}";
                    text = text.Replace(placeholder, words[i]);
                }
                Console.WriteLine(text);
                inputAll = Console.ReadLine();
            }
        }
    }
}
