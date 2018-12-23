using QuadrilateralFunctionality.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadrilateralFunctionality.logic
{

    /*
     * 10. Определить класс Четырехугольник на плоскости, вершины которого имеют тип Точка. 
     * Определить площадь и периметр четырехугольника. Создать массив/список/множество объектов и 
     * подсчитать количество четырехугольников разного типа (квадрат, прямоугольник, ромб, произвольный). 
     * Определить для каждой группы наибольший и наименьший по площади (периметру) объект. 
     */

    public class ProcessQuadrilateral
    {
        public static double FindSquare(Quadrilateral item)
        {
            double p = FindPerimetr(item) / 2;
            double ab = FindSideLength(item.Top1, item.Top2);
            double bc = FindSideLength(item.Top2, item.Top3);
            double cd = FindSideLength(item.Top3, item.Top4);
            double ad = FindSideLength(item.Top1, item.Top4);
            double sqr = Math.Sqrt((p - ab) * (p - bc) * (p - cd) * (p - ad));
            return sqr;
        }

        public static double FindPerimetr(Quadrilateral item)
        {
            double ab = FindSideLength(item.Top1, item.Top2);
            double bc = FindSideLength(item.Top2, item.Top3);
            double cd = FindSideLength(item.Top3, item.Top4);
            double ad = FindSideLength(item.Top1, item.Top4);
            return ab + bc + cd + ad;
        }

        public static double FindSideLength(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        public static Boolean IsQuadrate(Quadrilateral item)
        {
            double ab = FindSideLength(item.Top1, item.Top2);
            double bc = FindSideLength(item.Top2, item.Top3);
            double cd = FindSideLength(item.Top3, item.Top4);
            double ad = FindSideLength(item.Top1, item.Top4);
            double ac = FindSideLength(item.Top1, item.Top3);
            decimal tmpSide = (decimal)(ab * ab + bc * bc);
            decimal tmpDiagonal = (decimal)(ac * ac);
            if (ab == bc && bc == cd && cd == ad && ad == ab && tmpSide == tmpDiagonal)
            {
                return true;
            }
            return false;
        }

        public static Boolean IsRhombus(Quadrilateral item)
        {
            double ab = FindSideLength(item.Top1, item.Top2);
            double bc = FindSideLength(item.Top2, item.Top3);
            double cd = FindSideLength(item.Top3, item.Top4);
            double ad = FindSideLength(item.Top1, item.Top4);
            double ac = FindSideLength(item.Top1, item.Top3);
            decimal tmpSide = (decimal)(ab * ab + bc * bc);
            decimal tmpDiagonal = (decimal)(ac * ac);
            if (ab == bc && bc == cd && cd == ad && ad == ab && tmpSide != tmpDiagonal)
            {
                return true;
            }
            return false;
        }

        public static Boolean IsRectangle(Quadrilateral item)
        {
            double ab = FindSideLength(item.Top1, item.Top2);
            double bc = FindSideLength(item.Top2, item.Top3);
            double cd = FindSideLength(item.Top3, item.Top4);
            double ad = FindSideLength(item.Top1, item.Top4);
            if (((ab == cd && bc == ad) || (ab == bc && cd == ad)) && ab * bc == FindSquare(item))
            {
                return true;
            }
            return false;
        }

        public static List<Quadrilateral> FindQuadrilateralMaxSquare(List<Quadrilateral> allItems)
        {
            List<Quadrilateral> result = new List<Quadrilateral>();
            double maxValue = 0;
            foreach (Quadrilateral item in allItems)
            {
                if (FindSquare(item) > maxValue)
                {
                    maxValue = FindSquare(item);
                }
            }
            foreach (Quadrilateral item in allItems)
            {
                if (FindSquare(item) == maxValue)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<Quadrilateral> FindQuadrilateralMaxPerimeter(List<Quadrilateral> allItems)
        {
            List<Quadrilateral> result = new List<Quadrilateral>();
            double maxValue = 0;
            foreach (Quadrilateral item in allItems)
            {
                if (FindSquare(item) > maxValue)
                {
                    maxValue = FindPerimetr(item);
                }
            }
            foreach (Quadrilateral item in allItems)
            {
                if (FindPerimetr(item) == maxValue)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<Quadrilateral> FindQuadrateMaxPerimeter(List<Quadrilateral> allItems)
        {
            List<Quadrilateral> maxParam = new List<Quadrilateral>();
            List<Quadrilateral> selectedItems = new List<Quadrilateral>();
            foreach (Quadrilateral item in allItems)
            {
                if (IsQuadrate(item))
                {
                    selectedItems.Add(item);
                }
            }
            maxParam = FindQuadrilateralMaxPerimeter(selectedItems);
            return maxParam;
        }

        public static List<Quadrilateral> FindRhombusMaxPerimeter(List<Quadrilateral> allItems)
        {
            List<Quadrilateral> maxParam = new List<Quadrilateral>(); List<Quadrilateral> selectedItems = new List<Quadrilateral>();
            foreach (Quadrilateral item in allItems)
            {
                if (IsRhombus(item))
                {
                    selectedItems.Add(item);
                }
            }
            maxParam = FindQuadrilateralMaxPerimeter(selectedItems);
            return maxParam;
        }

        public static List<Quadrilateral> FindRectangleMaxPerimeter(List<Quadrilateral> allItems)
        {
            List<Quadrilateral> maxParam = new List<Quadrilateral>();
            List<Quadrilateral> selectedItems = new List<Quadrilateral>();
            foreach (Quadrilateral item in allItems)
            {
                if (IsRectangle(item))
                {
                    selectedItems.Add(item);
                }
            }
            maxParam = FindQuadrilateralMaxPerimeter(selectedItems);
            return maxParam;
        }

        public static List<Quadrilateral> FindRandomQuadrilateralMaxPerimeter(List<Quadrilateral> allItems)
        {
            List<Quadrilateral> maxParam = new List<Quadrilateral>();
            List<Quadrilateral> selectedItems = new List<Quadrilateral>();
            foreach (Quadrilateral item in allItems)
            {
                if (!IsQuadrate(item) && !IsRectangle(item) && !IsRhombus(item))
                {
                    selectedItems.Add(item);
                }
            }
            maxParam = FindQuadrilateralMaxPerimeter(selectedItems);
            return maxParam;
        }

        public static List<Quadrilateral> FindQuadrateMaxSquare(List<Quadrilateral> allItems)
        {
            List<Quadrilateral> maxParam = new List<Quadrilateral>();
            List<Quadrilateral> selectedItems = new List<Quadrilateral>();
            foreach (Quadrilateral item in allItems)
            {
                if (IsQuadrate(item))
                {
                    selectedItems.Add(item);
                }
            }
            maxParam = FindQuadrilateralMaxSquare(selectedItems);
            return maxParam;
        }

        public static List<Quadrilateral> FindRhombusMaxSquare(List<Quadrilateral> allItems)
        {
            List<Quadrilateral> maxParam = new List<Quadrilateral>();
            List<Quadrilateral> selectedItems = new List<Quadrilateral>();
            foreach (Quadrilateral item in allItems)
            {
                if (IsRhombus(item))
                {
                    selectedItems.Add(item);
                }
            }
            maxParam = FindQuadrilateralMaxSquare(selectedItems);
            return maxParam;
        }

        public static List<Quadrilateral> FindRectangleMaxSquare(List<Quadrilateral> allItems)
        {
            List<Quadrilateral> maxParam = new List<Quadrilateral>();
            List<Quadrilateral> selectedItems = new List<Quadrilateral>();
            foreach (Quadrilateral item in allItems)
            {
                if (IsRectangle(item))
                {
                    selectedItems.Add(item);
                }
            }
            maxParam = FindQuadrilateralMaxSquare(selectedItems);
            return maxParam;
        }

        public static List<Quadrilateral> FindRandomQuadrilateralMaxSquare(List<Quadrilateral> allItems)
        {
            List<Quadrilateral> maxParam = new List<Quadrilateral>();
            List<Quadrilateral> selectedItems = new List<Quadrilateral>();
            foreach (Quadrilateral item in allItems)
            {
                if (!IsQuadrate(item) && !IsRectangle(item) && !IsRhombus(item))
                {
                    selectedItems.Add(item);
                }
            }
            maxParam = FindQuadrilateralMaxSquare(selectedItems);
            return maxParam;
        }

    }
}
