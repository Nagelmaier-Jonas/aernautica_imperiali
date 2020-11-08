using System;

namespace aernautica_imperiali {
    public class DefaultMoveBehavior : IMoveBehavior {
       
        public void Move(Plane plane, Point destination, int speedChange) {
            plane.SetOrientation(destination);
            plane.HasMoved = true;
            plane.X = destination.X;
            plane.Y = destination.Y;
            plane.Z = destination.Z;
            GameEngine.GetInstance().CheckTurns();
        }
        public void Fire(Plane plane, Plane target, Weapon weapon) {
            if (plane.CanFire(target, weapon) && !plane.ShotsFired && GameEngine.GetInstance().AllowFire) {
                ERange range = plane.CheckRange(target);
                for (int i = 0; i < weapon.Firepower[range]; i++) {
                    if (plane.DoDamage(target, weapon)) {
                        GameEngine.GetInstance().CheckStructure();
                        break;
                    }
                }
                if (weapon.Ammo != -1) {
                    weapon.Ammo--;
                }
                plane.ShotsFired = true;
            }
            else {
                Logger.GetInstance().Info("Fire Checks failed");
            }
        }
    }
}