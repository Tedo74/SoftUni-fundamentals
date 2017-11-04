using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Pyramidic
{
    class Pyramidic
    {
        static void Main()
        {
            List<string> lines = new List<string>();
            List<string> piramides = new List<string>();
            int biggestPiramid = 3;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                lines.Add(line);
            }

            for (int i = 0; i < lines.Count; i++) // all lines
            {
                string line = lines[i]; // current line
                for (int j = 0; j < line.Length; j++)
                {
                    char currentChar = line[j]; // char from current line
                    StringBuilder sb = new StringBuilder(currentChar + Environment.NewLine);
                    int count = 3;
                    for (int k = i + 1; k < lines.Count; k++)
                    {
                        string piramid = new string(currentChar, count);
                        if (!lines[k].Contains(piramid))
                        {
                            break;
                        }
                        sb.Append(piramid + Environment.NewLine);
                        count += 2;
                    }
                    if (count + 1 > biggestPiramid)
                    {
                        biggestPiramid = count + 1;
                        piramides.Add(sb.ToString());
                    }
                }
            }
            string biggest = piramides.OrderByDescending(p => p.Length).First();
            Console.WriteLine(biggest);
        }
    }
}
