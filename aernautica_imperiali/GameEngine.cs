using System.Collections.Generic;

namespace aernautica_imperiali {
    public class GameEngine {
        private static GameEngine _instance = new GameEngine();
        private Player _imperialis = new Player();
        private Player _ork = new Player();
        private bool _turnToken = true;
        private int _turns = 0;
        private bool _allowFire = false;
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

        public void CheckTurns() {
            if (_turns == _imperialis.Planes.Count + _ork.Planes.Count) {
                _allowFire = true;
                _turns = 0;
            }
            _turns++;
            _allowFire = false;
        }

        public void EndTurn() {
            if (_imperialis.Points >= 100) {
                Logger.GetInstance().Info("Imperialis won");
            }else if (_ork.Points >= 100) {
                Logger.GetInstance().Info("Orks won");
            }
        }

        public void Move(Plane plane, Point destination) {
            plane.X += destination.X;
            plane.Y += destination.Y;
            plane.Z += destination.Z;
            _turnToken = !_turnToken;
        }
        
    }
}