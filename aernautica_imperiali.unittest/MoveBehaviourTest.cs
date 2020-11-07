using NUnit.Framework;

namespace aernautica_imperiali.unittest {
    public class MoveBehaviourTest {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void DefaultMoveTest() {
            GameEngine.GetInstance().RestartGame();
            Plane e = PlaneFactory.Executioner(new Point(0, 0, 1), 5);
            GameEngine.GetInstance().PlacePlane(e);

            e.MoveBehavior.Move(e, new Point(3, 0, 1), -2);
            Assert.AreEqual(3, e.X);

            GameEngine.GetInstance().NextRound();

            e.MoveBehavior.Move(e, new Point(5, 0, 2), 0);
            Assert.AreEqual(5, e.X);
            Assert.AreEqual(2, e.Z);

            GameEngine.GetInstance().NextRound();

            e.MoveBehavior.Move(e, new Point(10, 1, 2), 2);
            Assert.AreEqual(10, e.X);
            Assert.AreEqual(1, e.Y);
        }
    }
}