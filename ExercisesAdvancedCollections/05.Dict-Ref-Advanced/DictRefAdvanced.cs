using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Dict_Ref_Advanced
{
    class DictRefAdvanced
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> nameData = new Dictionary<string, List<int>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(new string[] {" -> "}, StringSplitOptions.None);
                if (input[0] == "end")
                {
                    break;
                }
                string name = input[0];
                string[] nameOrNumbers = input[1].Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                bool isNum = IsNumber(nameOrNumbers[0]);
                if (isNum)
                {
                    int[] numbers = nameOrNumbers.Select(int.Parse).ToArray();
                    if (!nameData.ContainsKey(name))
                    {
                        nameData.Add(name, new List<int>());
                    }
                    nameData[name].AddRange(numbers);
                }
                else
                {
                    string otherName = nameOrNumbers[0];
                    if (nameData.ContainsKey(otherName))
                    {
                        if (!nameData.ContainsKey(name))
                        {
                            nameData.Add(name, new List<int>());
                        }
                        nameData[name].Clear();
                        nameData[name].AddRange(nameData[otherName]);
                    }
                }
            }
            foreach (var data in nameData)
            {
                Console.WriteLine($"{data.Key} === {string.Join(", ",data.Value)}");
            }
        }

        static bool IsNumber(string s)
        {
            foreach (char check in s)
            {
                if (char.IsLetter(check))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
