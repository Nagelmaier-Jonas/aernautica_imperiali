using NUnit.Framework;
namespace aernautica_imperiali.unittest {
    public class PlaneTest {

        [SetUp]
        public void Setup() {
        }
        
        [Test]
        public void TestIsMoveLegal() {
            PlaneFactory factory = new PlaneFactory();
            Plane e = factory.Executioner(new Point(0, 0, 1), 4);
            
            Assert.AreEqual(true, e.IsMoveLegal(new Point(4,0,1)));
            Assert.AreEqual(true, e.IsMoveLegal(new Point(4,2,1)));
            Assert.AreEqual(true, e.IsMoveLegal(new Point(3,0,2)));
            
            e.MoveBehavior.Move(e, new Point(4,0,1), 0);
            e.Speed = 2;
            Assert.IsFalse(e.IsMoveLegal(new Point( 6, 0, 1)));
        }

        [Test]
        public void TestBehaviorChecks() {
            PlaneFactory factory = new PlaneFactory();
            Plane e = factory.Executioner(new Point(0, 0, 1), 1);
            
            e.CheckSpeed();
            Assert.AreEqual(new SpinBehavior().GetType(), e.MoveBehavior.GetType());

            Plane e2 = factory.Executioner(new Point(1, 0, 10), 4);
            Assert.AreEqual(new SpinBehavior().GetType(), e.MoveBehavior.GetType());
        }

        [Test]
        public void TestChangeSpeed() {
            PlaneFactory factory = new PlaneFactory();
            Plane e = factory.Executioner(new Point(0, 0, 1), 4);
            e.ChangeSpeed(2);
            
            Assert.AreEqual(6, e.Speed);
        }
    }
}