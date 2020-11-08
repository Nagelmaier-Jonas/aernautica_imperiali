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
        private bool _shotsFired;
        private bool _hasMoved;
        private int _listIndex;

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

        public EOrientation Orientation{
            get => _orientation;
            set => _orientation = value;
        }

        public IMoveBehavior MoveBehavior => _moveBehavior;

        public char Type => _type;

        public char Faction => _faction;

        public bool ShotsFired {
            get => _shotsFired;
            set => _shotsFired = value;
        }

        public bool HasMoved {
            get => _hasMoved;
            set => _hasMoved = value;
        }

        public int ListIndex {
            get => _listIndex;
            set => _listIndex = value;
        }

        public bool IsMoveLegal(Point destination) {
            foreach (Point p in CalculateRoute(destination)) {
                if (!IsPointValid(p)) return false;
            }

            if (_hasMoved) {
                Logger.GetInstance().Info("Plane " +  + Char.ToUpper(_type) + ListIndex + " has already moved"); 
                return false;
            }

            int speed = _speed;
            int maneuver = _maneuver;

            int zdistance = Math.Abs(Z - destination.Z);
            speed -= zdistance;

            for (int i = 0; i < CalculateRoute(destination).Count - 1; i++) {
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

        public bool IsPointValid(Point p) {
            if (!Map.GetInstance().IsPointLegal(p)) return false;
            foreach (Plane plane in GameEngine.GetInstance().GetAllPlanes()) {
                if (plane.X == p.X && plane.Y == p.Y && plane.Z == p.Z) return false;
            }
            return true;
        }

        public void CheckSpin() {
            if (Dice.GetInstance().Roll() >= _handling) {
                Logger.GetInstance().Info("Handling-Test successful for " + Char.ToUpper(_type) + ListIndex);
                _moveBehavior = new DefaultMoveBehavior();
            }
            else {
                Logger.GetInstance().Info("Handling-Test failed for " + Char.ToUpper(_type) + ListIndex);
                HitGround();
            }
            Z--;
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

        public void HitGround() {
            if (Z <= 0)
                _structure = 0;
        }

        public bool CanFire(Plane plane, Weapon weapon) {
            if (InFireArc(plane, weapon) && CheckRange(plane) != ERange.OUTOFRANGE)
                if (weapon.Ammo == 0) {
                    Logger.GetInstance().Info("Plane " + Char.ToUpper(_type) + ListIndex + " is out of Ammo");
                    return false;
                }
            return true;
        }

        public ERange CheckRange(Plane plane) {
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

        private bool InFireArc(Plane target, Weapon weapon) {
            foreach (EFireArc eFireArc in weapon.FireArc){
                switch (_orientation){
                    case EOrientation.NORTH:
                        if (InNorthFireArc(target, eFireArc)){
                            return true;
                        }
                        break;
                    case EOrientation.EAST:
                        if (InEastFireArc(target, eFireArc)){
                            return true;
                        }
                        break;
                    case EOrientation.SOUTH:
                        if (InSouthFireArc(target, eFireArc)){
                            return true;
                        }
                        break;
                    case EOrientation.WEST:
                        if (InWestFireArc(target, eFireArc)){
                            return true;
                        }
                        break;
                    default:
                        throw new Exception("Hoppala");
                }
            }
            return false;
        }

        public bool InNorthFireArc(Plane target, EFireArc fireArc) {
            switch (fireArc) {
                case EFireArc.ALLROUND:
                    if (X != target.X ^ Y != target.Y) {
                        return true;
                    }

                    break;
                case EFireArc.FRONT:
                    if (Y < target.Y) {
                        return true;
                    }

                    break;
                case EFireArc.LEFT:
                    if (X < target.X) {
                        return true;
                    }

                    break;
                case EFireArc.RIGHT:
                    if (X > target.X) {
                        return true;
                    }

                    break;
                case EFireArc.REAR:
                    if (Y > target.Y) {
                        return true;
                    }

                    break;
                case EFireArc.UP:
                    if (Z < target.Z) {
                        return true;
                    }

                    break;
            }

            return false;
        }

        public bool InSouthFireArc(Plane target, EFireArc fireArc) {
            switch (fireArc) {
                case EFireArc.ALLROUND:
                    if (X != target.X ^ Y != target.Y) {
                        return true;
                    }

                    break;
                case EFireArc.FRONT:
                    if (Y > target.Y) {
                        return true;
                    }

                    break;
                case EFireArc.LEFT:
                    if (X > target.X) {
                        return true;
                    }

                    break;
                case EFireArc.RIGHT:
                    if (X < target.X) {
                        return true;
                    }

                    break;
                case EFireArc.REAR:
                    if (Y < target.Y) {
                        return true;
                    }

                    break;
                case EFireArc.UP:
                    if (Z < target.Z) {
                        return true;
                    }

                    break;
            }

            return false;
        }

        public bool InWestFireArc(Plane target, EFireArc fireArc) {
            switch (fireArc) {
                case EFireArc.ALLROUND:
                    if (X != target.X ^ Y != target.Y) {
                        return true;
                    }

                    break;
                case EFireArc.FRONT:
                    if (X > target.X) {
                        return true;
                    }

                    break;
                case EFireArc.LEFT:
                    if (Y < target.Y) {
                        return true;
                    }

                    break;
                case EFireArc.RIGHT:
                    if (Y > target.Y) {
                        return true;
                    }

                    break;
                case EFireArc.REAR:
                    if (X < target.X) {
                        return true;
                    }

                    break;
                case EFireArc.UP:
                    if (Z < target.Z) {
                        return true;
                    }

                    break;
            }

            return false;
        }

        public bool InEastFireArc(Plane target, EFireArc fireArc) {
            switch (fireArc) {
                case EFireArc.ALLROUND:
                    if (X != target.X ^ Y != target.Y) {
                        return true;
                    }

                    break;
                case EFireArc.FRONT:
                    if (X < target.X) {
                        return true;
                    }

                    break;
                case EFireArc.LEFT:
                    if (Y > target.Y) {
                        return true;
                    }

                    break;
                case EFireArc.RIGHT:
                    if (Y < target.Y) {
                        return true;
                    }

                    break;
                case EFireArc.REAR:
                    if (X > target.X) {
                        return true;
                    }

                    break;
                case EFireArc.UP:
                    if (Z < target.Z) {
                        return true;
                    }

                    break;
            }

            return false;
        }

        

        public bool DoDamage(Plane target, Weapon weapon) {
            int dice;
            int heightDifference = Math.Abs(Z - target.Z);
            dice = Dice.GetInstance().Roll() - heightDifference;
            if (dice >= weapon.Damage) {
                Logger.GetInstance().Info("Plane " + Char.ToUpper(target.Type) + target.ListIndex + " was Hit by" + Char.ToUpper(_type) + ListIndex);
                target.Structure--;
                if (dice >= weapon.Special && weapon.Special != 0) {
                    Logger.GetInstance().Info("Plane " + Char.ToUpper(target.Type) + target.ListIndex + " was Hit with a special by" + Char.ToUpper(_type) + ListIndex);
                    target.Structure--;
                }
                return true;
            }

            Logger.GetInstance().Info(Char.ToUpper(_type) + ListIndex + " missed");

            return false;
        }
        
        public void Move(Point destination, int speedChange) {
            if (!GameEngine.GetInstance().GameOver) {
                if (_faction != 'i' && _faction != 'o') {
                    GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
                }
                else {
                    ChangeSpeed(speedChange);
                    if (IsMoveLegal(destination)) {
                        MoveBehavior.Move(this, destination, speedChange);
                        CheckSpeed();
                        CheckHeight();
                    }
                    GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
                }
            }
        }
        
        public void Fire(int targetIndex, int weaponIndex) {
            Plane target;
            Weapon weapon;
            if (!GameEngine.GetInstance().GameOver) {
                if (_faction != 'i' && _faction != 'o') {
                    GameEngine.GetInstance().FireTurns++;
                    GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
                }
                else {
                    if (_faction == 'i' && targetIndex >= 0 && targetIndex < GameEngine.GetInstance().Ork.Planes.Count) {
                        target = GameEngine.GetInstance().GetOrk(targetIndex);
                    }
                    else {
                        target = GameEngine.GetInstance().GetImperialis(targetIndex);
                    }

                    if (weaponIndex >= 0 && weaponIndex < target._weapons.Length) {
                        weapon = target._weapons[weaponIndex];
                        weapon.Fire(this,target);
                    }
                }
            }
        }
        
        public void SetOrientation(Point destination) {
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
            Logger.GetInstance().Info("SpeedChange is too high for " + Char.ToUpper(_type) + ListIndex);
        }
    }
}