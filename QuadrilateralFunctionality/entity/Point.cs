using System;

namespace QuadrilateralFunctionality.entity
{
    public class Point
    {
        private int x;
        private int y;

        public int Y { get => y; set => y = value; }
        public int X { get => x; set => x = value; }

        public Point()
        {
        }

        public Point(int y, int x)
        {
            Y = y;
            X = x;
        }

        public override bool Equals(object obj)
        {
            var point = obj as Point;
            return point != null &&
                   Y == point.Y &&
                   X == point.X;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Y, X);
        }

        public override string ToString()
        {
            return "Point: x = " + X + ", y = " + Y;
        }
    }
}
