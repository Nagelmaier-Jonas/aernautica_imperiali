using System;

namespace aernautica_imperiali {
    class Program {
        static void Main(string[] args) {
            PlaneFactory factory = new PlaneFactory();
            Point p = new Point(1,1,1);
            GameEngine.GetInstance().Imperialis.Planes.Add(factory.Executioner(p,3));
            Map.GetInstance().PrintMap();
        }
    }
}