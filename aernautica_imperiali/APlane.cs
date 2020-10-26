namespace aernautica_imperiali{
    public class APlane : Point{
        private int _structure;
        private int _speed;
        private int _throttle;
        private int _minSpeed;
        private int _maxSpeed;
        private int _maneuver;
        private int _handling;
        private int _altitude;
        private int _maxAltitude;
        private int _planeValue;

        public APlane(int x, int y, int z, int structure, int speed, int throttle, int minSpeed, int maxSpeed, int maneuver, int handling, int altitude, int maxAltitude, int planeValue) : base(x, y, z){
            _structure = structure;
            _speed = speed;
            _throttle = throttle;
            _minSpeed = minSpeed;
            _maxSpeed = maxSpeed;
            _maneuver = maneuver;
            _handling = handling;
            _altitude = altitude;
            _maxAltitude = maxAltitude;
            _planeValue = planeValue;
        }

        public int PlaneValue{
            get => _planeValue;
            set => _planeValue = value;
        }

        public int MaxAltitude{
            get => _maxAltitude;
            set => _maxAltitude = value;
        }

        public int Altitude{
            get => _altitude;
            set => _altitude = value;
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
    }
}