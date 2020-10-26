using System;

namespace aernautica_imperiali
{
    public class Dice
    {
        private static Dice instance;
        
        private Random random = new Random();
        private Dice()
        {
            
        }

        public static Dice getInstance()
        {
            return instance;
        }
        
        

        public int Roll()
        {
            return random.Next(1, 7);
        }
    }
}