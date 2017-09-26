using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.MatchFullName
{
    class MatchFullName
    {
        static void Main()
        {
            Regex pattern = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");
            string fullName = Console.ReadLine();
            MatchCollection matchedNames = pattern.Matches(fullName);
            foreach (Match name in matchedNames)
            {
                Console.Write(name.Value+" ");
            }
            Console.WriteLine();
        }
    }
}
