using System.Collections.Generic;

namespace aernautica_imperiali {
    public class GameEngine {
        private static GameEngine _instance = new GameEngine();
        private GameEngine() {
        }
        
        public static GameEngine GetInstance() {
            return _instance;
        }

        public void Move(Point destination) {
            //Bewegung des Flugzeuges
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