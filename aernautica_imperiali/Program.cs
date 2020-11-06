using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace aernautica_imperiali {
    class Program {
        static void Main(string[] args) {
            
            //Place
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(0,1,2), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(2,2,4), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(4,1,3), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(6,2,2), 3));

            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(2,12,2), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(4,13,4), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(6,12,3), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(8,14,2), 3));
            
            Map.GetInstance().PrintMap(); // PlacePlane
            
            //Move
            GameEngine.GetInstance().Imperialis.Planes[0].MoveBehavior.Move(GameEngine.GetInstance().Imperialis.Planes[0],new Point(1,4,2), 0);
            GameEngine.GetInstance().Ork.Planes[0].MoveBehavior.Move(GameEngine.GetInstance().Ork.Planes[0], new Point(3,10,3), 0);

            GameEngine.GetInstance().Imperialis.Planes[1].MoveBehavior.Move(GameEngine.GetInstance().Imperialis.Planes[1], new Point(2,4,3), 0);
            GameEngine.GetInstance().Ork.Planes[1].MoveBehavior.Move(GameEngine.GetInstance().Ork.Planes[1], new Point(6,10,3), 0);
            
            GameEngine.GetInstance().Imperialis.Planes[2].MoveBehavior.Move(GameEngine.GetInstance().Imperialis.Planes[2], new Point(5,4,5), 0);
            GameEngine.GetInstance().Ork.Planes[2].MoveBehavior.Move(GameEngine.GetInstance().Ork.Planes[2], new Point(5,9,4), 0);
            
            GameEngine.GetInstance().Imperialis.Planes[3].MoveBehavior.Move(GameEngine.GetInstance().Imperialis.Planes[3], new Point(7,5,3), 0);
            GameEngine.GetInstance().Ork.Planes[3].MoveBehavior.Move(GameEngine.GetInstance().Ork.Planes[3], new Point(8,12,4), 0);
            
            Map.GetInstance().PrintMap(); // MovePlane
            
            //Fire
            
            GameEngine.GetInstance().Imperialis.Planes[0].MoveBehavior.Fire(GameEngine.GetInstance().Imperialis.Planes[0],GameEngine.GetInstance().Ork.Planes[0], WeaponFactory.QuadAutocannon());
            GameEngine.GetInstance().Ork.Planes[0].MoveBehavior.Fire(GameEngine.GetInstance().Ork.Planes[0], GameEngine.GetInstance().Imperialis.Planes[0], WeaponFactory.QuadBigShootas());

            GameEngine.GetInstance().Imperialis.Planes[1].MoveBehavior.Fire(GameEngine.GetInstance().Imperialis.Planes[1],GameEngine.GetInstance().Ork.Planes[1], WeaponFactory.QuadAutocannon());
            GameEngine.GetInstance().Ork.Planes[1].MoveBehavior.Fire(GameEngine.GetInstance().Ork.Planes[1], GameEngine.GetInstance().Imperialis.Planes[1], WeaponFactory.QuadBigShootas());
            
            GameEngine.GetInstance().Imperialis.Planes[2].MoveBehavior.Fire(GameEngine.GetInstance().Imperialis.Planes[2],GameEngine.GetInstance().Ork.Planes[2], WeaponFactory.QuadAutocannon());
            GameEngine.GetInstance().Ork.Planes[2].MoveBehavior.Fire(GameEngine.GetInstance().Ork.Planes[2], GameEngine.GetInstance().Imperialis.Planes[2], WeaponFactory.QuadBigShootas());
            
            GameEngine.GetInstance().Imperialis.Planes[3].MoveBehavior.Fire(GameEngine.GetInstance().Imperialis.Planes[3],GameEngine.GetInstance().Ork.Planes[3], WeaponFactory.QuadAutocannon());
            GameEngine.GetInstance().Ork.Planes[3].MoveBehavior.Fire(GameEngine.GetInstance().Ork.Planes[3], GameEngine.GetInstance().Imperialis.Planes[3], WeaponFactory.QuadBigShootas());
            
            Map.GetInstance().PrintMap(); // Fire

            Console.WriteLine("WE ARE THE CHAMPIONS");
        }
    }
}