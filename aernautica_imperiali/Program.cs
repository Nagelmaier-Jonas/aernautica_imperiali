﻿using System;
using System.Runtime.CompilerServices;

namespace aernautica_imperiali {
    class Program {
        static void Main(string[] args) {
            PlaneFactory factory = new PlaneFactory();

            GameEngine.GetInstance().PlacePlane(factory.Executioner(new Point(0,1,2), 3));
            GameEngine.GetInstance().PlacePlane(factory.Executioner(new Point(2,2,4), 3));
            GameEngine.GetInstance().PlacePlane(factory.Hellion(new Point(4,1,3), 3));
            GameEngine.GetInstance().PlacePlane(factory.BlueDevil(new Point(6,2,2), 3));
            GameEngine.GetInstance().PlacePlane(factory.Executioner(new Point(9,1,3), 3));
            GameEngine.GetInstance().PlacePlane(factory.BlueDevil(new Point(13,2,1), 3));
            
            GameEngine.GetInstance().PlacePlane(factory.BigBurna(new Point(2,12,2), 3));
            GameEngine.GetInstance().PlacePlane(factory.GrotBommer(new Point(4,13,4), 3));
            GameEngine.GetInstance().PlacePlane(factory.GrotBommer(new Point(6,12,3), 3));
            GameEngine.GetInstance().PlacePlane(factory.Vulture(new Point(8,14,2), 3));
            GameEngine.GetInstance().PlacePlane(factory.Vulture(new Point(11,13,3), 3));
            GameEngine.GetInstance().PlacePlane(factory.BigBurna(new Point(13,12,3), 3));
            
            //Round 1
            //GameEngine.GetInstance().Imperialis.Planes[0].MoveBehavior.Move(GameEngine.GetInstance().Imperialis.Planes[0],new Point(1,4,2), 0);
            //GameEngine.GetInstance().Ork.Planes[0].Move(new Point(3,9,3));
            
            //GameEngine.GetInstance().Imperialis.Planes[1].Move(new Point(2,4,3));
            //GameEngine.GetInstance().Ork.Planes[1].Move(new Point(4,10,5));
            
            //GameEngine.GetInstance().Imperialis.Planes[2].Move(new Point(5,4,5));
            //GameEngine.GetInstance().Ork.Planes[2].Move(new Point(5,9,4));
            
            //GameEngine.GetInstance().Imperialis.Planes[3].Move(new Point(7,5,3));
            //GameEngine.GetInstance().Ork.Planes[3].Move(new Point(8,12,4));
            
            //GameEngine.GetInstance().Imperialis.Planes[4].Move(new Point(8,5,3));
            //GameEngine.GetInstance().Ork.Planes[4].Move(new Point(11,10,2));
            
            //GameEngine.GetInstance().Imperialis.Planes[5].Move(new Point(13,4,1));
            //GameEngine.GetInstance().Ork.Planes[5].Move(new Point(13,10,5));
            
            Map.GetInstance().PrintMap();

        }
    }
}