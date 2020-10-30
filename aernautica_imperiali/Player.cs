namespace aernautica_imperiali {
    public class Player {
        private int _points;
        private int _startPoints;
        private APlane[] _planes;

        public Player() {
            _points = 0;
            _startPoints = 150;
        }

        public APlane[] Planes {
            get => _planes;
            set => _planes = value;
        }
    }
}