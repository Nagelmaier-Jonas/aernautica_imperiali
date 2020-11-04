using System;

namespace aernautica_imperiali {
    class Program {
        static void Main(string[] args) {
            PlaneFactory factory = new PlaneFactory();
            Point p = new Point(1,1,1);
            Point p2 = new Point(2,2,3);
            GameEngine.GetInstance().PlacePlane(factory.Executioner(p,5));
            GameEngine.GetInstance().PlacePlane(factory.Hellion(p2,5));
            Map.GetInstance().PrintMap();
        }
    }
}