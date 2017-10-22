using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arr1 = Console.ReadLine().ToCharArray().Where(c => c != ' ').ToArray();
            char[] arr2 = Console.ReadLine().ToCharArray().Where(c => c != ' ').ToArray();
            int minLength = Math.Min(arr1.Length, arr2.Length);
            bool areAllEquals = true;
            for (int i = 0; i < minLength; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    continue;
                }
                if (arr1[i]< arr2[i])
                {
                    areAllEquals = false;
                    Console.WriteLine(new string(arr1));
                    Console.WriteLine(new string(arr2));
                    break;
                }
                else
                {
                    areAllEquals = false;
                    Console.WriteLine(new string(arr2));
                    Console.WriteLine(new string(arr1));
                    break;
                }
            }
            if (areAllEquals)
            {
                if (arr1.Length == minLength)
                {
                    Console.WriteLine(new string(arr1));
                    Console.WriteLine(new string(arr2));
                }
                else
                {
                    Console.WriteLine(new string(arr2));
                    Console.WriteLine(new string(arr1));
                }
            }
        }
    }
}
