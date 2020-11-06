using System;
using System.Runtime.CompilerServices;

namespace aernautica_imperiali {
    class Program {
        static void Main(string[] args) {
            PlaneFactory factory = new PlaneFactory();
            Plane e = factory.Executioner(new Point(0, 0, 12), 1);
            ;
        }
    }
}