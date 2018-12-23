using NUnit.Framework;
using QuadrilateralFunctionality.entity;
using QuadrilateralFunctionality.logic;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private List<Quadrilateral> items;

        [SetUp]
        public void Setup()
        {
            items = new List<Quadrilateral>();
            items.Add(new Quadrilateral(new Point(2, 3), new Point(2, 21), new Point(22, 21), new Point(22, 3))); // rectangle
            items.Add(new Quadrilateral(new Point(5, 10), new Point(5, 16), new Point(11, 16), new Point(11, 10))); // IsQuadrate true
            items.Add(new Quadrilateral(new Point(10, 9), new Point(10, 12), new Point(13, 12), new Point(13, 9))); // IsQuadrate true
            items.Add(new Quadrilateral(new Point(5, 4), new Point(4, 7), new Point(12, 7), new Point(9, 4))); // non of all
            items.Add(new Quadrilateral(new Point(15, 17), new Point(15, 20), new Point(21, 20), new Point(21, 17))); // rectangle
            items.Add(new Quadrilateral(new Point(18, 6), new Point(16, 10), new Point(18, 14), new Point(20, 10))); // IsRhombus
        }

        [Test]
        public void TestFindQuadrateMaxSquare()
        {
            Assert.AreEqual(new Quadrilateral(new Point(5, 10), new Point(5, 16), new Point(11, 16), new Point(11, 10)), ProcessQuadrilateral.FindQuadrateMaxSquare(items)[0]);
        }

        [Test]
        public void TestIsQuadrate()
        {
            Assert.IsTrue(ProcessQuadrilateral.IsQuadrate(new Quadrilateral(new Point(5, 10), new Point(5, 16), new Point(11, 16), new Point(11, 10))));
            Assert.IsTrue(ProcessQuadrilateral.IsQuadrate(new Quadrilateral(new Point(10, 9), new Point(10, 12), new Point(13, 12), new Point(13, 9))));
            Assert.IsFalse(ProcessQuadrilateral.IsQuadrate(new Quadrilateral(new Point(18, 6), new Point(16, 10), new Point(18, 14), new Point(20, 10))));
            Assert.IsFalse(ProcessQuadrilateral.IsQuadrate(new Quadrilateral(new Point(5, 4), new Point(4, 7), new Point(12, 7), new Point(9, 4))));
        }

        [Test]
        public void TestIsRhombus()
        {
            Assert.IsTrue(ProcessQuadrilateral.IsRhombus(new Quadrilateral(new Point(18, 6), new Point(16, 10), new Point(18, 14), new Point(20, 10))));
            Assert.IsFalse(ProcessQuadrilateral.IsRhombus(new Quadrilateral(new Point(5, 4), new Point(4, 7), new Point(12, 7), new Point(9, 4))));
        }

        [Test]
        public void TestIsRectangle()
        {
            Assert.IsTrue(ProcessQuadrilateral.IsRectangle(new Quadrilateral(new Point(5, 10), new Point(5, 16), new Point(11, 16), new Point(11, 10))));
            Assert.IsFalse(ProcessQuadrilateral.IsRectangle(new Quadrilateral(new Point(5, 4), new Point(4, 7), new Point(12, 7), new Point(9, 4))));
        }

        [Test]
        public void TestFindRandomQuadrilateralMaxSquare()
        {
            Assert.AreEqual(new Quadrilateral(new Point(5, 4), new Point(4, 7), new Point(12, 7), new Point(9, 4)), ProcessQuadrilateral.FindRandomQuadrilateralMaxSquare(items)[0]);
        }
    }
}