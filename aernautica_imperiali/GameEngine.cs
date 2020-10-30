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
        
        public int CalculateDistance(Point destination) {
            return 0;
        }
        public List<Point> CalculateRoute(Point destination) {
            return null;
        }

        public bool IsPointValid() {
            return true;
        }

        public bool CheckSpin() {
            return true;
        }

        public void HandlingTest() {
            
        }
    }
}