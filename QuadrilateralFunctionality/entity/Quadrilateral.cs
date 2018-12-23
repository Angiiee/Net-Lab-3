using System;
using System.Collections.Generic;
using System.Text;

namespace QuadrilateralFunctionality.entity
{
    public class Quadrilateral
    {
        private Point top1;
        private Point top2;
        private Point top3;
        private Point top4;

        public Point Top4 { get => top4; set => top4 = value; }
        public Point Top3 { get => top3; set => top3 = value; }
        public Point Top2 { get => top2; set => top2 = value; }
        public Point Top1 { get => top1; set => top1 = value; }

        public Quadrilateral()
        {
        }

        public Quadrilateral(Point top4, Point top3, Point top2, Point top1)
        {
            Top4 = top4;
            Top3 = top3;
            Top2 = top2;
            Top1 = top1;
        }

        public override bool Equals(object obj)
        {
            var quadrilateral = obj as Quadrilateral;
            return quadrilateral != null &&
                   EqualityComparer<Point>.Default.Equals(Top4, quadrilateral.Top4) &&
                   EqualityComparer<Point>.Default.Equals(Top3, quadrilateral.Top3) &&
                   EqualityComparer<Point>.Default.Equals(Top2, quadrilateral.Top2) &&
                   EqualityComparer<Point>.Default.Equals(Top1, quadrilateral.Top1);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Top4, Top3, Top2, Top1);
        }

        public override string ToString()
        {
            return Top1.ToString() + Top2.ToString() + Top3.ToString() + Top4.ToString();
        }
    }
}
