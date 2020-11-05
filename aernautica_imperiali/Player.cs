using System.Collections.Generic;

namespace aernautica_imperiali {
    public class Player {
        private int _points;
        private int _startPoints;
        private List<Plane> _planes = new List<Plane>();

        public Player() {
            _points = 0;
            _startPoints = 150;
        }

        public List<Plane> Planes {
            get => _planes;
            set => _planes = value;
        }

        public int Points {
            get => _points;
            set => _points = value;
        }

        public int StartPoints {
            get => _startPoints;
            set => _startPoints = value;
        }
    }
}