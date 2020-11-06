using System;

namespace aernautica_imperiali{
    public class DefaultMoveBehavior : IMoveBehavior{
        public void Move(Plane plane, Point destination, int speedChange) {
            if (plane.Faction == 'i') {
                if (GameEngine.GetInstance().TurnToken) {
                    plane.ChangeSpeed(speedChange);
                    plane.CheckSpeed();
                    if (plane.IsMoveLegal(destination)) {
                        plane.Move(destination);
                        plane.CheckHeight();
                    }
                }
                else {
                    Logger.GetInstance().Info("It's not your turn");
                }
            }
            else 
            {
                if (!GameEngine.GetInstance().TurnToken) {
                    plane.ChangeSpeed(speedChange);
                    plane.CheckSpeed();
                    if (plane.IsMoveLegal(destination)) {
                        plane.Move(destination);
                        plane.CheckHeight();
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
                    GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
                }
                else {
                    Logger.GetInstance().Info("It's not your turn");
                }
            }
            else {
                if (!GameEngine.GetInstance().TurnToken) {
                    plane.Fire(target,weapon);     
                    GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
                }
                else {
                    Logger.GetInstance().Info("It's not your turn");      
                }
            }
        }
    }
}