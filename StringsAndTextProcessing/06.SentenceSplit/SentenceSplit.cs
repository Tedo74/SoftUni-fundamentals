using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SentenceSplit
{
    class SentenceSplit
    {
        static void Main()
        {
            string sentence = Console.ReadLine();
            string delimeter = Console.ReadLine();
            string[] tokens = sentence.Split(new string[] {delimeter}, StringSplitOptions.None);
            Console.WriteLine("["+string.Join(", ", tokens)+"]");
        }
    }
}
