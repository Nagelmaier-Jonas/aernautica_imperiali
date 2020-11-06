using System;
using System.Collections.Generic;

namespace aernautica_imperiali{
    public class Point{
        
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
        
        public List<Point> CalculateRoute(Point destination){
            int deltax = (_x < destination.X) ? 1 : (_x == destination.X) ? 0 : -1;
            int deltay = (_y < destination.Y) ? 1 : (_y == destination.Y) ? 0 : -1;
            int deltaz = (_z < destination.Z) ? 1 : (_z == destination.Z) ? 0 : -1;
            int stepCountx = Math.Abs(_x - destination.X);
            int stepCounty = Math.Abs(_y - destination.Y);
            int stepCountz = Math.Min(Math.Max(stepCountx,stepCounty), Math.Abs(_z - destination.Z));
            
            List<Point> Points = new List<Point>();

            for (int i = 1, j = 1, k = 1, step = 0;step < Math.Max(stepCountx,stepCounty); step++){
                Points.Add(new Point(_x + (i * deltax),_y + (j * deltay), _z + (k * deltaz)));

                if (i < stepCountx) i++;
                if (j < stepCounty) j++;
                if (k < stepCountz) k++;
            }

            return Points;
        }
        
        public override int GetHashCode(){
            unchecked{
                var hashCode = _x;
                hashCode = (hashCode * 397) ^ _y;
                hashCode = (hashCode * 397) ^ _z;
                return hashCode;
            }
        }
        public override bool Equals(object obj){
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point) obj);
        }
        protected bool Equals(Point other){ 
            return _x == other._x && _y == other._y && _z == other._z;
        }
        public override string ToString(){
            return $"{nameof(_x)}: {_x}, {nameof(_y)}: {_y}, {nameof(_z)}: {_z}";
        }
    }
}