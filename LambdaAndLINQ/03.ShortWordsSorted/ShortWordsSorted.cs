using System;
using System.Collections.Generic;
using System.Linq;


namespace _03.ShortWordsSorted
{
    class ShortWordsSorted
    {
        static void Main()
        {
            char[] delimeter = ". , : ; ( ) [ ] \" ' \\ / ! ? ".ToCharArray();
            string[] words = Console.ReadLine().Split(delimeter, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.ToLower()).Distinct().Where(w => w.Length < 5).OrderBy(w => w).ToArray();
            Console.WriteLine(string.Join(", ", words));
        }
    }
}
