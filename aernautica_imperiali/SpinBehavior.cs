using System;

namespace aernautica_imperiali{
    public class SpinBehavior : IMoveBehavior{
        public void Move(Plane plane, Point destination) {
            plane.Z--;
            Logger.GetInstance().Info("Shit happens! (Spin)");
        }
    }
}