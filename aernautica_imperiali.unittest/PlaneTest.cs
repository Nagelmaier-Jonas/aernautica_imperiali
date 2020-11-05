using NUnit.Framework;
namespace aernautica_imperiali.unittest {
    public class PlaneTest {

        [SetUp]
        public void Setup() {
        }
        
        [Test]
        public void TestIsMoveLegal() {
            PlaneFactory factory = new PlaneFactory();
            Plane e = factory.GrotBommer(new Point(0, 0, 1), 4);
            
            Assert.AreEqual(true, e.IsMoveLegal(new Point(4,0,1)));
            //Assert.AreEqual(true, e.IsMoveLegal(new Point(4,2,1)));
        }

        [Test]
        public void TestCheckSpin() {
            PlaneFactory factory = new PlaneFactory();
            Plane e = factory.Executioner(new Point(0, 0, 1), 1);
            e.CheckSpin();
            
            //Assert.AreEqual(new SpinBehavior(), e.MoveBehavior);
        }
    }
}