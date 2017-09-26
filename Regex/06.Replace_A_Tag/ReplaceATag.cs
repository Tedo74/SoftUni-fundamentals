using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.Replace_A_Tag
{
    class ReplaceATag
    {
        static void Main()
        {
            string pattern = @"<a.*?href=(.+?)>(.+?)<\/a>";
            Regex regex = new Regex(pattern);
            string htmlText = Console.ReadLine();
            while (htmlText !="end")
            {
                var replacment = "[URL href=$1]$2[/URL]";
                var result = regex.Replace(htmlText, replacment);
                Console.WriteLine(result);
                htmlText = Console.ReadLine();
            }
        }
    }
}
