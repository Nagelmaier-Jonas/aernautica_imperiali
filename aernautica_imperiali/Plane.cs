using System;

namespace aernautica_imperiali{
    public class Plane : Point{
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

        public Plane(Point p, int structure, int speed, int throttle, int minSpeed, int maxSpeed, int maneuver, int handling, int maxAltitude, int planeValue, Weapon[] weapons, EOrientation orientation, char type, char faction) : base(p.X,p.Y,p.Z){
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
        
        public IMoveBehavior MoveBehavior {
            get => _moveBehavior;
            set => _moveBehavior = value;
        }

        public char Type => _type;

        public char Faction => _faction;

        public bool IsMoveLegal(Point destination) {
            foreach (Point p in CalculateRoute(destination)){
                if (!IsPointValid(p)) return false;
            }

            int speed = _speed;
            int maneuver = _maneuver;

            for (int i = 0; i < CalculateRoute(destination).Count; i++){
                if (CalculateRoute(destination)[i].X != CalculateRoute(destination)[i++].X &&
                    CalculateRoute(destination)[i].Y != CalculateRoute(destination)[i++].Y){
                    maneuver--;
                    if (maneuver == 0) return false;
                }
                speed--;
                if (speed == 0) return false;
            }

            return true;

        }
        
        public bool IsPointValid(Point p){
            if (!Map.GetInstance().IsPointLegal(p)) return false;
            foreach (Plane plane in GameEngine.GetInstance().Ork.Planes){
                if (plane.X == p.X && plane.Y == p.Y && plane.Z == p.Z) return false;
            }
            foreach (Plane plane in GameEngine.GetInstance().Imperialis.Planes){
                if (plane.X == p.X && plane.Y == p.Y && plane.Z == p.Z) return false;
            }
            return true;
        }
        
        public void CheckSpin() {
            if (_moveBehavior == new DefaultMoveBehavior()) {
                if (_speed > _maxSpeed || _speed < _minSpeed || Z > _maxAltitude) {
                    _moveBehavior = new SpinBehavior();
                }
            }

            if (_moveBehavior == new SpinBehavior()) {
                if (Dice.GetInstance().Roll() >= _handling) {
                    _moveBehavior = new DefaultMoveBehavior();
                }
            }
        }

        public void HitGround() {
            if (Z <= 0)
                _structure = 0;
        }

        public bool CanFire(Plane plane, Weapon weapon) {
            if (InFireArc(plane, weapon) && CheckRange(plane) != ERange.OUTOFRANGE)
                if (weapon.Ammo == 0){
                    Logger.GetInstance().Info("Out of Ammo");
                    return false;
                }
                return true;
        }
        public ERange CheckRange(Plane plane) {
            if (CalculateRoute(plane).Count <= 4) {
                return ERange.SHORT;
            }

            if (CalculateRoute(plane).Count > 4 && CalculateRoute(plane).Count <= 7) {
                return ERange.MEDIUM;
            }

            if (CalculateRoute(plane).Count > 7 && CalculateRoute(plane).Count <= 10) {
                return ERange.LONG;
            }

            return ERange.OUTOFRANGE;
        }

        public bool InFireArc(Plane plane, Weapon weapon) {
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

        public bool InNorthFireArc(Plane plane, EFireArc fireArc) {
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
        
        public bool InSouthFireArc(Plane plane, EFireArc fireArc) {
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
        
        public bool InWestFireArc(Plane plane, EFireArc fireArc) {
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
        
        public bool InEastFireArc(Plane plane, EFireArc fireArc) {
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
            int dice;
             if (CanFire(target,weapon)) {
                ERange range = CheckRange(target);
                switch (range) {
                    case ERange.SHORT:
                        for (int i = 0; i < weapon.Firepower[ERange.SHORT]; i++) {
                            dice = Dice.GetInstance().Roll();
                            if (dice >= weapon.Damage) {
                                target.Structure--;
                            }

                            if (dice >= weapon.Special) {
                                target.Structure--;
                            }
                        }
                        break;
                    case ERange.MEDIUM:
                        for (int i = 0; i < weapon.Firepower[ERange.MEDIUM]; i++) {
                            dice = Dice.GetInstance().Roll();
                            if (dice >= weapon.Damage) {
                                target.Structure--;
                            }

                            if (dice >= weapon.Special) {
                                target.Structure--;
                            }
                        }
                        break;
                    case ERange.LONG:
                        for (int i = 0; i < weapon.Firepower[ERange.LONG]; i++) {
                            dice = Dice.GetInstance().Roll();
                            if (dice >= weapon.Damage) {
                                target.Structure--;
                            }

                            if (dice >= weapon.Special) {
                                target.Structure--;
                            }
                        }
                        break;
                    case ERange.OUTOFRANGE:
                        Logger.GetInstance().Info("Target is out of Range");
                        break;
                }

                GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
                weapon.Ammo--;
             }
        }
        
        public void Move( Point destination) {
            X += destination.X;
            Y += destination.Y;
            Z += destination.Z;
            GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
        }
    }
}