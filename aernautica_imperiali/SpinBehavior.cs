using System;

namespace aernautica_imperiali{
    public class SpinBehavior : IMoveBehavior{
        public void Move(Plane plane, Point destination, int speedChange) {
            Logger.GetInstance().Info("You can not move, you're in spinmode");
        }

        public void Fire(Plane plane, Plane target, Weapon weapon) {
            Logger.GetInstance().Info("You can not shoot, you're in spinmode");
        }
    }
}