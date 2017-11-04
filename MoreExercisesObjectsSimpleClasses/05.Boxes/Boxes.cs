using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Boxes
{
    class Boxes
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] points = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                Point topLeft = new Point(points[0]);
                Point topRight = new Point(points[1]);
                Point bottomLeft = new Point(points[2]);
                Point bottomRight = new Point(points[3]);
                Box b= new Box(topLeft, topRight, bottomLeft, bottomRight);
                boxes.Add(b);
                input = Console.ReadLine();
            }
            foreach (var box in boxes)
            {
                Console.WriteLine($"Box: {box.getWidth()}, {box.getHeight()}");
                Console.WriteLine($"Perimeter: {box.getPerimeter()}");
                Console.WriteLine($"Area: {box.getArea()}");
            }
        }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(string points)
        {
            int[] pointXY = points.Split(':').Select(int.Parse).ToArray();
            this.X = pointXY[0];
            this.Y = pointXY[1];
        }
    }

    class Box
    {
        public Point TopLeft { get; set; }
        public Point TopRight { get; set; }
        public Point BottomLeft { get; set; }
        public Point BottomRight { get; set; }
        
        public Box(Point a,Point b, Point c,Point d)
        {
            this.TopLeft = a;
            this.TopRight = b;
            this.BottomLeft = c;
            this.BottomRight = d;
        }

        public int getWidth()
        {
            return Math.Abs(this.TopLeft.X - this.TopRight.X);
        }

        public int getHeight()
        {
            return Math.Abs(this.TopLeft.Y - this.BottomLeft.Y);
        }

        public int getArea()
        {
            return getHeight() * getWidth();
        }

        public int getPerimeter()
        {
            return (getHeight() * 2)+(getWidth() * 2);
        }
    }
}
