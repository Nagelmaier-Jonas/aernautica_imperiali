using System.Collections.Generic;

namespace aernautica_imperiali{
    public class Map{
        private static Map _instance = new Map();
        private Point[,,] _content = new Point[15, 15, 15];

        public static Map GetInstance() {
            return _instance;
        }
        private Map() {
            for (int i = 0; i < _content.GetLength(2); i++) {
                for (int j = 0; j < _content.GetLength(1); j++) {
                    for (int k = 0; k < _content.GetLength(0); k++) {
                        _content[k, j, i] = new Point(j, i,k);
                    }
                }
            }
        }
        
        public bool IsPointLegal(Point p)
        {
            if (p.X < _content.GetLength(0) && p.X > 0 && p.Y < _content.GetLength(1) && p.Y > 0 && p.X < _content.GetLength(2) && p.X > 0) return true;
            return false;
        }
    }
}