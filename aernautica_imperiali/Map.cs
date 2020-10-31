using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

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

        public bool IsSame(Plane plane, Point p) {
            if (plane.X == p.X && plane.Y == p.Y && plane.Z == p.Z)
                return true;
            else
                return false;
        }
        
        public void PrintMap() {
            for (int i = 0; i < _content.GetLength(2); i++) {
                for (int j = 0; j < _content.GetLength(1); j++) {
                    for (int k = 0; k < _content.GetLength(0); k++) {
                        if (GameEngine.GetInstance().Imperialis.Planes.Contains(_content[k, j, i])) {
                            foreach (var plane in GameEngine.GetInstance().Imperialis.Planes) {
                                if (IsSame(plane, _content[k, j, i])) {
                                    Console.WriteLine(_content[k, j, i].ToString());
                                }
                            }
                        }
                        else if (GameEngine.GetInstance().Ork.Planes.Contains(_content[k, j, i])) {
                            foreach (var plane in GameEngine.GetInstance().Ork.Planes) {
                                if (IsSame(plane, _content[k, j, i])) {
                                    Console.WriteLine(_content[k, j, i].ToString());
                                }
                            }
                        }
                        else {
                            Console.WriteLine("-");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}