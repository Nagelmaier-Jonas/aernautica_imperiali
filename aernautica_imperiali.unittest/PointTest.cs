using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace aernautica_imperiali.unittest {
    public class PointTest {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void CalculateRouteTest() {
            Point planePoint = new Point(1, 1, 1);
            Plane plane = PlaneFactory.Executioner(planePoint, 3);
            Point destination = new Point(5, 2, 3);

            List<Point> expectedRoute = new List<Point>(new[]
                {new Point(2, 2, 2), new Point(3, 2, 3), new Point(4, 2, 3), new Point(5, 2, 3)});

            List<Point> route = plane.CalculateRoute(destination);

            Assert.AreEqual(expectedRoute, route);
        }

        [Test]
        public void CalculateRouteTest_Helicopter() {
            Point planePoint = new Point(1, 1, 1);
            Plane plane = PlaneFactory.Executioner(planePoint, 3);
            Point destination = new Point(1, 1, 3);

            List<Point> expectedRoute = new List<Point>(new[] {new Point(1, 1, 2), new Point(1, 1, 3)});

            List<Point> route = plane.CalculateRoute(destination);

            Assert.AreNotEqual(expectedRoute, route);
        }
        
    }
}