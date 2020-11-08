using NUnit.Framework;

namespace aernautica_imperiali.unittest {
    public class MoveBehaviourTest {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void DefaultMoveTest() {
            GameEngine.GetInstance().RestartGame();
            
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(0, 0, 1), 5));

            GameEngine.GetInstance().GetImperialis(0).Move(new Point(3, 0, 1), -2);
            Assert.AreEqual(3, GameEngine.GetInstance().GetImperialis(0).X);

            GameEngine.GetInstance().NextRound();

            GameEngine.GetInstance().GetImperialis(0).Move(new Point(5, 0, 2), 0);
            Assert.AreEqual(5, GameEngine.GetInstance().GetImperialis(0).X);
            Assert.AreEqual(2, GameEngine.GetInstance().GetImperialis(0).Z);

            GameEngine.GetInstance().NextRound();

            GameEngine.GetInstance().GetImperialis(0).Move(new Point(10, 1, 2), 2);
            Assert.AreEqual(10, GameEngine.GetInstance().GetImperialis(0).X);
            Assert.AreEqual(1, GameEngine.GetInstance().GetImperialis(0).Y);
        }
    }
}