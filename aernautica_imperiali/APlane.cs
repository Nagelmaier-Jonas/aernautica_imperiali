namespace aernautica_imperiali{
    public class APlane : Point{
        private int _structure;
        private int _speed;
        private int _throttle;
        private int _minSpeed;
        private int _maxSpeed;
        private int _maneuver;
        private int _handling;
        private int _maxAltitude;
        private int _planeValue;
        private bool _spin;
        private AWeapon[] _weapons;

        public APlane(Point p, int structure, int speed, int throttle, int minSpeed, int maxSpeed, int maneuver, int handling, int maxAltitude, int planeValue, bool spin, AWeapon[] weapons) : base(p.X,p.Y,p.Z){
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

        public AWeapon[] Weapons => _weapons;

        public bool IsMoveLegal(Point destination) {
            return true;
            return false;
        }

        public void MovePlane(Point destination) {
            
        }
        
    }
}