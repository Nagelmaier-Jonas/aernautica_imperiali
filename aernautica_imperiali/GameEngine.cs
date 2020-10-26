namespace aernautica_imperiali {
    public class GameEngine {
        private static GameEngine _instance = new GameEngine();
        private GameEngine() {
        }
        
        public static GameEngine GetInstance() {
            return _instance;
        }
    }
}