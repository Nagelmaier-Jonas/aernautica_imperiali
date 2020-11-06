using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace aernautica_imperiali {
    class Program {
        static void Main(string[] args) {

            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(0,1,2), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(2,2,4), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Hellion(new Point(4,1,3), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.BlueDevil(new Point(6,2,2), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Executioner(new Point(9,1,3), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.BlueDevil(new Point(13,2,1), 3));
            
            GameEngine.GetInstance().PlacePlane(PlaneFactory.BigBurna(new Point(2,12,2), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(4,13,4), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.GrotBommer(new Point(6,12,3), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(8,14,2), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.Vulture(new Point(11,13,3), 3));
            GameEngine.GetInstance().PlacePlane(PlaneFactory.BigBurna(new Point(13,12,3), 3));
            
            //Round 1
            Map.GetInstance().PrintMap();
            Thread.Sleep(10000);
            Console.Clear();
            GameEngine.GetInstance().Imperialis.Planes[0].MoveBehavior.Move(GameEngine.GetInstance().Imperialis.Planes[0],new Point(1,4,2), 0);
            Map.GetInstance().PrintMap();
            Thread.Sleep(10000);
            Console.Clear();
            GameEngine.GetInstance().Ork.Planes[0].MoveBehavior.Move(GameEngine.GetInstance().Imperialis.Planes[0], new Point(3,9,3), 0);
            Map.GetInstance().PrintMap();
            Thread.Sleep(10000);
            Console.Clear();
            
            /*GameEngine.GetInstance().Imperialis.Planes[1].MoveBehavior.Move(GameEngine.GetInstance().Imperialis.Planes[1], new Point(2,4,3), 0);
            GameEngine.GetInstance().Ork.Planes[1].MoveBehavior.Move(GameEngine.GetInstance().Ork.Planes[1], new Point(4,10,5), 0);
            
            GameEngine.GetInstance().Imperialis.Planes[2].MoveBehavior.Move(GameEngine.GetInstance().Imperialis.Planes[2], new Point(5,4,5), 0);
            GameEngine.GetInstance().Ork.Planes[2].MoveBehavior.Move(GameEngine.GetInstance().Ork.Planes[2], new Point(5,9,4), 0);
            
            GameEngine.GetInstance().Imperialis.Planes[3].MoveBehavior.Move(GameEngine.GetInstance().Imperialis.Planes[3], new Point(7,5,3), 0);
            GameEngine.GetInstance().Ork.Planes[3].MoveBehavior.Move(GameEngine.GetInstance().Ork.Planes[3], new Point(8,12,4), 0);
            
            GameEngine.GetInstance().Imperialis.Planes[4].MoveBehavior.Move(GameEngine.GetInstance().Imperialis.Planes[4], new Point(8,5,3), 0);
            GameEngine.GetInstance().Ork.Planes[4].MoveBehavior.Move(GameEngine.GetInstance().Ork.Planes[4], new Point(11,10,2), 0);
            
            GameEngine.GetInstance().Imperialis.Planes[5].MoveBehavior.Move(GameEngine.GetInstance().Imperialis.Planes[4], new Point(13,4,1), 0);
            GameEngine.GetInstance().Ork.Planes[5].MoveBehavior.Move(GameEngine.GetInstance().Ork.Planes[4],new Point(13,10,5), 0);
            
            Map.GetInstance().PrintMap();

            Console.WriteLine("WE ARE THE CHAMPIONS");*/
        }
    }
}