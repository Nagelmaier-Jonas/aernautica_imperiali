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

        public int MoveTurns {
            get => _moveTurns;
            set => _moveTurns = value;
        }

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
            foreach (Plane plane in GetAllPlanes()) {
                if (plane.Structure <= 0) {
                    switch (plane.Faction) {
                        case 'i':
                            Logger.GetInstance().Info("Imperialis Plane destroyed");
                            _ork.Points += plane.PlaneValue;
                            _imperialis.Planes.Remove(plane);
                            break;
                        case 'o':
                            Logger.GetInstance().Info("Ork Plane destroyed");
                            _imperialis.Points += plane.PlaneValue;
                            _ork.Planes.Remove(plane);
                            break;
                        default:
                            throw new Exception("plane is not in List");
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
           // Logger.GetInstance().Info("CheckTurns aufgerufen" + "MoveTurns: " + _moveTurns + "PlanesLength: " + GetAllPlanes().Count);
            if (_moveTurns == GetAllPlanes().Count) {
                _allowFire = true;
                _moveTurns = 0;
            }
            else {
                _allowFire = false;
            }
        }

        public void EndTurn() {
            if (_gameOver) {
                return;
            }
            _round++;
            if (_round == 5) {
                if (HasWon() == _imperialis) {
                    Logger.GetInstance().Info("Imperialis won");
                    DisplayPoints();
                    _gameOver = true;
                }
                else {
                    if (HasWon() == _ork) {
                        Logger.GetInstance().Info("Orks won");
                        DisplayPoints();
                        _gameOver = true;
                    }
                    else {
                        Logger.GetInstance().Info("Nobody won! It's a draw");
                        DisplayPoints();
                        _gameOver = true;
                    }
                }
            }
            else {
                if (HasWon() == _imperialis) {
                    Logger.GetInstance().Info("Imperialis won");
                    DisplayPoints();
                    _gameOver = true;
                }
                else if (HasWon() == _ork) {
                    Logger.GetInstance().Info("Orks won");
                    DisplayPoints();
                    _gameOver = true;
                }
            }
            DisplayPoints();
            NextRound();
        }

        public Player HasWon() {
            if (_imperialis.Points >= 100) {
                return _imperialis;
            }

            if (_ork.Points >= 100) {
                return _ork;
            }

            return null;
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
                plane.ShotsFired = false;
            }

            _turnToken = true;
            _moveTurns = 0;
            _fireTurns = 0;
            _allowFire = false;
        }
        
        public List<Plane> GetAllPlanes() {
            List<Plane> planes = new List<Plane>();
            planes.AddRange(_imperialis.Planes);
            planes.AddRange(_ork.Planes);

            return planes;
        }
    }
}