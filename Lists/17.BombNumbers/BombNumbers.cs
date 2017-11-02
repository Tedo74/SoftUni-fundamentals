using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.BombNumbers
{
    public class BombNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int[] bomb = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int specialNumber = bomb[0];
            int power = bomb[1];
            int index = numbers.IndexOf(specialNumber);
            while ( index != -1)
            {
                int left = index - power;
                if (index - power < 0)
                {
                    left = 0;
                }
                for (int i = left; i < index; i++)
                {
                    numbers[i] = 0;
                }
                int right = index + power;
                if (index + power > numbers.Count -1)
                {
                    right = numbers.Count -1;
                }
                for (int i = index; i <= right; i++)
                {
                    numbers[i] = 0;
                }
                index = numbers.IndexOf(specialNumber, index + 1);
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
