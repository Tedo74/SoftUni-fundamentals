using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _24.Files
{
    class Files
    {
        public static string GetExtension(string e)
        {
            int index = e.LastIndexOf('.');
            string ext = e.Remove(0, index + 1);
            return ext;
        }
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> directoryFiles = new Dictionary<string, Dictionary<string, long>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                string root = input[0];
                string all = input[input.Length - 1];
                string[] fileNameAndSize = all.Split(';');
                string fileName = fileNameAndSize[0];
                long fileSize = long.Parse(fileNameAndSize[1]);
                if (!directoryFiles.ContainsKey(root))
                {
                    directoryFiles.Add(root, new Dictionary<string, long>());
                }
                directoryFiles[root][fileName] = fileSize;
            }
            string[] command = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (directoryFiles.ContainsKey(command[2]))
            {
                var myFiles = directoryFiles[command[2]].Where(f => GetExtension(f.Key) == command[0])
                    .OrderByDescending(f => f.Value).ThenBy(f => f.Key);
                if (myFiles.Any())
                {
                    foreach (var f in myFiles)
                    {
                        Console.WriteLine($"{f.Key} - {f.Value} KB");
                    }
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
