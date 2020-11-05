using System.Numerics;
using NUnit.Framework;
namespace aernautica_imperiali.unittest {
    public class PlaneTest {

        [Test]
        public void TestIsMoveLegal() {
            PlaneFactory factory = new PlaneFactory();
            factory.Executioner(new Point(0, 0, 0), 2);
            
        }
    }
}