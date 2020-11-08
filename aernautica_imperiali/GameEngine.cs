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
        private bool _allowFire = false;
        private static int _round = 0;
        private int _fireTurns;
        private bool _gameOver;

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
        
        public bool GameOver => _gameOver;

        public int FireTurns {
            get => _fireTurns;
            set => _fireTurns = value;
        }

        public static GameEngine GetInstance() {
            return _instance;
        }
        
        public void CheckStructure() {
            if (_imperialis.Planes.Count > 0) {
                for (int i = 0; i < _imperialis.Planes.Count; i++) {
                    if (_imperialis.Planes[i].Structure <= 0) {
                        Logger.GetInstance().Info("Imperialis Plane destroyed");
                        _ork.Points += _imperialis.Planes[i].PlaneValue;
                        _imperialis.Planes.Remove(_imperialis.Planes[i]);
                    }
                }
            }

            if (_ork.Planes.Count > 0) {
                for (int i = 0; i < _ork.Planes.Count; i++) {
                    if (_ork.Planes[i].Structure <= 0) {
                        Logger.GetInstance().Info("Ork Plane destroyed");
                        _imperialis.Points += _ork.Planes[i].PlaneValue;
                        _ork.Planes.Remove(_ork.Planes[i]);
                    }
                }
            }
        }

        public void PlacePlane(Plane plane) {
            if (Map.GetInstance().IsPointLegal(plane)) {
                if (plane.Faction == 'i') {
                    if (plane.Y < 3 && plane.Z <= plane.MaxAltitude) {
                        if (_imperialis.StartPoints >= plane.PlaneValue) {
                            _imperialis.StartPoints -= plane.PlaneValue;
                            _imperialis.Planes.Add(plane);
                            plane.ListIndex = _imperialis.Planes.Count - 1;
                        }
                        else {
                            Logger.GetInstance()
                                .Info("You don't have enough Points: " + _imperialis.StartPoints + " left");
                        }
                    }
                    else {
                        Logger.GetInstance().Info("Out of placement field");
                    }
                }
                else {
                    if (plane.Y > 11 && plane.Z <= plane.MaxAltitude) {
                        if (_ork.StartPoints >= plane.PlaneValue) {
                            _ork.StartPoints -= plane.PlaneValue;
                            _ork.Planes.Add(plane);
                            plane.ListIndex = _ork.Planes.Count - 1;
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
                    DisplayPoints();
                    RestartGame();
                }
                else {
                    if (_ork.Points >= 100) {
                        Logger.GetInstance().Info("Orks won");
                        DisplayPoints();
                        RestartGame();
                    }
                    else {
                        Logger.GetInstance().Info("Nobody won! It's a draw");
                        DisplayPoints();
                        RestartGame();
                    }
                }
            }
            else {
                if (_imperialis.Points >= 100) {
                    Logger.GetInstance().Info("Imperialis won");
                    DisplayPoints();
                    RestartGame();
                }
                else if (_ork.Points >= 100) {
                    Logger.GetInstance().Info("Orks won");
                    DisplayPoints();
                    RestartGame();
                }
            }
            DisplayPoints();
            NextRound();
        }

        public Plane GetImperialis(int number) {
            foreach (Plane plane in _imperialis.Planes) {
                if (plane.ListIndex == number) {
                    return plane;
                }
            }
            return new Plane(new Point(-1,-1,-1), 0,0,0,0,0,0,0,0,0,new Weapon[]{new Weapon(new EFireArc[] {EFireArc.ALLROUND}, 0,0,0,0,0,0)}, EOrientation.NORTH,'-','-');
        }

        public Plane GetOrk(int number) {
            foreach (Plane plane in _ork.Planes) {
                if (plane.ListIndex == number) {
                    return plane;
                }
            }
            return new Plane(new Point(-1,-1,-1), 0,0,0,0,0,0,0,0,0,new Weapon[]{new Weapon(new EFireArc[] {EFireArc.ALLROUND}, 0,0,0,0,0,0)}, EOrientation.NORTH,'-','-');
        }
        
        public void Fire(Plane plane, Plane target, Weapon weapon) {
            if (!_gameOver) {
                if (_fireTurns == 0 && plane.Faction != '-') {
                    Console.WriteLine("Current Round: Fire");
                    Console.WriteLine();
                }
                if (plane != null && target != null) {
                    weapon.Fire(plane,target);
                    if (AllShotsFired()) {
                        Logger.GetInstance().Info("EndTurn");
                        EndTurn();
                    }
                    if (plane.ShotsFired) {
                        _fireTurns++;
                    }
                    Logger.GetInstance().Info("FireTurns: " + _fireTurns);
                }
                else {
                    Logger.GetInstance().Info("Plane doesn't exist anymore");
                }
            }
        }

        public void DisplayPoints() {
            if (!_gameOver) {
                Console.WriteLine("Imperialis: " + _imperialis.Points);
                Console.WriteLine("Orks: " + _ork.Points);
                Console.WriteLine();
            }
        }

        public void NextRound() {
            foreach (Plane plane in GetAllPlanes()) {
                plane.HasMoved = false;
            }
            foreach (Plane plane in GetAllPlanes()) {
                plane.ShotsFired = false;
            }

            _turnToken = true;
            _moveTurns = 0;
            _fireTurns = 0;
            _allowFire = false;
        }

        public void RestartGame() {
            _gameOver = true;
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

        public List<Plane> GetAllPlanes() {
            List<Plane> planes = new List<Plane>();
            planes.AddRange(_imperialis.Planes);
            planes.AddRange(_ork.Planes);

            return planes;
        }

        public bool AllShotsFired() {
            bool check = true;
            foreach (Plane plane in GetAllPlanes()) {
                if (!plane.ShotsFired) {
                    check = false;
                }
            }
            Logger.GetInstance().Info("AllShotsFired: " + check);
            return check;
        }
    }
}