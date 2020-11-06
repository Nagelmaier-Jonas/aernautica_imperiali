using NUnit.Framework;

namespace aernautica_imperiali.unittest {
    public class MoveBehaviourTest {
        
        [SetUp]
        public void Setup() {
        }
        
        [Test]
        public void DefaultMoveTest() {
            PlaneFactory pfactory = new PlaneFactory();
            Plane e = pfactory.Executioner(new Point(0, 0, 1), 5);
            GameEngine.GetInstance().PlacePlane(e);
            e.MoveBehavior.Move(e, new Point(5,0,1), 0);
            
            Assert.AreEqual(5, e.X);
        }
    }
}