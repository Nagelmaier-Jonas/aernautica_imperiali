using NUnit.Framework;
using aernautica_imperiali;

namespace aernautica_imperiali.unittest {
    public class GameEngineTest {
        
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void TestSingleton(){
            GameEngine gameEngine = GameEngine.GetInstance();
            GameEngine gameEngine2 = GameEngine.GetInstance();
            Assert.AreSame(gameEngine,gameEngine2);
        }
        
        [Test]
        public void TestCheckStructure() {
            PlaneFactory factory = new PlaneFactory();
            GameEngine.GetInstance().PlacePlane(factory.Executioner(new Point(3,3,3), 3));
            GameEngine.GetInstance().Imperialis.Planes[0].Structure = 0;
            Assert.AreEqual(0,GameEngine.GetInstance().Imperialis.Planes.Count);
        }
        
        [Test]
        public void TestPlacePlane(){
            
        }
        
        [Test]
        public void Test(){
            
        }
        
        [Test]
        public void Test(){
            
        }
        
        [Test]
        public void Test(){
            
        }
        
        [Test]
        public void Test(){
            
        }
        
        [Test]
        public void Test(){
            
        }
    }
}