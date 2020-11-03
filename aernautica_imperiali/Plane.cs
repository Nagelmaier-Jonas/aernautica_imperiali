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

        public Plane(Point p, int structure, int speed, int throttle, int minSpeed, int maxSpeed, int maneuver, int handling, int maxAltitude, int planeValue, Weapon[] weapons, EOrientation orientation, char type) : base(p.X,p.Y,p.Z){
            _structure = structure;
            _speed = speed;
            _throttle = throttle;
            _minSpeed = minSpeed;
            _maxSpeed = maxSpeed;
            _maneuver = maneuver;
            _handling = handling;
            _maxAltitude = maxAltitude;
            _planeValue = planeValue;
            _spin = spin;
            _weapons = weapons;
            _orientation = orientation;
            _type = type;
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

        public bool Spin {
            get => _spin;
            set => _spin = value;
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
            if (_speed > _maxSpeed || _speed < _minSpeed || Z > _maxAltitude)
                _spin = true;
            _spin = false;
        }
        
        public void HandlingTest() {
            if (Dice.getInstance().Roll() >= _handling)
                //No Spin
            //Spin

        }

        public void HitGround() {
            if (Z <= 0)
                _structure = 0;
        }
        
    }
}