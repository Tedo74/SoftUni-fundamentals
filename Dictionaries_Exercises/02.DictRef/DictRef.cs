using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DictRef
{
    class DictRef
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> values = new Dictionary<string, int>();
            string[] tokens = ReadInput();
            while (tokens[0] != "end")
            {
                string name = tokens[0];
                string maybeValue = tokens[1];
                int number;
                if (int.TryParse(maybeValue, out number))
                {
                    values[name] = number;
                }
                else
                {
                    if (values.ContainsKey(maybeValue))
                    {
                        values[name] = values[maybeValue];
                    }
                }
                tokens = ReadInput();
            }
            foreach (KeyValuePair<string,int> item in values)
            {
                Console.WriteLine($"{item.Key} === {item.Value}");
            }
        }
        static string[] ReadInput()
        {
            string[] inputStrings = Console.ReadLine().Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
            return inputStrings;
        }
    }
}
