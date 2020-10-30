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
        

        public APlane(Point p, int structure, int speed, int throttle, int minSpeed, int maxSpeed, int maneuver, int handling, int maxAltitude, int planeValue, bool spin) : base(p.X,p.Y,p.Z){
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
        }

        public int PlaneValue{
            get => _planeValue;
            set => _planeValue = value;
        }

        public int MaxAltitude{
            get => _maxAltitude;
            set => _maxAltitude = value;
        }
        
        public int Handling{
            get => _handling;
            set => _handling = value;
        }

        public int Maneuver{
            get => _maneuver;
            set => _maneuver = value;
        }

        public int MaxSpeed{
            get => _maxSpeed;
            set => _maxSpeed = value;
        }

        public int MinSpeed{
            get => _minSpeed;
            set => _minSpeed = value;
        }

        public int Throttle{
            get => _throttle;
            set => _throttle = value;
        }

        public int Speed{
            get => _speed;
            set => _speed = value;
        }

        public int Structure{
            get => _structure;
            set => _structure = value;
        }
        
        public bool Spin {
            get => _spin;
            set => _spin = value;
        }
    }
}