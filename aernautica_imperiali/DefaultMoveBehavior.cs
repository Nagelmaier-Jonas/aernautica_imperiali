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
           // Logger.GetInstance().Info("ShotsFired:" + plane.ShotsFired + "AllowFire: " + GameEngine.GetInstance().AllowFire);
            if (plane.CanFire(target, weapon) && !plane.ShotsFired && GameEngine.GetInstance().AllowFire) {
                ERange range = plane.CheckRange(target);
                switch (range) {
                    case ERange.SHORT:
                        for (int i = 0; i < weapon.Firepower[ERange.SHORT]; i++) {
                            if (plane.DoDamage(target, weapon)) {
                                GameEngine.GetInstance().CheckStructure();
                                break;
                            }
                        }

                        break;
                    case ERange.MEDIUM:
                        for (int i = 0; i < weapon.Firepower[ERange.MEDIUM]; i++) {
                            if (plane.DoDamage(target, weapon)) {
                                GameEngine.GetInstance().CheckStructure();
                                break;
                            }
                        }

                        break;
                    case ERange.LONG:
                        for (int i = 0; i < weapon.Firepower[ERange.LONG]; i++) {
                            if (plane.DoDamage(target, weapon)) {
                                GameEngine.GetInstance().CheckStructure();
                                break;
                            }
                        }
                        break;
                    case ERange.OUTOFRANGE:
                        Logger.GetInstance().Info("Target is out of Range");
                        break;
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