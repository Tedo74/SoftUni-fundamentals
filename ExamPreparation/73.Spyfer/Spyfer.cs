using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _73.Spyfer
{
    class Spyfer
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Spy(numbers);
        }

        private static void Spy(List<int> numbers)
        {
            bool isFound = true;
            while (isFound && numbers.Count >= 2)
            {
                isFound = false;
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i == 0 && numbers[0] == numbers[1])
                    {
                        isFound = true;
                        numbers.RemoveAt(i + 1);
                        break;
                    }
                    else if(i == numbers.Count -1 && numbers[numbers.Count - 2] == numbers[numbers.Count -1])
                    {
                        isFound = true;
                        numbers.RemoveAt(i - 1);
                        break;
                    }
                    else if (i != 0 && i != numbers.Count -1 && numbers[i] == (numbers[i - 1] + numbers[i + 1]))
                    {
                        isFound = true;
                        numbers.RemoveAt(i + 1);
                        numbers.RemoveAt(i - 1);
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
