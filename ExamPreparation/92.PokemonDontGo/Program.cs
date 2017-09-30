using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _92.PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int removedElementsTotalValue = 0;
            while (numbers.Any())
            {
                int index = int.Parse(Console.ReadLine());
                int value;
                if (index >= 0 && index < numbers.Count)
                {
                    value = numbers[index];
                    numbers.RemoveAt(index);
                    removedElementsTotalValue += value;
                    if (!numbers.Any())
                    {
                        break;
                    }
                    numbers = numbers.Select(n => ChangeValue(value, n)).ToList();
                }
                else if (index < 0)
                {
                    value = numbers[0];
                    removedElementsTotalValue += value;
                    numbers[0] = numbers[numbers.Count - 1];
                    numbers = numbers.Select(n => ChangeValue(value, n)).ToList();
                }
                else
                {
                    value = numbers[numbers.Count - 1];
                    removedElementsTotalValue += value;
                    numbers[numbers.Count - 1] = numbers[0];
                    numbers = numbers.Select(n => ChangeValue(value, n)).ToList();
                }
            }
            Console.WriteLine(removedElementsTotalValue);
        }

        private static int ChangeValue(int value, int numbersValue)
        {
            if (numbersValue <= value)
            {
                numbersValue += value;
            }
            else
            {
                numbersValue -= value;
            }
            return numbersValue;
        }
    }
}
