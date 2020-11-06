using System;
using System.Collections.Generic;
using System.Linq;

namespace aernautica_imperiali {
    public class Plane : Point {
        private int _structure;
        private int _speed;
        private int _throttle;
        private int _minSpeed;
        private int _maxSpeed;
        private int _maneuver;
        private int _handling;
        private int _maxAltitude;
        private int _planeValue;
        private IMoveBehavior _moveBehavior = new DefaultMoveBehavior();
        private Weapon[] _weapons;
        private EOrientation _orientation;
        private char _type;
        private char _faction;
        private bool _shotsFired = false;
        private bool _hasMoved = false;

        public Plane(Point p, int structure, int speed, int throttle, int minSpeed, int maxSpeed, int maneuver,
            int handling, int maxAltitude, int planeValue, Weapon[] weapons, EOrientation orientation, char type,
            char faction) : base(p.X, p.Y, p.Z) {
            _structure = structure;
            _speed = speed;
            _throttle = throttle;
            _minSpeed = minSpeed;
            _maxSpeed = maxSpeed;
            _maneuver = maneuver;
            _handling = handling;
            _maxAltitude = maxAltitude;
            _planeValue = planeValue;
            _weapons = weapons;
            _orientation = orientation;
            _type = type;
            _faction = faction;
        }

        public int Structure {
            get => _structure;
            set => _structure = value;
        }

        public int Speed {
            get => _speed;
            set => _speed = value;
        }

        public int Maneuver {
            get => _maneuver;
            set => _maneuver = value;
        }

        public int Throttle => _throttle;

        public int MinSpeed => _minSpeed;

        public int MaxSpeed => _maxSpeed;

        public int Handling => _handling;

        public int MaxAltitude => _maxAltitude;

        public int PlaneValue => _planeValue;

        public Weapon[] Weapons => _weapons;
        public IMoveBehavior MoveBehavior => _moveBehavior;

        public char Type => _type;

        public char Faction => _faction;

        public bool HasMoved {
            get => _hasMoved;
            set => _hasMoved = value;
        }

        public bool IsMoveLegal(Point destination) {
            foreach (Point p in CalculateRoute(destination)) {
                if (!IsPointValid(p)) return false;
            }

            if (_hasMoved) return false;

            int speed = _speed;
            int maneuver = _maneuver;

            int zdistance = Math.Abs(Z - destination.Z);
            speed -= zdistance;

            for (int i = 0; i < (CalculateRoute(destination).Count - 1); i++) {
                if (CalculateRoute(destination)[i].X != CalculateRoute(destination)[i + 1].X &&
                    CalculateRoute(destination)[i].Y != CalculateRoute(destination)[i + 1].Y) {
                    maneuver--;
                    if (maneuver < 0) return false;
                }

                speed--;
                if (speed == 0) return true;
            }

            speed--;
            if (speed == 0) return true;

            return false;
        }

        private bool IsPointValid(Point p) {
            if (!Map.GetInstance().IsPointLegal(p)) return false;
            foreach (Plane plane in GameEngine.GetInstance().Ork.Planes) {
                if (plane.X == p.X && plane.Y == p.Y && plane.Z == p.Z) return false;
            }

            foreach (Plane plane in GameEngine.GetInstance().Imperialis.Planes) {
                if (plane.X == p.X && plane.Y == p.Y && plane.Z == p.Z) return false;
            }

            return true;
        }

        public void CheckSpin() {
            if (Dice.GetInstance().Roll() >= _handling) {
                Logger.GetInstance().Info("Handling-Test successful");
                _moveBehavior = new DefaultMoveBehavior();
            }
            else {
                Logger.GetInstance().Info("Handling-Test failed");
                Z--;
                HitGround();
            }
        }

        public void CheckHeight() {
            if (Z > _maxAltitude) {
                _moveBehavior = new SpinBehavior();
            }
        }

        public void CheckSpeed() {
            if (_speed > _maxSpeed || _speed < _minSpeed) {
                _moveBehavior = new SpinBehavior();
            }
        }

        private void HitGround() {
            if (Z <= 0)
                _structure = 0;
        }

        private bool CanFire(Plane plane, Weapon weapon) {
            if (InFireArc(plane, weapon) && CheckRange(plane) != ERange.OUTOFRANGE)
                if (weapon.Ammo == 0) {
                    Logger.GetInstance().Info("Out of Ammo");
                    return false;
                }

            return true;
        }

        private ERange CheckRange(Plane plane) {
            if (CalculateRoute(plane).Count <= Weapon.SHORT) {
                return ERange.SHORT;
            }

            if (CalculateRoute(plane).Count > Weapon.SHORT && CalculateRoute(plane).Count <= Weapon.MEDIUM) {
                return ERange.MEDIUM;
            }

            if (CalculateRoute(plane).Count > Weapon.MEDIUM && CalculateRoute(plane).Count <= Weapon.LONG) {
                return ERange.LONG;
            }

            return ERange.OUTOFRANGE;
        }

        private bool InFireArc(Plane plane, Weapon weapon) {
            switch (_orientation) {
                case EOrientation.NORTH:
                    foreach (EFireArc fireArc in weapon.FireArc) {
                        if (InNorthFireArc(plane, fireArc)) {
                            return true;
                        }
                    }

                    break;
                case EOrientation.EAST:
                    foreach (EFireArc fireArc in weapon.FireArc) {
                        if (InEastFireArc(plane, fireArc)) {
                            return true;
                        }
                    }

                    break;
                case EOrientation.SOUTH:
                    foreach (EFireArc fireArc in weapon.FireArc) {
                        if (InSouthFireArc(plane, fireArc)) {
                            return true;
                        }
                    }

                    break;
                case EOrientation.WEST:
                    foreach (EFireArc fireArc in weapon.FireArc) {
                        if (InWestFireArc(plane, fireArc)) {
                            return true;
                        }
                    }

                    break;
                default:
                    throw new Exception("Hoppala do is wos schief gonga");
            }

            return false;
        }

        private bool InNorthFireArc(Plane plane, EFireArc fireArc) {
            switch (fireArc) {
                case EFireArc.ALLROUND:
                    if (X != plane.X ^ Y != plane.Y) {
                        return true;
                    }

                    break;
                case EFireArc.FRONT:
                    if (Y < plane.Y) {
                        return true;
                    }

                    break;
                case EFireArc.LEFT:
                    if (X < plane.X) {
                        return true;
                    }

                    break;
                case EFireArc.RIGHT:
                    if (X > plane.X) {
                        return true;
                    }

                    break;
                case EFireArc.REAR:
                    if (Y > plane.Y) {
                        return true;
                    }

                    break;
                case EFireArc.UP:
                    if (Z < plane.Z) {
                        return true;
                    }

                    break;
            }

            return false;
        }

        private bool InSouthFireArc(Plane plane, EFireArc fireArc) {
            switch (fireArc) {
                case EFireArc.ALLROUND:
                    if (X != plane.X ^ Y != plane.Y) {
                        return true;
                    }

                    break;
                case EFireArc.FRONT:
                    if (Y > plane.Y) {
                        return true;
                    }

                    break;
                case EFireArc.LEFT:
                    if (X > plane.X) {
                        return true;
                    }

                    break;
                case EFireArc.RIGHT:
                    if (X < plane.X) {
                        return true;
                    }

                    break;
                case EFireArc.REAR:
                    if (Y < plane.Y) {
                        return true;
                    }

                    break;
                case EFireArc.UP:
                    if (Z < plane.Z) {
                        return true;
                    }

                    break;
            }

            return false;
        }

        private bool InWestFireArc(Plane plane, EFireArc fireArc) {
            switch (fireArc) {
                case EFireArc.ALLROUND:
                    if (X != plane.X ^ Y != plane.Y) {
                        return true;
                    }

                    break;
                case EFireArc.FRONT:
                    if (X > plane.X) {
                        return true;
                    }

                    break;
                case EFireArc.LEFT:
                    if (Y < plane.Y) {
                        return true;
                    }

                    break;
                case EFireArc.RIGHT:
                    if (Y > plane.Y) {
                        return true;
                    }

                    break;
                case EFireArc.REAR:
                    if (X < plane.X) {
                        return true;
                    }

                    break;
                case EFireArc.UP:
                    if (Z < plane.Z) {
                        return true;
                    }

                    break;
            }

            return false;
        }

        private bool InEastFireArc(Plane plane, EFireArc fireArc) {
            switch (fireArc) {
                case EFireArc.ALLROUND:
                    if (X != plane.X ^ Y != plane.Y) {
                        return true;
                    }

                    break;
                case EFireArc.FRONT:
                    if (X < plane.X) {
                        return true;
                    }

                    break;
                case EFireArc.LEFT:
                    if (Y > plane.Y) {
                        return true;
                    }

                    break;
                case EFireArc.RIGHT:
                    if (Y < plane.Y) {
                        return true;
                    }

                    break;
                case EFireArc.REAR:
                    if (X > plane.X) {
                        return true;
                    }

                    break;
                case EFireArc.UP:
                    if (Z < plane.Z) {
                        return true;
                    }

                    break;
            }

            return false;
        }

        public void Fire(Plane target, Weapon weapon) {
            if (_weapons.Contains(weapon)) {
                if (CanFire(target, weapon) && !_shotsFired && GameEngine.GetInstance().AllowFire) {
                    ERange range = CheckRange(target);
                    switch (range) {
                        case ERange.SHORT:
                            for (int i = 0; i < weapon.Firepower[ERange.SHORT]; i++) {
                                if (DoDamage(target, weapon)) {
                                    GameEngine.GetInstance().CheckStructure();
                                    return;
                                }
                            }

                            break;
                        case ERange.MEDIUM:
                            for (int i = 0; i < weapon.Firepower[ERange.MEDIUM]; i++) {
                                if (DoDamage(target, weapon)) {
                                    GameEngine.GetInstance().CheckStructure();
                                    return;
                                }
                            }

                            break;
                        case ERange.LONG:
                            for (int i = 0; i < weapon.Firepower[ERange.LONG]; i++) {
                                if (DoDamage(target, weapon)) {
                                    GameEngine.GetInstance().CheckStructure();
                                    return;
                                }
                            }

                            break;
                        case ERange.OUTOFRANGE:
                            Logger.GetInstance().Info("Target is out of Range");
                            break;
                    }
                }
            }
        }

        private bool DoDamage(Plane target, Weapon weapon) {
            int dice;
            int heightDifference = Math.Abs(Z - target.Z);
            dice = Dice.GetInstance().Roll() - heightDifference;
            if (dice >= weapon.Damage) {
                target.Structure--;
                if (dice >= weapon.Special) {
                    target.Structure--;
                }

                GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
                weapon.Ammo--;
                _shotsFired = true;
                return true;
            }

            return false;
        }

        public void Move(Point destination) {
            SetOrientation(destination);
            _hasMoved = true;
            X += destination.X;
            Y += destination.Y;
            Z += destination.Z;
            GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
            GameEngine.GetInstance().CheckTurns();
        }

        private void SetOrientation(Point destination) {
            List<Point> route = CalculateRoute(destination);
            Point[] lastPoints = new Point[2];
            if (route.Count == 1) {
                lastPoints[0] = new Point(X, Y, Z);
                lastPoints[1] = route[0];
            }
            else {
                lastPoints[0] = route[route.Count - 2];
                lastPoints[1] = route[route.Count - 1];
            }

            if (lastPoints[0].X < lastPoints[1].X && lastPoints[0].Y == lastPoints[1].Y) {
                _orientation = EOrientation.EAST;
            }

            if (lastPoints[0].X > lastPoints[1].X && lastPoints[0].Y == lastPoints[1].Y) {
                _orientation = EOrientation.WEST;
            }

            if (lastPoints[0].X == lastPoints[1].X && lastPoints[0].Y < lastPoints[1].Y) {
                _orientation = EOrientation.NORTH;
            }

            if (lastPoints[0].X == lastPoints[1].X && lastPoints[0].Y > lastPoints[1].Y) {
                _orientation = EOrientation.SOUTH;
            }

            if (lastPoints[0].X != lastPoints[1].X && lastPoints[0].Y < lastPoints[1].Y) {
                _orientation = EOrientation.SOUTH;
            }

            if (lastPoints[0].X != lastPoints[1].X && lastPoints[0].Y > lastPoints[1].Y) {
                _orientation = EOrientation.NORTH;
            }
        }

        public void ChangeSpeed(int changeSpeed) {
            if (Math.Abs(changeSpeed) <= _throttle) {
                _speed += changeSpeed;
                return;
            }

            Logger.GetInstance().Info("SpeedChange is too high");
        }
    }
}