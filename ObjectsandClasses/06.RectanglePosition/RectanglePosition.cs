using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.RectanglePosition
{
    class RectanglePosition
    {
        static void Main()
        {
            Rectangle rec1 = new Rectangle(Console.ReadLine());
            Rectangle rec2 = new Rectangle(Console.ReadLine());
            if (rec1.IsInside(rec2))
            {
                Console.WriteLine($"Inside");
            }
            else
            {
                Console.WriteLine($"Not inside");
            }
        }
    }

    class Rectangle
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Bottom{ get { return Top + Height; } }
        public int Right { get { return Left + Width; } }

        public Rectangle(string r)
        {
            int[] coordinates = r.Split(' ').Select(int.Parse).ToArray();
            this.Left = coordinates[0];
            this.Top = coordinates[1];
            this.Width = coordinates[2];
            this.Height = coordinates[3];
        }

        public bool IsInside(Rectangle rec)
        {
            if (this.Left >= rec.Left && this.Top >= rec.Top && this.Bottom <= rec.Bottom && this.Right <= rec.Right)
            {
                return true;
            }
            return false;
        }
    }
}
