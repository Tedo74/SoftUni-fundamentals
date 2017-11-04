using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.StringCommander
{
    class StringCommander
    {
        static void Main()
        {
            string toManipulate = Console.ReadLine();
            string inputCommand = Console.ReadLine();
            while (inputCommand != "end")
            {
                string[] command = inputCommand.Split(' ');
                switch (command[0])
                {
                    case "Left":
                        toManipulate = MoveLeft(toManipulate, command);
                        break;
                    case "Right":
                        toManipulate = MoveRight(toManipulate, command);
                        break;
                    case "Delete":
                        toManipulate = DeleteString(toManipulate, command);
                        break;
                    case "Insert":
                        toManipulate = InsertString(toManipulate, command);
                        break;
                }
                inputCommand = Console.ReadLine();
            }
            Console.WriteLine(toManipulate);
        }

        private static string InsertString(string toManipulate, string[] command)
        {
            int position = int.Parse(command[1]);
            toManipulate = toManipulate.Insert(position, command[2]);
            return toManipulate;
        }

        private static string DeleteString(string toManipulate, string[] command)
        {
            int startIndex = int.Parse(command[1]);
            int endIndex = int.Parse(command[2]);
            toManipulate = toManipulate.Remove(startIndex, endIndex - startIndex +1);
            return toManipulate;
        }

        private static string MoveRight(string toManipulate, string[] command)
        {
            int n = int.Parse(command[1]);
            for (int i = 0; i < n; i++)
            {
                char temp = toManipulate[toManipulate.Length - 1];
                toManipulate = toManipulate.Remove(toManipulate.Length - 1);
                toManipulate = toManipulate.Insert(0, temp.ToString());
            }
            return toManipulate;
        }

        private static string MoveLeft(string toManipulate, string[] command)
        {
            StringBuilder sb = new StringBuilder(toManipulate);
            int n = int.Parse(command[1]);
            for (int j = 0; j < n; j++)
            {
                char temp = sb[0];
                for (int i = 1; i < sb.Length; i++)
                {
                    sb[i - 1] = sb[i];
                }
                sb[sb.Length - 1] = temp;
            }
            return sb.ToString();
        }
    }
}
