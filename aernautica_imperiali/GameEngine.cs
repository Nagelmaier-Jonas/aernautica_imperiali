using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace aernautica_imperiali {
    public class GameEngine {
        private static GameEngine _instance = new GameEngine();
        private Player _imperialis = new Player();
        private Player _ork = new Player();
        private bool _turnToken = true;
        private int _moveTurns = 0;
        private int _fireTurns = 0;
        private bool _allowFire = false;
        private static int _round = 1;
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

        public int MoveTurns => _moveTurns;

        public bool AllowFire => _allowFire;

        public static GameEngine GetInstance() {
            return _instance;
        }

        public void CheckStructure() {
            if (_imperialis.Planes.Count > 0) {
                for (int i = 0; i < _imperialis.Planes.Count; i++) {
                    if (_imperialis.Planes[i].Structure <= 0) {
                        _imperialis.Planes.Remove(_imperialis.Planes[i]);
                    }
                }
            }
            if (_ork.Planes.Count > 0) {
                for (int i = 0; i < _ork.Planes.Count; i++) {
                    if (_ork.Planes[i].Structure <= 0) {
                        _ork.Planes.Remove(_ork.Planes[i]);
                    }
                }
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
            _moveTurns++;
            if (_moveTurns == _imperialis.Planes.Count + _ork.Planes.Count) {
                _allowFire = true;
                _moveTurns = 0;
            }
            else {
                _allowFire = false;
            }
        }
        
        public void EndTurn() {
            _round++;
            if (_round == 5) {
                if (_imperialis.Points >= 100) {
                    Logger.GetInstance().Info("Imperialis won");
                    RestartGame();
                }
                else {
                    if (_ork.Points >= 100) {
                        Logger.GetInstance().Info("Orks won");
                        RestartGame();
                    }
                    else {
                        Logger.GetInstance().Info("Nobody won! It's a draw");
                        RestartGame();
                    }
                }
            }
            else{
                if (_imperialis.Points >= 100){
                    Logger.GetInstance().Info("Imperialis won");
                    RestartGame();
                }
                else if (_ork.Points >= 100){
                    Logger.GetInstance().Info("Orks won");
                    RestartGame();
                }
            }
            NextRound();
        }

        public void NextRound() {
            _turnToken = true;
            _moveTurns = 0;
            _fireTurns = 0;
            _allowFire = false;
        }

        public void RestartGame() {
            _imperialis.StartPoints = 150;
            _imperialis.Points = 0;
            _imperialis.Planes.Clear();
            _ork.StartPoints = 150;
            _ork.Points = 0;
            _ork.Planes.Clear();
            
        _turnToken = true;
        _moveTurns = 0;
        _fireTurns = 0; 
        _allowFire = false;
        _round = 1;
        }
    }
    
}