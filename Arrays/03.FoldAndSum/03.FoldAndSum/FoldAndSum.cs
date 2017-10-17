using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FoldAndSum
{
    public class FoldAndSum
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            int k = arr.Length / 4;
            int[] leftTopArr = arr.Take(k).Reverse().ToArray();
            int[] bottomArr = arr.Skip(k).Take(2 * k).ToArray();
            int[] rightTopArr = arr.Skip(3 * k).Take(k).Reverse().ToArray();
            int[] topArr = leftTopArr.Concat(rightTopArr).ToArray();
            int[] finalArr = new int[k * 2];
            for (int i = 0; i < finalArr.Length; i++)
            {
                finalArr[i] = topArr[i] + bottomArr[i];
            }
            Console.WriteLine(string.Join(" ", finalArr));
        }
    }
}
