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

            GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
            e.
            
            e.MoveBehavior.Move(e, new Point(6,0,2), 2);
            Assert.AreEqual(6, e.X);
            Assert.AreEqual(2, e.Z);
            
            GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
            
            e.MoveBehavior.Move(e, new Point(8, 1, 2), 2);
            Assert.AreEqual(8, e.X);
            Assert.AreEqual(1, e.Y);
        }
    }
}