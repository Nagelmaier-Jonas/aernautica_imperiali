using System.Collections.Generic;
using NUnit.Framework;

namespace aernautica_imperiali.unittest {
    public class MapTest {
        
        [SetUp]
        public void Setup() {
        }
        
        [Test]
        public void IsPointLegalTest() {
            Point p1 = new Point(14,0,9);
            Point p2 = new Point(13,7,8);
            Point p3 = new Point(15,2,5);
            
            Assert.IsTrue(Map.GetInstance().IsPointLegal(p1));
            Assert.IsTrue(Map.GetInstance().IsPointLegal(p2));
            Assert.IsFalse(Map.GetInstance().IsPointLegal(p3));
        }
        
        [Test]
        public void IsSameTest() {
            PlaneFactory factory = new PlaneFactory();
            Point p = new Point(1,1,1);
            Point p2 = new Point(2,4,5);
            
            GameEngine.GetInstance().Imperialis.Planes.Add(factory.Executioner(p,2));
            
            Assert.IsTrue(Map.GetInstance().IsSame(GameEngine.GetInstance().Imperialis.Planes[0],p));
            Assert.IsFalse(Map.GetInstance().IsSame(GameEngine.GetInstance().Imperialis.Planes[0],p2));
        }
        
        [Test]
        public void GetPlanePointsTest() {
            PlaneFactory factory = new PlaneFactory();
            Point plane1 = new Point(1,1,1);
            Point plane2 = new Point(2,2,1);
            Point plane3 = new Point(13,13,1);
            Point plane4 = new Point(14,14,1);
            
            GameEngine.GetInstance().Imperialis.Planes.Add(factory.Executioner(plane1,2));
            GameEngine.GetInstance().Imperialis.Planes.Add(factory.BlueDevil(plane2,2));
            GameEngine.GetInstance().Imperialis.Planes.Add(factory.BigBurna(plane3,2));
            GameEngine.GetInstance().Imperialis.Planes.Add(factory.GrotBommer(plane4,2));
            
            List<Point> expectedPlanePoints = new List<Point>();
            expectedPlanePoints.Add(plane1);
            expectedPlanePoints.Add(plane2);
            expectedPlanePoints.Add(plane3);
            expectedPlanePoints.Add(plane4);
            
            Assert.AreEqual(expectedPlanePoints,Map.GetInstance().GetPlanePoints());

        }
    }
}