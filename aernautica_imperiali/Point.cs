namespace aernautica_imperiali{
    public class Point{
        protected bool Equals(Point other){
            return _x == other._x && _y == other._y && _z == other._z;
        }

        public override int GetHashCode(){
            unchecked{
                var hashCode = _x;
                hashCode = (hashCode * 397) ^ _y;
                hashCode = (hashCode * 397) ^ _z;
                return hashCode;
            }
        }

        private int _x;
        private int _y;
        private int _z;

        public Point(int x, int y, int z){
            _x = x;
            _y = y;
            _z = z;
        }

        public int Z{
            get => _z;
            set => _z = value;
        }

        public int Y{
            get => _y;
            set => _y = value;
        }

        public int X{
            get => _x;
            set => _x = value;
        }

        public override bool Equals(object obj){
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point) obj);
        }

        public override string ToString(){
            return $"{nameof(_x)}: {_x}, {nameof(_y)}: {_y}, {nameof(_z)}: {_z}";
        }
    }
}