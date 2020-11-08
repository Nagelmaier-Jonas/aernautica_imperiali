using System.Diagnostics;
using NUnit.Framework;

namespace aernautica_imperiali.unittest {
    public class PlaneTest {
        [SetUp]
        public void Setup() {
            //irgenda schas damit ich pushen kann
        }

        [Test]
        public void TestIsMoveLegal() {
            GameEngine.GetInstance().Imperialis.Planes.Clear();
            GameEngine.GetInstance().Ork.Planes.Clear();
            Plane e = PlaneFactory.Executioner(new Point(0, 0, 1), 4);

            Assert.AreEqual(true, e.IsMoveLegal(new Point(4, 0, 1)));
            Assert.AreEqual(true, e.IsMoveLegal(new Point(4, 2, 1)));
            Assert.AreEqual(true, e.IsMoveLegal(new Point(3, 0, 2)));

            e.Move(new Point(4, 0, 1), 0);
            Assert.IsFalse(e.IsMoveLegal(new Point(8, 0, 1)));
        }

        [Test]
        public void TestIsPointValid() {
            GameEngine.GetInstance().RestartGame();
            
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(0, 0, 1), 4));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(4, 0, 1), 4));
            
            Assert.IsFalse(GameEngine.GetInstance().GetImperialis(0).IsPointValid(new Point(4,0,1)));
            Assert.IsTrue(GameEngine.GetInstance().GetImperialis(1).IsPointValid(new Point(1,0,1)));
        }

        [Test]
        public void TestBehaviorChecks() {
            GameEngine.GetInstance().Imperialis.Planes.Clear();
            GameEngine.GetInstance().Ork.Planes.Clear();
            Plane e = PlaneFactory.Executioner(new Point(0, 0, 1), 1);

            e.CheckSpeed();
            Assert.AreEqual(new SpinBehavior().GetType(), e.MoveBehavior.GetType());

            Plane e2 = PlaneFactory.Executioner(new Point(1, 0, 10), 4);
            e2.CheckHeight();
            Assert.AreEqual(new SpinBehavior().GetType(), e.MoveBehavior.GetType());
        }

        [Test]
        public void TestHitGround() {
            GameEngine.GetInstance().Imperialis.Planes.Clear();
            GameEngine.GetInstance().Ork.Planes.Clear();
            Plane e = PlaneFactory.Executioner(new Point(0, 0, 0), 4);
            e.HitGround();
            
            Assert.AreEqual(0, e.Structure);
            
        }

        [Test]
        public void TestCanFire() {
            GameEngine.GetInstance().RestartGame();
            
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(3, 2, 3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(3,12,3), 4)); 
            
            Assert.IsTrue(GameEngine.GetInstance().GetImperialis(0).CanFire(GameEngine.GetInstance().GetOrk(0), GameEngine.GetInstance().GetImperialis(0).Weapons[0]));
            GameEngine.GetInstance().GetImperialis(0).Weapons[0].Ammo = 0;
            Assert.IsFalse(GameEngine.GetInstance().GetImperialis(0).CanFire(GameEngine.GetInstance().GetOrk(0), GameEngine.GetInstance().GetImperialis(0).Weapons[0]));
        }

        [Test]
        public void TestCheckRange() {
            GameEngine.GetInstance().Imperialis.Planes.Clear();
            GameEngine.GetInstance().Ork.Planes.Clear();
            Plane e = PlaneFactory.Executioner(new Point(0, 0, 1), 4);
            Plane g = PlaneFactory.GrotBommer(new Point(2,0,1), 4);
            Plane g2 = PlaneFactory.GrotBommer(new Point(6,0,1), 4);
            Plane g3 = PlaneFactory.GrotBommer(new Point(9,0,1), 4);
            Plane g4 = PlaneFactory.GrotBommer(new Point(11,0,1), 4);
            
            Assert.AreEqual(ERange.SHORT, e.CheckRange(g));
            Assert.AreEqual(ERange.MEDIUM, e.CheckRange(g2));
            Assert.AreEqual(ERange.LONG, e.CheckRange(g3));
            Assert.AreEqual(ERange.OUTOFRANGE, e.CheckRange(g4));
        }

        [Test]
        public void TestInNorthFireArc() {
            GameEngine.GetInstance().RestartGame();
            
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(4,12,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(4,13,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(4,14,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(3,12,3), 4));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(5,12,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(5,12,4), 4)); 
            
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InNorthFireArc(GameEngine.GetInstance().GetOrk(1), EFireArc.ALLROUND));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InNorthFireArc(GameEngine.GetInstance().GetOrk(4), EFireArc.ALLROUND));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InNorthFireArc(GameEngine.GetInstance().GetOrk(1), EFireArc.FRONT));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(3).InNorthFireArc(GameEngine.GetInstance().GetOrk(0), EFireArc.LEFT));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(4).InNorthFireArc(GameEngine.GetInstance().GetOrk(0), EFireArc.RIGHT));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(2).InNorthFireArc(GameEngine.GetInstance().GetOrk(1), EFireArc.REAR));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(4).InNorthFireArc(GameEngine.GetInstance().GetOrk(5), EFireArc.UP));
            
        }
        
        [Test]
        public void TestInSouthFireArc() {
            GameEngine.GetInstance().RestartGame();
            
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(4,12,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(4,13,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(4,14,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(3,12,3), 4));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(5,12,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(5,12,4), 4)); 
            
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InSouthFireArc(GameEngine.GetInstance().GetOrk(1), EFireArc.ALLROUND));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InSouthFireArc(GameEngine.GetInstance().GetOrk(4), EFireArc.ALLROUND));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(1).InSouthFireArc(GameEngine.GetInstance().GetOrk(0), EFireArc.FRONT));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InSouthFireArc(GameEngine.GetInstance().GetOrk(3), EFireArc.LEFT));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InSouthFireArc(GameEngine.GetInstance().GetOrk(4), EFireArc.RIGHT));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(1).InSouthFireArc(GameEngine.GetInstance().GetOrk(2), EFireArc.REAR));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(4).InSouthFireArc(GameEngine.GetInstance().GetOrk(5), EFireArc.UP));
            
        }
        
        [Test]
        public void TestInWestFireArc() {
            GameEngine.GetInstance().RestartGame();
            
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(4,12,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(4,13,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(4,14,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(3,12,3), 4));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(5,12,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(5,12,4), 4)); 
            
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InWestFireArc(GameEngine.GetInstance().GetOrk(1), EFireArc.ALLROUND));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InWestFireArc(GameEngine.GetInstance().GetOrk(4), EFireArc.ALLROUND));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(4).InWestFireArc(GameEngine.GetInstance().GetOrk(0), EFireArc.FRONT));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InWestFireArc(GameEngine.GetInstance().GetOrk(1), EFireArc.LEFT));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(1).InWestFireArc(GameEngine.GetInstance().GetOrk(0), EFireArc.RIGHT));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InWestFireArc(GameEngine.GetInstance().GetOrk(4), EFireArc.REAR));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(4).InWestFireArc(GameEngine.GetInstance().GetOrk(5), EFireArc.UP));
            
        }
        
        [Test]
        public void TestInEastFireArc() {
            GameEngine.GetInstance().RestartGame();
            
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(4,12,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(4,13,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(4,14,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(3,12,3), 4));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(5,12,3), 4)); 
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(5,12,4), 4)); 
            
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InEastFireArc(GameEngine.GetInstance().GetOrk(1), EFireArc.ALLROUND));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InEastFireArc(GameEngine.GetInstance().GetOrk(4), EFireArc.ALLROUND));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InEastFireArc(GameEngine.GetInstance().GetOrk(4), EFireArc.FRONT));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(1).InEastFireArc(GameEngine.GetInstance().GetOrk(0), EFireArc.LEFT));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(0).InEastFireArc(GameEngine.GetInstance().GetOrk(1), EFireArc.RIGHT));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(4).InEastFireArc(GameEngine.GetInstance().GetOrk(0), EFireArc.REAR));
            Assert.IsTrue(GameEngine.GetInstance().GetOrk(4).InEastFireArc(GameEngine.GetInstance().GetOrk(5), EFireArc.UP));
            
        }

        [Test]
        public void TestSetOrientation() {
            GameEngine.GetInstance().RestartGame();
            
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(3, 2, 3), 4));

            GameEngine.GetInstance().GetImperialis(0).SetOrientation(new Point(4,2,3));
            Assert.AreEqual(EOrientation.EAST, GameEngine.GetInstance().GetImperialis(0).Orientation);
            
            GameEngine.GetInstance().GetImperialis(0).SetOrientation(new Point(2,2,3));
            Assert.AreEqual(EOrientation.WEST, GameEngine.GetInstance().GetImperialis(0).Orientation);
            
            GameEngine.GetInstance().GetImperialis(0).SetOrientation(new Point(3,4,3));
            Assert.AreEqual(EOrientation.NORTH, GameEngine.GetInstance().GetImperialis(0).Orientation);
            
            GameEngine.GetInstance().GetImperialis(0).SetOrientation(new Point(3,1,3));
            Assert.AreEqual(EOrientation.SOUTH, GameEngine.GetInstance().GetImperialis(0).Orientation);
            
            GameEngine.GetInstance().GetImperialis(0).SetOrientation(new Point(4,4,3));
            Assert.AreEqual(EOrientation.NORTH, GameEngine.GetInstance().GetImperialis(0).Orientation);
            
            GameEngine.GetInstance().GetImperialis(0).SetOrientation(new Point(4,1,3));
            Assert.AreEqual(EOrientation.SOUTH, GameEngine.GetInstance().GetImperialis(0).Orientation);
        }

        public void TestChangeSpeed() {
            Plane e = PlaneFactory.Executioner(new Point(0, 0, 1), 4);
            e.ChangeSpeed(2);

            Assert.AreEqual(6, e.Speed);
        }
    }
}