using System;

namespace aernautica_imperiali
{
    public class Dice
    {
        private static Dice instance;

        private Dice()
        {
            
        }

        public static Dice getInstance()
        {
            return instance;
        }
        
        Random random = new Random();

        public int Roll()
        {
            return random.Next(1, 7);
        }
    }
}