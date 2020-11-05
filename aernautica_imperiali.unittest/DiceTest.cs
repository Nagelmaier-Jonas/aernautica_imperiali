using NUnit.Framework;
namespace aernautica_imperiali.unittest {
    public class DiceTest {

        [Test]
        public void SingletonTest() {
            Dice dice = Dice.GetInstance();
            Dice dice2 = Dice.GetInstance();
            
            Assert.AreSame(dice,dice2);
        }
        
        [Test]
        public void Roll() {
            int roll = Dice.GetInstance().Roll();
            
            Assert.IsTrue(roll >= 1 && roll <= 6);
            
        }
    }
}