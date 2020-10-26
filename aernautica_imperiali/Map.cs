using System.Collections.Generic;

namespace aernautica_imperiali{
    public class Map{
        private List<Point> points = new List<Point>();

        public Map(){
        }

        public List<Point> Points{
            get => points;
            set => points = value;
        }
    }
}