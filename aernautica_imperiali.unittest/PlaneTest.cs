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
            GameEngine.GetInstance().Imperialis.Planes.Clear();
            GameEngine.GetInstance().Ork.Planes.Clear();
            
            Plane e = PlaneFactory.Executioner(new Point(0, 0, 1), 4);
            Plane e2 = PlaneFactory.Executioner(new Point(4, 0, 1), 4);
            Assert.IsFalse(e.IsPointValid(new Point(4,0,1)));
            Assert.IsTrue(e.IsPointValid(new Point(1,0,1)));
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
            GameEngine.GetInstance().Imperialis.Planes.Clear();
            GameEngine.GetInstance().Ork.Planes.Clear();
            Plane e = PlaneFactory.Executioner(new Point(0, 0, 1), 4);
            Plane g = PlaneFactory.GrotBommer(new Point(6,0,1), 4);
            
            Assert.IsTrue(e.CanFire(g, e.Weapons[0]));
            e.Weapons[0].Ammo = 0;
            Assert.IsFalse(e.CanFire(g, e.Weapons[0]));
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
            GameEngine.GetInstance().Imperialis.Planes.Clear();
            GameEngine.GetInstance().Ork.Planes.Clear();
            Plane e = PlaneFactory.Executioner(new Point(3, 3, 1), 4);
            Plane gall = PlaneFactory.GrotBommer(new Point(4,4,1), 4);
            Plane gfront = PlaneFactory.GrotBommer(new Point(3,4,1), 4);
            Plane gleft = PlaneFactory.GrotBommer(new Point(4,3,1), 4);
            Plane gright = PlaneFactory.GrotBommer(new Point(2,3,1), 4);
            Plane grear = PlaneFactory.GrotBommer(new Point(3,2,1), 4);
            Plane gup = PlaneFactory.GrotBommer(new Point(3,4,2), 4);
            
            Assert.IsTrue(e.InNorthFireArc(gall, EFireArc.ALLROUND));
            Assert.IsTrue(e.InNorthFireArc(gfront, EFireArc.FRONT));
            Assert.IsTrue(e.InNorthFireArc(gleft, EFireArc.LEFT));
            Assert.IsTrue(e.InNorthFireArc(gright, EFireArc.RIGHT));
            Assert.IsTrue(e.InNorthFireArc(grear, EFireArc.REAR));
            Assert.IsTrue(e.InNorthFireArc(gup, EFireArc.UP));
            
        }
        
        [Test]
        public void TestInSouthFireArc() {
            GameEngine.GetInstance().Imperialis.Planes.Clear();
            GameEngine.GetInstance().Ork.Planes.Clear();
            Plane e = PlaneFactory.Executioner(new Point(3, 3, 1), 4);
            Plane gall = PlaneFactory.GrotBommer(new Point(4,4,1), 4);
            Plane gfront = PlaneFactory.GrotBommer(new Point(3,2,1), 4);
            Plane gleft = PlaneFactory.GrotBommer(new Point(2,3,1), 4);
            Plane gright = PlaneFactory.GrotBommer(new Point(4,3,1), 4);
            Plane grear = PlaneFactory.GrotBommer(new Point(2,4,1), 4);
            Plane gup = PlaneFactory.GrotBommer(new Point(3,4,2), 4);
            
            Assert.IsTrue(e.InSouthFireArc(gall, EFireArc.ALLROUND));
            Assert.IsTrue(e.InSouthFireArc(gfront, EFireArc.FRONT));
            Assert.IsTrue(e.InSouthFireArc(gleft, EFireArc.LEFT));
            Assert.IsTrue(e.InSouthFireArc(gright, EFireArc.RIGHT));
            Assert.IsTrue(e.InSouthFireArc(grear, EFireArc.REAR));
            Assert.IsTrue(e.InSouthFireArc(gup, EFireArc.UP));
            
        }
        
        [Test]
        public void TestInWestFireArc() {
            GameEngine.GetInstance().Imperialis.Planes.Clear();
            GameEngine.GetInstance().Ork.Planes.Clear();
            Plane e = PlaneFactory.Executioner(new Point(3, 3, 1), 4);
            Plane gall = PlaneFactory.GrotBommer(new Point(4,4,1), 4);
            Plane gfront = PlaneFactory.GrotBommer(new Point(2,3,1), 4);
            Plane gleft = PlaneFactory.GrotBommer(new Point(3,4,1), 4);
            Plane gright = PlaneFactory.GrotBommer(new Point(3,2,1), 4);
            Plane grear = PlaneFactory.GrotBommer(new Point(4,3,1), 4);
            Plane gup = PlaneFactory.GrotBommer(new Point(3,4,2), 4);
            
            Assert.IsTrue(e.InWestFireArc(gall, EFireArc.ALLROUND));
            Assert.IsTrue(e.InWestFireArc(gfront, EFireArc.FRONT));
            Assert.IsTrue(e.InWestFireArc(gleft, EFireArc.LEFT));
            Assert.IsTrue(e.InWestFireArc(gright, EFireArc.RIGHT));
            Assert.IsTrue(e.InWestFireArc(grear, EFireArc.REAR));
            Assert.IsTrue(e.InWestFireArc(gup, EFireArc.UP));
            
        }
        
        [Test]
        public void TestInEastFireArc() {
            GameEngine.GetInstance().Imperialis.Planes.Clear();
            GameEngine.GetInstance().Ork.Planes.Clear();
            Plane e = PlaneFactory.Executioner(new Point(3, 3, 1), 4);
            Plane gall = PlaneFactory.GrotBommer(new Point(4,4,1), 4);
            Plane gfront = PlaneFactory.GrotBommer(new Point(4,3,1), 4);
            Plane gleft = PlaneFactory.GrotBommer(new Point(3,2,1), 4);
            Plane gright = PlaneFactory.GrotBommer(new Point(3,4,1), 4);
            Plane grear = PlaneFactory.GrotBommer(new Point(2,3,1), 4);
            Plane gup = PlaneFactory.GrotBommer(new Point(3,4,2), 4);
            
            Assert.IsTrue(e.InEastFireArc(gall, EFireArc.ALLROUND));
            Assert.IsTrue(e.InEastFireArc(gfront, EFireArc.FRONT));
            Assert.IsTrue(e.InEastFireArc(gleft, EFireArc.LEFT));
            Assert.IsTrue(e.InEastFireArc(gright, EFireArc.RIGHT));
            Assert.IsTrue(e.InEastFireArc(grear, EFireArc.REAR));
            Assert.IsTrue(e.InEastFireArc(gup, EFireArc.UP));
            
        }

        [Test]
        public void TestSetOrientation() {
            GameEngine.GetInstance().Imperialis.Planes.Clear();
            GameEngine.GetInstance().Ork.Planes.Clear();
            Plane e = PlaneFactory.Executioner(new Point(3, 3, 1), 4);
            
            e.SetOrientation(new Point(4,3,1));
            Assert.AreEqual(EOrientation.EAST, e.Orientation);
            
            e.SetOrientation(new Point(2,3,1));
            Assert.AreEqual(EOrientation.WEST, e.Orientation);
            
            e.SetOrientation(new Point(3,4,1));
            Assert.AreEqual(EOrientation.NORTH, e.Orientation);
            
            e.SetOrientation(new Point(3,2,1));
            Assert.AreEqual(EOrientation.SOUTH, e.Orientation);
            
            e.SetOrientation(new Point(4,4,1));
            Assert.AreEqual(EOrientation.NORTH, e.Orientation);
            
            e.SetOrientation(new Point(4,2,1));
            Assert.AreEqual(EOrientation.SOUTH, e.Orientation);
        }

        public void TestChangeSpeed() {
            Plane e = PlaneFactory.Executioner(new Point(0, 0, 1), 4);
            e.ChangeSpeed(2);

            Assert.AreEqual(6, e.Speed);
        }
    }
}