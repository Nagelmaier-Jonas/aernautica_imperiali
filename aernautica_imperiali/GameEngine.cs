using System.Collections.Generic;

namespace aernautica_imperiali {
    public class GameEngine {
        private static GameEngine _instance = new GameEngine();
        private Player _imperialis;
        private Player _ork;
        private GameEngine() {
        }

        public Player Imperialis {
            get => _imperialis;
            set => _imperialis = value;
        }

        public Player Ork {
            get => _ork;
            set => _ork = value;
        }

        public static GameEngine GetInstance() {
            return _instance;
        }
        
        public bool IsMoveLegal(APlane plane, Point destination) {
            
        }

        public void MovePlane(Point destination) {
            
        }

        public bool IsPointValid(Point p){
            if (!Map.GetInstance().IsPointLegal(p)) return false;
            foreach (Player player in _ork){
                foreach (APlane plane in player){
                    if(plane.)
                }
            }
        }

        public bool CheckSpin() {
            return true;
        }

        public void HandlingTest() {
            
        }
    }
}