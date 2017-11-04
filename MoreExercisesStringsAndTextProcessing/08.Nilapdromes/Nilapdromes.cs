using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Nilapdromes
{
    class Nilapdromes
    {
        static void Main()
        {
            string word = Console.ReadLine();
            while (word != "end")
            {
                word = ReturnNilapdrom(word);
                if (word != String.Empty)
                {
                    Console.WriteLine(word);
                }
                word = Console.ReadLine();
            }
        }

        private static string ReturnNilapdrom(string word)
        {
            if (word.Length < 3)
            {
                return "";
            }
            if (word.Length % 2 == 0)
            {
                string leftBorder = word.Substring(0, word.Length / 2 - 1);
                //Console.WriteLine("leftBorder = " + leftBorder);
                string rightBorder = word.Substring(word.Length / 2 + 1, word.Length - 1 - word.Length / 2);
               // Console.WriteLine("rightBorder = " + rightBorder);
                string middle = word.Substring(leftBorder.Length, word.Length - 2 * leftBorder.Length);
                //Console.WriteLine("middle = " + middle);
                int endIndex = leftBorder.Length;
                for (int i = 0; i <= endIndex; i++)
                {
                    if (!leftBorder.Any())
                    {
                        return "";
                    }
                    if (leftBorder == rightBorder)
                    {
                        return middle + leftBorder + middle;
                    }
                    else
                    {
                        middle = leftBorder[leftBorder.Length - 1] + middle + rightBorder[0];
                        leftBorder = leftBorder.Remove(leftBorder.Length - 1, 1);
                        rightBorder = rightBorder.Remove(0, 1);
                        //Console.WriteLine("middle = " + middle);
                        //Console.WriteLine("rightBorder = " + rightBorder);
                        //Console.WriteLine("leftBorder = " + leftBorder);
                    }
                }
                return "";
            }
            else
            {
                string leftBorder = word.Substring(0, word.Length / 2);
                //Console.WriteLine("leftBorder = " + leftBorder);
                string rightBorder = word.Substring(word.Length / 2 + 1, word.Length - 1 - word.Length / 2);
                //Console.WriteLine("rightBorder = " + rightBorder);
                string middle = word.Substring(leftBorder.Length, word.Length - 2 * leftBorder.Length);
                //Console.WriteLine("middle = " + middle);
                int endIndex = leftBorder.Length;
                for (int i = 0; i <= endIndex; i++)
                {
                    if (!leftBorder.Any())
                    {
                        return "";
                    }
                    if (leftBorder == rightBorder)
                    {
                        return middle + leftBorder + middle;
                    }
                    else
                    {
                        middle = leftBorder[leftBorder.Length - 1] + middle + rightBorder[0];
                        leftBorder = leftBorder.Remove(leftBorder.Length - 1, 1);
                        rightBorder = rightBorder.Remove(0, 1);
                        //Console.WriteLine("middle = " + middle);
                        //Console.WriteLine("rightBorder = " + rightBorder);
                        //Console.WriteLine("leftBorder = " + leftBorder);
                    }
                }
                return "";
            }
        }
    }
}
