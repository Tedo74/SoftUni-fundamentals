using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class ReverseString
    {
        static void Main()
        {
            String toReverse = Console.ReadLine();
            string reversed = new string(toReverse.Reverse().ToArray());
            Console.WriteLine(reversed);
        }
    }
}
