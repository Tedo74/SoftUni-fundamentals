using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,int>> allClothes = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(',');
                if (!allClothes.ContainsKey(color))
                {
                    allClothes.Add(color, new Dictionary<string, int>());
                }
                for (int j = 0; j < clothes.Length; j++)
                {
                    Dictionary<string,int> cloth = allClothes[color];
                    if (!cloth.ContainsKey(clothes[j]))
                    {
                        cloth.Add(clothes[j],0);
                    }
                    cloth[clothes[j]]++;
                }
            }
            string[] searchTokens = Console.ReadLine().Split(' ');
            string byColor = searchTokens[0];
            string byCloth = searchTokens[1];
            foreach (var colorData in allClothes)
            {
                Console.WriteLine($"{colorData.Key} clothes:");
                foreach (var clothItem in colorData.Value)
                {
                    if (colorData.Key == byColor && clothItem.Key == byCloth)
                    {
                        Console.WriteLine($"* {clothItem.Key} - {clothItem.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothItem.Key} - {clothItem.Value}");
                    }
                }
            }
        }
    }
}
