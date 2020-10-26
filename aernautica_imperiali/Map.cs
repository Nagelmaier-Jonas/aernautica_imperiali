using System.Collections.Generic;

namespace aernautica_imperiali{
    public class Map{
        public Point[,,] _points;

        public Map(Point[,,] points){
            _points = points;
        }
        
        public bool IsPointLegal(Point p)
        {
            if (p.X < _points.GetLength(0) && p.X > 0 && p.Y < _points.GetLength(1) && p.Y > 0 && p.X < _points.GetLength(2) && p.X > 0) return true;
            return false;
        }
    }
}