using System.Collections.Generic;

namespace aernautica_imperiali {
    public class GameEngine {
        private static GameEngine _instance = new GameEngine();
        private Player _imperialis = new Player();
        private Player _ork = new Player();
        private bool _turnToken;
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

        public bool TurnToken {
            get => _turnToken;
            set => _turnToken = value;
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

        public void PlacePlane(Plane plane) {
            if (Map.GetInstance().IsPointLegal(plane)) {
                if (plane.Faction == 'i') {
                    if (plane.Y < 3) {
                        if (_imperialis.StartPoints >= plane.PlaneValue) {
                            _imperialis.StartPoints -= plane.PlaneValue;
                            _imperialis.Planes.Add(plane);
                        }
                        else {
                            Logger.GetInstance().Info("You don't have enough Points: " + _imperialis.StartPoints + " left");
                        }
                    }
                    else {
                        Logger.GetInstance().Info("Out of placement field");
                    }
                }
                else {
                    if (plane.Y > 11) {
                        if (_ork.StartPoints >= plane.PlaneValue) {
                            _ork.StartPoints -= plane.PlaneValue;
                            _ork.Planes.Add(plane);
                        }
                        else {
                            Logger.GetInstance().Info("You don't have enough Points: " + _ork.StartPoints + " left");
                        }
                    }
                    else {
                        Logger.GetInstance().Info("Out of placement field");
                    }
                }
            }
        }
        
    }
}