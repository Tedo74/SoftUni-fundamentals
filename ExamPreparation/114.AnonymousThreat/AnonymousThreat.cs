using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.AnonymousThreat
{
    public class AnonymousThreat
    {
        public static void Main()
        {
            List<string> input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "3:1")
            {
                string[] currentCommand = command.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (currentCommand[0] == "merge")
                {
                    int start = int.Parse(currentCommand[1]); 
                    int end = int.Parse(currentCommand[2]);
                    start = ValidateIndex(start, input.Count);
                    end = ValidateIndex(end, input.Count);

                    string concate = "";
                    for (int i = start; i <= end; i++)
                    {
                        concate += input[i];
                    }

                    for (int i = start; i <= end; i++)
                    {
                        input.RemoveAt(start);
                    }

                    input.Insert(start, concate);
                }
                else if(currentCommand[0] == "divide")
                {
                    int index = int.Parse(currentCommand[1]);
                    int partitions = int.Parse(currentCommand[2]);
                    string current = input[index];
                    List<string> dividedstring = new List<string>();
                    int partLength = current.Length / partitions;

                    for (int i = 0; i < current.Length; i+= partLength)
                    {
                        dividedstring.Add(new string(current.Skip(i).Take(partLength).ToArray()));
                    }

                    if (dividedstring.Count > partitions)
                    {
                        string temp = dividedstring[dividedstring.Count - 1];
                        string newLast = dividedstring[dividedstring.Count - 2];
                        dividedstring[dividedstring.Count - 2] = newLast + temp;
                        dividedstring.RemoveAt(dividedstring.Count - 1);
                    }

                    input.RemoveAt(index);
                    input.InsertRange(index, dividedstring);
                }


                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", input));
        }

        static int ValidateIndex(int index, int count)
        {
            if (index < 0)
            {
                return 0;
            }
            else if (index > count -1)
            {
                return count - 1;
            }

            return index;
        }
    }
}
