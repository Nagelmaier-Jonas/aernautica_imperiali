using System.Collections.Generic;
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
            GameEngine.GetInstance().GetImperialis(0).Structure = 0;
            GameEngine.GetInstance().CheckStructure();
            Assert.AreEqual(1, GameEngine.GetInstance().Imperialis.Planes.Count);
        }

        [Test]
        public void TestPlacePlane() {
            GameEngine.GetInstance().RestartGame();

            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(5, 13, 3), 4));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Hellion(new Point(2, 2, 4), 4));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(18, 13, 6), 4));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(-2, 20, 7), 4));

            Assert.AreEqual(PlaneFactory.Vulture(new Point(5, 13, 3), 4), GameEngine.GetInstance().GetOrk(0));
            Assert.AreEqual(PlaneFactory.Hellion(new Point(2, 2, 4), 4), GameEngine.GetInstance().GetImperialis(0));
            Assert.AreEqual(1, GameEngine.GetInstance().Imperialis.Planes.Count);
            Assert.AreEqual(1, GameEngine.GetInstance().Ork.Planes.Count);
        }

        [Test]
        public void TestCheckTurns() {
            GameEngine.GetInstance().RestartGame();

            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(2, 2, 2), 2));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.BigBurna(new Point(3, 12, 2), 2));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Hellion(new Point(2, 1, 2), 2));
            Assert.IsFalse(GameEngine.GetInstance().AllowFire);
            GameEngine.GetInstance().GetImperialis(0).Move(new Point(3, 3, 3),0);
            GameEngine.GetInstance().GetOrk(0).Move(new Point(3, 11, 3),0);
            Assert.AreEqual(2, GameEngine.GetInstance().MoveTurns);
            GameEngine.GetInstance().GetImperialis(1).Move(new Point(3, 1, 3),0);
            Assert.IsTrue(GameEngine.GetInstance().AllowFire);
            Assert.AreEqual(0, GameEngine.GetInstance().MoveTurns);
        }

        [Test]
        public void TestEndTurn() {
            GameEngine.GetInstance().RestartGame();
            
            GameEngine.GetInstance().Imperialis.Planes.Add(PlaneFactory.Executioner(new Point(2, 2, 2), 2));
            GameEngine.GetInstance().TurnToken = false;
            GameEngine.GetInstance().AllowFire = true;
            GameEngine.GetInstance().MoveTurns = 3;
            GameEngine.GetInstance().FireTurns = 3;
            GameEngine.GetInstance().EndTurn();
            Assert.IsTrue(GameEngine.GetInstance().TurnToken);
            Assert.IsFalse(GameEngine.GetInstance().AllowFire);
            Assert.AreEqual(0,GameEngine.GetInstance().MoveTurns);
            Assert.AreEqual(0,GameEngine.GetInstance().FireTurns);

            GameEngine.GetInstance().Imperialis.StartPoints = 0;
            GameEngine.GetInstance().TurnToken = false;
            GameEngine.GetInstance().EndTurn();
            Assert.AreEqual(true, GameEngine.GetInstance().TurnToken);
            Assert.AreEqual(0, GameEngine.GetInstance().Imperialis.StartPoints);
        }

        [Test]
        public void TestHasWon() {
            GameEngine.GetInstance().RestartGame();

            GameEngine.GetInstance().Imperialis.Points = 126;
            Assert.AreEqual(GameEngine.GetInstance().Imperialis,GameEngine.GetInstance().HasWon());
        }

        [Test]
        public void TestGetAllPlanes() {
            GameEngine.GetInstance().RestartGame();
            
            GameEngine.GetInstance().Imperialis.Planes.Add(PlaneFactory.Executioner(new Point(1,1,1),3));
            GameEngine.GetInstance().Ork.Planes.Add(PlaneFactory.GrotBommer(new Point(12,12,1),3));

            Assert.AreEqual(GameEngine.GetInstance().GetAllPlanes().Count, 2);
            Assert.AreEqual(GameEngine.GetInstance().GetImperialis(0), GameEngine.GetInstance().GetAllPlanes()[0]);
            Assert.AreEqual(GameEngine.GetInstance().GetOrk(0), GameEngine.GetInstance().GetAllPlanes()[1]);
        }

        [Test]
        public void TestGetPlanes() {
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(1,1,1),3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(1,1,1),3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(1,1,1),3));
            
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(12,12,1),3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(12,12,1),3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(12,12,1),3));
            
            Assert.AreSame(GameEngine.GetInstance().Imperialis.Planes[2], GameEngine.GetInstance().GetImperialis(2));
            Assert.AreSame(GameEngine.GetInstance().Ork.Planes[1], GameEngine.GetInstance().GetOrk(1));
        }
    }
}