using System;
using System.Collections.Generic;
using System.Linq;


namespace _06.OrderedBankingSystem
{
    class OrderedBankingSystem
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, decimal>> banks = new Dictionary<string, Dictionary<string, decimal>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputTokens = input.Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                string bankName = inputTokens[0];
                string account = inputTokens[1];
                decimal money = decimal.Parse(inputTokens[2]);
                if (!banks.ContainsKey(bankName))
                {
                    banks.Add(bankName, new Dictionary<string, decimal>());
                }
                if (!banks[bankName].ContainsKey(account))
                {
                    banks[bankName][account] = 0;
                }
                banks[bankName][account] += money;
                input = Console.ReadLine();
            }
            var sortedBanks = banks.OrderByDescending(b => b.Value.Sum(m => m.Value))
                .ThenByDescending(b => b.Value.Max(m => m.Value));

            foreach (var b in sortedBanks)
            {
                var accounts = b.Value.OrderByDescending(a => a.Value);
                foreach (var a in accounts)
                {
                    Console.WriteLine($"{a.Key} -> {a.Value} ({b.Key})");
                }
            }
        }
    }
}
