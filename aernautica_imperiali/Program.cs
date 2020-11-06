using System;
using System.Runtime.CompilerServices;

namespace aernautica_imperiali {
    class Program {
        static void Main(string[] args) {
            PlaneFactory factory = new PlaneFactory();
            Point p = new Point(1,1,1);
            Plane e = factory.Executioner(p, 1);
            e.CheckSpin();
            Console.WriteLine(e.MoveBehavior);
            
            //Round1
            
            //Round2
            
            //Round3
            
            //Round4
            
            //Round5
        }
    }
}