using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _01.DayOfWeek
{
    class DayOfWeek
    {
        static void Main()
        {
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.DayOfWeek);
        }
    }
}
