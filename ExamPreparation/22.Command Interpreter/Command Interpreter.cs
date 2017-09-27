using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22.Command_Interpreter
{
    class Program
    {
        public static void Main()
        {
            List<string> collection = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] commands = input.Split(' ');
                string command = commands[0];
                int startIndex = -1;
                int count = -1;
                long rollCount = 0;
                if (commands.Length > 3)
                {
                    startIndex = int.Parse(commands[2]);
                    count = int.Parse(commands[4]);
                }
                else
                {
                    rollCount = long.Parse(commands[1]);
                }

                switch (command)
                {
                    case "reverse":
                        if (checkInput(collection, startIndex, count))
                        {
                            Reverse(collection, startIndex, count);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input parameters.");
                        }
                        break;
                    case "sort":
                        if (checkInput(collection, startIndex, count))
                        {
                            SortCollection(collection, startIndex, count);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input parameters.");
                        }
                        break;
                    case "rollLeft":
                        if (rollCount >= 0)
                        {
                            RollLeft(collection, rollCount);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input parameters.");
                        }
                        break;
                    case "rollRight":

                        if (rollCount >= 0)
                        {
                            RollRight(collection, rollCount);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input parameters.");
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", collection)}]");
        }

        private static void RollRight(List<string> collection, long rollCount)
        {
            int n = (int)(rollCount % collection.Count);
            for (int j = 0; j < n; j++)
            {
                string c = collection[collection.Count - 1];
                for (int i = collection.Count - 2; i >= 0; i--)
                {
                    collection[i + 1] = collection[i];
                }
                collection[0] = c;
            }
        }

        private static void RollLeft(List<string> collection, long rollCount)
        {
            int n = (int)(rollCount % collection.Count);
            for (int j = 0; j < n; j++)
            {
                string c = collection[0];
                for (int i = 1; i < collection.Count; i++)
                {
                    collection[i - 1] = collection[i];
                }
                collection[collection.Count - 1] = c;
            }
        }

        private static void Reverse(List<string> collection, int startIndex, int count)
        {
            collection.Reverse(startIndex, count);
        }

        private static void SortCollection(List<string> collection, int startIndex, int count)
        {
            collection.Sort(startIndex, count, null);
        }

        static bool checkInput(List<string> collection, int start, int count)
        {
            if (start < 0 || start>= collection.Count || count < 0 || start + count < 0 || start + count > collection.Count)
            {
                return false;
            }
            return true;
        }
    }
}
