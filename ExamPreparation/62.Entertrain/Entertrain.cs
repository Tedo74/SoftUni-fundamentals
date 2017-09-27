using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _62.Entertrain
{
    class Entertrain
    {
        static void Main(string[] args)
        {
            int locomotivePower = int.Parse(Console.ReadLine());
            List<int> wagons = new List<int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "All ofboard!")
                {
                    break;
                }
                int wagon = int.Parse(input);
                wagons.Add(wagon);
                if (wagons.Sum() > locomotivePower)
                {
                    int average = (int)wagons.Average();
                    int indexToRemove = GetClosest(wagons, average);
                    wagons.RemoveAt(indexToRemove);
                }
            }
            if (wagons.Any())
            {
                wagons.Reverse();
            }
            wagons.Add(locomotivePower);
            Console.WriteLine(string.Join(" ", wagons));
        }

        private static int GetClosest(List<int> wagons, int average)
        {
            int closestWagonWeigth = int.MaxValue;
            int index = -1;
            for (int i = 0; i < wagons.Count; i++)
            {
                if (Math.Abs(wagons[i] - average) < closestWagonWeigth)
                {
                    closestWagonWeigth = Math.Abs(wagons[i] - average);
                    index = i;
                }
            }
            return index;
        }
    }
}
