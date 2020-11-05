using System;

namespace aernautica_imperiali{
    public class DefaultMoveBehavior : IMoveBehavior{
        public void Move(Plane plane, Point destination) {
            if (plane.Faction == 'i') {
                if (GameEngine.GetInstance().TurnToken) {
                    if (plane.IsMoveLegal(destination)) {
                        plane.X += destination.X;
                        plane.Y += destination.Y;
                        plane.Z += destination.Z;
                        GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
                    }
                }
                else {
                    Logger.GetInstance().Info("It's not your turn");
                }
            }
            else 
            {
                if (GameEngine.GetInstance().TurnToken == false) {
                    if (plane.IsMoveLegal(destination)) {
                        plane.X += destination.X;
                        plane.Y += destination.Y;
                        plane.Z += destination.Z;
                        GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
                    }
                }
                else {
                    Logger.GetInstance().Info("It's not your turn");
                }
            }
        }

        public void Fire(Plane plane, Plane target, Weapon weapon) {
            int dice;
            if (plane.Faction == 'i') {
                if (GameEngine.GetInstance().TurnToken) {
                    
                }
                else {
                    Logger.GetInstance().Info("It's not your turn");
                }
            }
            if (plane.CanFire(target,weapon)) {
                ERange range = plane.CheckRange(target);
                switch (range) {
                    case ERange.SHORT:
                        for (int i = 0; i < weapon.Firepower[ERange.SHORT]; i++) {
                            dice = Dice.GetInstance().Roll();
                            if (dice >= weapon.Damage) {
                                target.Structure--;
                            }

                            if (dice >= weapon.Special) {
                                target.Structure--;
                            }
                        }
                        break;
                    case ERange.MEDIUM:
                        for (int i = 0; i < weapon.Firepower[ERange.MEDIUM]; i++) {
                            dice = Dice.GetInstance().Roll();
                            if (dice >= weapon.Damage) {
                                target.Structure--;
                            }

                            if (dice >= weapon.Special) {
                                target.Structure--;
                            }
                        }
                        break;
                    case ERange.LONG:
                        for (int i = 0; i < weapon.Firepower[ERange.LONG]; i++) {
                            dice = Dice.GetInstance().Roll();
                            if (dice >= weapon.Damage) {
                                target.Structure--;
                            }

                            if (dice >= weapon.Special) {
                                target.Structure--;
                            }
                        }
                        break;
                    case ERange.OUTOFRANGE:
                        Logger.GetInstance().Info("Target is out of Range");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}