using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.SweetDessert
{
    class SweetDessert
    {
        public static void Main()
        {
            decimal ivanchosMoney = decimal.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            decimal bananasPrice = decimal.Parse(Console.ReadLine());
            decimal eggsPrice = decimal.Parse(Console.ReadLine());
            decimal berriesPrice = decimal.Parse(Console.ReadLine());
            int set = 0;
            if (guests > 0)
            {
                set = 1;
            }
            if (guests > 5)
            {
                set = guests / 6;
            }
            if (guests > 5 && guests % 6 != 0)
            {
                set += 1;
            }

            decimal nededMoney = Math.Round(CalcMoney(set, bananasPrice, eggsPrice, berriesPrice), 2);
            if (ivanchosMoney >= nededMoney)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {nededMoney:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {nededMoney - ivanchosMoney:F2}lv more.");
            }

        }

        public static decimal CalcMoney(int set, decimal bananasprice, decimal eggsPrice, decimal berriesPrice)
        {
            decimal money = set * 2 * bananasprice;
            money += set * 4 * eggsPrice;
            money += set * 0.2M * berriesPrice;
            return money;
        }
    }
}
