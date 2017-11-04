using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ClosestTwoPoints
{
    class ClosestTwoPoints
    {
        static void Main()
        {
            List<Point> points = new List<Point>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Point point = new Point(Console.ReadLine());
                points.Add(point);
            }
            double minDistance = double.MaxValue;
            Point[] closestPoints = new Point[2];
            for (int p1 = 0; p1 < points.Count-1; p1++)
            {
                for (int p2 = p1+1; p2 < points.Count; p2++)
                {
                    double distance = points[p1].getDistance(points[p2]);
                    if (distance < minDistance )
                    {
                        minDistance = distance;
                        closestPoints[0] = points[p1];
                        closestPoints[1] = points[p2];
                    }
                } 
            }
            Console.WriteLine($"{minDistance:F3}");
            Console.WriteLine($"{closestPoints[0]}");
            Console.WriteLine($"{closestPoints[1]}");
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
            double sideC = (Math.Pow(sideA, 2)) + (Math.Pow(sideB, 2));
            return Math.Sqrt(sideC);
        }

        public override string ToString()
        {
            return string.Format($"({X}, {Y})");
        }
    }
}
