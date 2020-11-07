using System;

namespace aernautica_imperiali {
    public class SpinBehavior : IMoveBehavior {
        public void Move(Plane plane, Point destination, int speedChange) {
            if (plane.Faction == 'i') {
                if (GameEngine.GetInstance().TurnToken) {
                    Logger.GetInstance().Info("You can not move, you're in spinmode");
                    GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
                    GameEngine.GetInstance().CheckTurns();
                }
                else {
                    Logger.GetInstance().Info("It's not your turn");
                }
            }
            else {
                if (GameEngine.GetInstance().TurnToken == false) {
                    Logger.GetInstance().Info("You can not move, you're in spinmode");
                    GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
                    GameEngine.GetInstance().CheckTurns();
                }
                else {
                    Logger.GetInstance().Info("It's not your turn");
                }
            }
        }

        public void Fire(Plane plane, Plane target, Weapon weapon) {
            Logger.GetInstance().Info("You can not shoot, you're in spinmode");
            plane.CheckSpin();
            GameEngine.GetInstance().CheckStructure();
        }
    }
}