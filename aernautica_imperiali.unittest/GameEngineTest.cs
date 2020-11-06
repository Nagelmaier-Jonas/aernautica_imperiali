using NUnit.Framework;
using NUnit.Framework.Constraints;

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
        public void TestCheckStructure(){
            PlaneFactory factory = new PlaneFactory();
            GameEngine.GetInstance().Imperialis.Planes.Add(factory.Executioner(new Point(3,3,3),3 ));
            GameEngine.GetInstance().Imperialis.Planes.Add(factory.Hellion(new Point(3,4,3),3 ));
            Assert.AreEqual(2,GameEngine.GetInstance().Imperialis.Planes.Count);
            GameEngine.GetInstance().Imperialis.Planes[0].Structure = 0;
            GameEngine.GetInstance().CheckStructure();
            Assert.AreEqual(1,GameEngine.GetInstance().Imperialis.Planes.Count);

        }

        [Test]
        public void TestPlacePlane(){
            PlaneFactory factory = new PlaneFactory();
            GameEngine.GetInstance().PlacePlane(factory.Vulture(new Point(5,5,5),4 ));
            GameEngine.GetInstance().PlacePlane(factory.Hellion(new Point(2,2,4),4 ));
            GameEngine.GetInstance().PlacePlane(factory.GrotBommer(new Point(13,13,6),4 ));
            GameEngine.GetInstance().PlacePlane(factory.Executioner(new Point(-2,20,7),4 ));
            Assert.AreSame(factory.Vulture(new Point(5,5,5),4 ),GameEngine.GetInstance().Ork.Planes[0]);
            Assert.AreSame(factory.Hellion(new Point(2,2,4),4 ),GameEngine.GetInstance().Imperialis.Planes[0]);
            Assert.AreEqual(1,GameEngine.GetInstance().Imperialis.Planes.Count);
            Assert.AreEqual(1,GameEngine.GetInstance().Ork.Planes.Count);
        }

        [Test]
        public void TestCheckTurns(){
            PlaneFactory factory = new PlaneFactory();
            GameEngine.GetInstance().Imperialis.Planes.Add(factory.Executioner(new Point(2,2,2),2));
            GameEngine.GetInstance().Ork.Planes.Add(factory.BigBurna(new Point(3,2,2),2));
            GameEngine.GetInstance().Imperialis.Planes.Add(factory.Hellion(new Point(2,4,2),2));
            Assert.IsFalse(GameEngine.GetInstance().AllowFire);
            GameEngine.GetInstance().Imperialis.Planes[0].Move(new Point(3,3,3));
            GameEngine.GetInstance().Ork.Planes[0].Move(new Point(2,2,3));
            Assert.AreEqual(2,GameEngine.GetInstance().MoveTurns);
            GameEngine.GetInstance().Imperialis.Planes[1].Move(new Point(4,4,4));
            Assert.IsTrue(GameEngine.GetInstance().AllowFire);
            Assert.AreEqual(0,GameEngine.GetInstance().MoveTurns);
        }

        [Test]
        public void TestEndTurn(){
            PlaneFactory factory = new PlaneFactory();
            GameEngine.GetInstance().Imperialis.Points = 120;
            GameEngine.GetInstance().Imperialis.Planes.Add(factory.Executioner(new Point(2,2,2), 2));
            GameEngine.GetInstance().Imperialis.StartPoints = 0;
            GameEngine.GetInstance().TurnToken = false;
            GameEngine.GetInstance().EndTurn();
            Assert.AreEqual(0,GameEngine.GetInstance().Imperialis.Points);
            Assert.AreEqual(0,GameEngine.GetInstance().Imperialis.Planes.Count);
            Assert.AreEqual(150,GameEngine.GetInstance().Imperialis.StartPoints);
            Assert.IsTrue(GameEngine.GetInstance().TurnToken);
            
            GameEngine.GetInstance().Imperialis.StartPoints = 0;
            GameEngine.GetInstance().TurnToken = false;
            GameEngine.GetInstance().EndTurn();
            Assert.IsTrue(GameEngine.GetInstance().TurnToken);
            Assert.AreEqual(0,GameEngine.GetInstance().Imperialis.StartPoints);
        }
    }
}