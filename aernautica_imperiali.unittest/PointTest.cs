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
            PlaneFactory factoryp = new PlaneFactory();
            Point planePoint = new Point(1,1,1);
            Plane plane = factoryp.Executioner(planePoint,3);
            Point destination = new Point(4,2,2);

            List<Point> expectedRoute = new List<Point>(new []{new Point(2,2,2),new Point(3,2,2),new Point(4,2,2),});
            expectedRoute.Add(new Point(2, 2, 2));
            expectedRoute.Add(new Point(3,2,2));
            expectedRoute.Add( new Point(4,2,2));
            
            List<Point> route = plane.CalculateRoute(destination);
            
            Assert.AreEqual(expectedRoute,route);
        }
        
    }
}