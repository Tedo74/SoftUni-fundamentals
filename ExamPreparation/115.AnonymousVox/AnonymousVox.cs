using System;
using System.Text.RegularExpressions;

namespace _15.AnonymousVox
{
    public class AnonymousVox
    {
        public static void Main()
        {
            string encodedText = Console.ReadLine();
            string[] placeHolders = Console.ReadLine().Split("{}".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"([A-Za-z]+)(.+)(\1)+";
            Regex decodeText = new Regex(pattern);
            MatchCollection matches = decodeText.Matches(encodedText);
            int count = 0;

            foreach (Match m in matches)
            {
                string decoded = m.Groups[1] + placeHolders[count] + m.Groups[3];
                count++;
                encodedText = encodedText.Replace(m.Groups[0].Value, decoded);
            }

            Console.WriteLine(encodedText);
        }
    }
}
