using System;

namespace aernautica_imperiali{
    public class DefaultMoveBehavior : IMoveBehavior{
        public void Move(Plane plane, Point destination) {
            if (plane.Faction == 'i') {
                if (GameEngine.GetInstance().TurnToken) {
                    if (plane.IsMoveLegal(destination)) {
                        plane.Move(destination);
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
                        plane.Move(destination);
                    }
                }
                else {
                    Logger.GetInstance().Info("It's not your turn");
                }
            }
        }

        public void Fire(Plane plane, Plane target, Weapon weapon) {
            if (plane.Faction == 'i') {
                if (GameEngine.GetInstance().TurnToken) {
                    plane.Fire(target,weapon);
                }
                else {
                    Logger.GetInstance().Info("It's not your turn");
                }
            }
            else {
                if (!GameEngine.GetInstance().TurnToken) {
                    plane.Fire(target,weapon);     
                }
                else {
                    Logger.GetInstance().Info("It's not your turn");      
                }
            }
        }
    }
}