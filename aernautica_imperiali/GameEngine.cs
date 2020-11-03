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

        public void CheckStructure() {
            foreach (Plane plane in _imperialis.Planes) {
                if (plane.Structure <= 0)
                    _imperialis.Planes.Remove(plane);
            }
            foreach (Plane plane in _ork.Planes) {
                if (plane.Structure <= 0)
                    _ork.Planes.Remove(plane);
            }
        }
        
    }
}