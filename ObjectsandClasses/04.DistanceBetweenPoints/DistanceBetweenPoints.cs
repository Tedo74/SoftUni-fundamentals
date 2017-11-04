using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DistanceBetweenPoints
{
    class DistanceBetweenPoints
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(Console.ReadLine());
            Point point2 = new Point(Console.ReadLine());
            double distance = point1.getDistance(point2);
            Console.WriteLine($"{distance:F3}");
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(string p)
        {
            int[] pointXY = p.Split(' ').Select(int.Parse).ToArray();
            this.X = pointXY[0];
            this.Y = pointXY[1];
        }

        public double getDistance(Point otherPoint)
        {
            int sideA = (this.X - otherPoint.X);
            int sideB = (this.Y - otherPoint.Y);
            double sideC =( Math.Pow(sideA, 2))+(Math.Pow(sideB,2));
            return Math.Sqrt(sideC);
        }
    }
}
