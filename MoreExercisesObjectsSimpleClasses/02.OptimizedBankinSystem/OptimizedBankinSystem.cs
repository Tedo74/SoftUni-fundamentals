using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OptimizedBankinSystem
{
    class OptimizedBankinSystem
    {
        static void Main()
        {
            List<BankAccount> accounts = new List<BankAccount>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputs = input.Split(new string[]{" | "}, StringSplitOptions.RemoveEmptyEntries);
                string bank = inputs[0];
                string name = inputs[1];
                decimal money = decimal.Parse(inputs[2]);
                accounts.Add(new BankAccount(bank, name, money));
                input = Console.ReadLine();
            }
            var orderedAccounts = accounts.OrderByDescending(a => a.Money).ThenBy(a => a.Bank.Length);
            foreach (var a in orderedAccounts)
            {
                Console.WriteLine($"{a.AccountName} -> {a.Money} ({a.Bank})");
            }
        }
    }

    class BankAccount
    {
        public string Bank { get; set; }
        public string AccountName { get; set; }
        public decimal Money { get; set; }

        public BankAccount(string bank, string account, decimal money)
        {
            this.Bank = bank;
            this.AccountName = account;
            this.Money = money;
        }
    }
}
