using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace aernautica_imperiali {
    class Program {
        static void Main(string[] args) {
            //Place

            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(2, 1, 3), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(2, 13, 3), 3));
            
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(5, 2, 3), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(5, 12, 3), 3));
            
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(8, 1, 3), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(8, 13, 3), 3));
            
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(12, 2, 3), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(12, 12, 3), 3));
            
            Map.GetInstance().PrintMap("place"); // PlacePlane
            
            //Move
            GameEngine.GetInstance().GetImperialis(0).Move(new Point(2, 2, 3), -2);
            GameEngine.GetInstance().GetOrk(0).Move(new Point(2, 11, 3), -1);
            
            GameEngine.GetInstance().GetImperialis(1).Move(new Point(5, 4, 3), -1);
            GameEngine.GetInstance().GetOrk(1).Move(new Point(5, 10, 3), -1);
            
            GameEngine.GetInstance().GetImperialis(2).Move(new Point(8, 3, 3), -1);
            GameEngine.GetInstance().GetOrk(2).Move(new Point(8, 11, 3), -1);
            
            GameEngine.GetInstance().GetImperialis(3).Move(new Point(12, 4, 3), -1);
            GameEngine.GetInstance().GetOrk(3).Move(new Point(12, 10, 3), -1);

            Map.GetInstance().PrintMap("move"); // MovePlane

            //Fire
            GameEngine.GetInstance().GetImperialis(0).Fire(0,0);
            GameEngine.GetInstance().GetOrk(0).Fire(0,0);
            
            GameEngine.GetInstance().GetImperialis(1).Fire(1,0);
            GameEngine.GetInstance().GetOrk(1).Fire(1,0);
            
            GameEngine.GetInstance().GetImperialis(2).Fire(2,0);
            GameEngine.GetInstance().GetOrk(2).Fire(2,0);
            
            GameEngine.GetInstance().GetImperialis(3).Fire(3,0);
            GameEngine.GetInstance().GetOrk(3).Fire(3,0);
            
            Map.GetInstance().PrintMap("fire"); // Fire
            GameEngine.GetInstance().EndTurn();

            //Move
            GameEngine.GetInstance().GetImperialis(0).Move(new Point(2, 4, 3), 1);
            GameEngine.GetInstance().GetOrk(0).Move(new Point(2, 9, 3), 0);
            
            GameEngine.GetInstance().GetImperialis(1).Move(new Point(5, 6, 3), 0);
            GameEngine.GetInstance().GetOrk(1).Move(new Point(5, 8, 3), 0);
            
            GameEngine.GetInstance().GetImperialis(2).Move(new Point(8, 5, 3), 0);
            GameEngine.GetInstance().GetOrk(2).Move(new Point(8, 9, 3), 0);
            
            GameEngine.GetInstance().GetImperialis(3).Move(new Point(12, 6, 3), 0);
            GameEngine.GetInstance().GetOrk(3).Move(new Point(12, 8, 3), 0);

            Map.GetInstance().PrintMap("move"); // MovePlane

            //Fire
            
            GameEngine.GetInstance().GetImperialis(0).Fire(0,0);
            GameEngine.GetInstance().GetOrk(0).Fire(0,0);
            
            GameEngine.GetInstance().GetImperialis(1).Fire(1,0);
            GameEngine.GetInstance().GetOrk(1).Fire(1,0);
            
            GameEngine.GetInstance().GetImperialis(2).Fire(2,0);
            GameEngine.GetInstance().GetOrk(2).Fire(2,0);
            
            GameEngine.GetInstance().GetImperialis(3).Fire(3,0);
            GameEngine.GetInstance().GetOrk(3).Fire(3,0);
            
            Map.GetInstance().PrintMap("fire"); // Fire
            GameEngine.GetInstance().EndTurn();

            //Move
            GameEngine.GetInstance().GetImperialis(0).Move(new Point(2, 6, 3), 0);
            GameEngine.GetInstance().GetOrk(0).Move(new Point(2, 7, 3), 0);
            
            GameEngine.GetInstance().GetImperialis(1).Move(new Point(5, 4, 3), 0);
            GameEngine.GetInstance().GetOrk(1).Move(new Point(5, 6, 3), 0);
            
            GameEngine.GetInstance().GetImperialis(2).Move(new Point(8, 7, 3), 0);
            GameEngine.GetInstance().GetOrk(2).Move(new Point(8, 11, 3), 0);
            
            GameEngine.GetInstance().GetImperialis(3).Move(new Point(12, 4, 3), 0);
            GameEngine.GetInstance().GetOrk(3).Move(new Point(12, 6, 3), 0);

            Map.GetInstance().PrintMap("move"); // MovePlane

            //Fire
            
            GameEngine.GetInstance().GetImperialis(0).Fire(0,0);
            GameEngine.GetInstance().GetOrk(0).Fire(0,0);
            
            GameEngine.GetInstance().GetImperialis(1).Fire(1,0);
            GameEngine.GetInstance().GetOrk(1).Fire(1,0);
            
            GameEngine.GetInstance().GetImperialis(2).Fire(2,0);
            GameEngine.GetInstance().GetOrk(2).Fire(2,0);
            
            GameEngine.GetInstance().GetImperialis(3).Fire(3,0);
            GameEngine.GetInstance().GetOrk(3).Fire(3,0);
            
            Map.GetInstance().PrintMap("fire"); // Fire
            GameEngine.GetInstance().EndTurn();

            //Move
            GameEngine.GetInstance().GetImperialis(0).Move(new Point(2, 4, 3), 0);
            GameEngine.GetInstance().GetOrk(0).Move(new Point(2, 5, 3), 0);
            
            GameEngine.GetInstance().GetImperialis(1).Move(new Point(5, 2, 3), 0);
            GameEngine.GetInstance().GetOrk(1).Move(new Point(5, 4, 3), 0);
            
            GameEngine.GetInstance().GetImperialis(2).Move(new Point(8, 5, 3), 0);
            GameEngine.GetInstance().GetOrk(2).Move(new Point(8, 9, 3), 0);
            
            GameEngine.GetInstance().GetImperialis(3).Move(new Point(12, 2, 3), 0);
            GameEngine.GetInstance().GetOrk(3).Move(new Point(12, 4, 3), 0);

            Map.GetInstance().PrintMap("move"); // MovePlane

            //Fire
            
            GameEngine.GetInstance().GetImperialis(0).Fire(0,0);
            GameEngine.GetInstance().GetOrk(0).Fire(0,0);
            
            GameEngine.GetInstance().GetImperialis(1).Fire(1,0);
            GameEngine.GetInstance().GetOrk(1).Fire(1,0);
            
            GameEngine.GetInstance().GetImperialis(2).Fire(2,0);
            GameEngine.GetInstance().GetOrk(2).Fire(2,0);
            
            GameEngine.GetInstance().GetImperialis(3).Fire(3,0);
            GameEngine.GetInstance().GetOrk(3).Fire(3,0);
            
            Map.GetInstance().PrintMap("fire"); // Fire
            GameEngine.GetInstance().EndTurn();

            //Move
            GameEngine.GetInstance().GetImperialis(0).Move(new Point(2, 2, 3), 0);
            GameEngine.GetInstance().GetOrk(0).Move(new Point(2, 3, 3), 0);
            
            GameEngine.GetInstance().GetImperialis(1).Move(new Point(5, 0, 3), 0);
            GameEngine.GetInstance().GetOrk(1).Move(new Point(5, 2, 3), 0);
            
            GameEngine.GetInstance().GetImperialis(2).Move(new Point(8, 3, 3), 0);
            GameEngine.GetInstance().GetOrk(2).Move(new Point(8, 7, 3), 0);
            
            GameEngine.GetInstance().GetImperialis(3).Move(new Point(12, 0, 3), 0);
            GameEngine.GetInstance().GetOrk(3).Move(new Point(12, 2, 3), 0);

            Map.GetInstance().PrintMap("move"); // MovePlane

            //Fire
            GameEngine.GetInstance().GetImperialis(0).Fire(0,0);
            GameEngine.GetInstance().GetOrk(0).Fire(0,0);
            
            GameEngine.GetInstance().GetImperialis(1).Fire(1,0);
            GameEngine.GetInstance().GetOrk(1).Fire(1,0);
            
            GameEngine.GetInstance().GetImperialis(2).Fire(2,0);
            GameEngine.GetInstance().GetOrk(2).Fire(2,0);
            
            GameEngine.GetInstance().GetImperialis(3).Fire(3,0);
            GameEngine.GetInstance().GetOrk(3).Fire(3,0);
            
            Map.GetInstance().PrintMap("fire"); // Fire
            GameEngine.GetInstance().EndTurn();

            Console.WriteLine("WE ARE THE CHAMPIONS");
        }
    }
}