using System.Numerics;
using NUnit.Framework;
namespace aernautica_imperiali.unittest {
    public class PlaneTest {

        [Test]
        public void TestIsMoveLegal() {
            PlaneFactory factory = new PlaneFactory();
            Plane e = factory.Executioner(new Point(0, 0, 0), 2);
            
            Assert.AreEqual(true, e.IsMoveLegal(new Point(2,0,0)));
        }

        public void TestCheckSpin() {
            
        }
    }
}