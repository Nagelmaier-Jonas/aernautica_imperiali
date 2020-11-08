using System;

namespace aernautica_imperiali {
    public class SpinBehavior : IMoveBehavior {
        public void Move(Plane plane, Point destination, int speedChange) {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Logger.GetInstance().Info("You can not move, you're in spinmode");
            plane.CheckSpin();
            GameEngine.GetInstance().CheckTurns();
        }

        public void Fire(Plane plane, Plane target, Weapon weapon) {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Logger.GetInstance().Info("You can not shoot, you're in spinmode");
            plane.ShotsFired = true;
            GameEngine.GetInstance().CheckStructure();
        }
    }
}