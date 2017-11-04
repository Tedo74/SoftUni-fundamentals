using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RecordUniqueNames
{
    class RecordUniqueNames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }
            Console.WriteLine("{0}", string.Join(Environment.NewLine,names));
        }
    }
}
