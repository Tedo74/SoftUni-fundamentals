using System;

namespace E1
{
    public class PadawanEquipment
    {
        public static void Main()
        {
            decimal money = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal lightsaberPrice = decimal.Parse(Console.ReadLine());
            decimal robePrice = decimal.Parse(Console.ReadLine());
            decimal beltPrice = decimal.Parse(Console.ReadLine());

            long moreLightsabers = (long)Math.Ceiling(students * 0.1);
            decimal lights = (students * lightsaberPrice) + (moreLightsabers * lightsaberPrice);

            decimal robesPrise = robePrice * students;

            int freeBelts = students / 6;
            decimal beltPrices = students * beltPrice - (freeBelts * beltPrice);

            decimal totalPrice = lights + robesPrise + beltPrices;

            if (money >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {Math.Abs( money - totalPrice):F2}lv more.");
            }

        }
    }
}
