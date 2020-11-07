using NUnit.Framework;
using NUnit.Framework.Constraints;
using aernautica_imperiali;

namespace aernautica_imperiali.unittest {
    public class GameEngineTest {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void TestSingleton() {
            GameEngine gameEngine = GameEngine.GetInstance();
            GameEngine gameEngine2 = GameEngine.GetInstance();
            Assert.AreSame(gameEngine, gameEngine2);
        }

        [Test]
        public void TestCheckStructure() {
            GameEngine.GetInstance().RestartGame();

            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(3, 1, 3), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Hellion(new Point(3, 2, 3), 3));
            Assert.AreEqual(2, GameEngine.GetInstance().Imperialis.Planes.Count);
            GameEngine.GetInstance().Imperialis.Planes[0].Structure = 0;
            GameEngine.GetInstance().CheckStructure();
            Assert.AreEqual(1, GameEngine.GetInstance().Imperialis.Planes.Count);
        }

        [Test]
        public void TestPlacePlane() {
            GameEngine.GetInstance().RestartGame();

            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(5, 13, 5), 4));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Hellion(new Point(2, 2, 4), 4));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(18, 13, 6), 4));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(-2, 20, 7), 4));
            Assert.AreEqual(PlaneFactory.Vulture(new Point(5, 13, 5), 4), GameEngine.GetInstance().Ork.Planes[0]);
            Assert.AreEqual(PlaneFactory.Hellion(new Point(2, 2, 4), 4), GameEngine.GetInstance().Imperialis.Planes[0]);
            Assert.AreEqual(1, GameEngine.GetInstance().Imperialis.Planes.Count);
            Assert.AreEqual(1, GameEngine.GetInstance().Ork.Planes.Count);
        }

        [Test]
        public void TestCheckTurns() {
            GameEngine.GetInstance().RestartGame();

            GameEngine.GetInstance().Imperialis.Planes.Add(PlaneFactory.Executioner(new Point(2, 2, 2), 2));
            GameEngine.GetInstance().Ork.Planes.Add(PlaneFactory.BigBurna(new Point(3, 12, 2), 2));
            GameEngine.GetInstance().Imperialis.Planes.Add(PlaneFactory.Hellion(new Point(2, 1, 2), 2));
            Assert.IsFalse(GameEngine.GetInstance().AllowFire);
            GameEngine.GetInstance().Imperialis.Planes[0].Move(new Point(3, 3, 3));
            GameEngine.GetInstance().Ork.Planes[0].Move(new Point(3, 11, 3));
            Assert.AreEqual(2, GameEngine.GetInstance().MoveTurns);
            GameEngine.GetInstance().Imperialis.Planes[1].Move(new Point(3, 1, 3));
            Assert.IsTrue(GameEngine.GetInstance().AllowFire);
            Assert.AreEqual(0, GameEngine.GetInstance().MoveTurns);
        }

        [Test]
        public void TestEndTurn() {
            GameEngine.GetInstance().RestartGame();

            GameEngine.GetInstance().Imperialis.Points = 120;
            GameEngine.GetInstance().Imperialis.Planes.Add(PlaneFactory.Executioner(new Point(2, 2, 2), 2));
            GameEngine.GetInstance().Imperialis.StartPoints = 0;
            GameEngine.GetInstance().TurnToken = false;
            GameEngine.GetInstance().EndTurn();
            Assert.AreEqual(0, GameEngine.GetInstance().Imperialis.Points);
            Assert.AreEqual(0, GameEngine.GetInstance().Imperialis.Planes.Count);
            Assert.AreEqual(150, GameEngine.GetInstance().Imperialis.StartPoints);
            Assert.AreEqual(true, GameEngine.GetInstance().TurnToken);

            GameEngine.GetInstance().Imperialis.StartPoints = 0;
            GameEngine.GetInstance().TurnToken = false;
            GameEngine.GetInstance().EndTurn();
            Assert.AreEqual(true, GameEngine.GetInstance().TurnToken);
            Assert.AreEqual(0, GameEngine.GetInstance().Imperialis.StartPoints);
        }
    }
}