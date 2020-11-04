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
            return false;
        }

        public void PrintMap() {
            for (int i = 0; i < _content.GetLength(2); i++) {
                for (int j = 0; j < _content.GetLength(1); j++) {
                    for (int k = 0; k < _content.GetLength(0); k++) {
                        if (GetPlanePoints().Contains(_content[k,j,i])) {
                            foreach (Plane plane in GameEngine.GetInstance().Imperialis.Planes) {
                                if(IsSame(plane,_content[k,j,i]))
                                    Console.Write(Char.ToUpperInvariant(plane.Type));
                            }
                            foreach (Plane plane in GameEngine.GetInstance().Ork.Planes) {
                                if(IsSame(plane,_content[k,j,i]))
                                    Console.Write(Char.ToUpperInvariant(plane.Type));
                            }
                        }
                        else {
                            Console.Write("-");
                        }
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public List<Point> GetPlanePoints() {
            List<Point> planePoints = new List<Point>();
            foreach (Plane plane in GameEngine.GetInstance().Imperialis.Planes) {
                planePoints.Add(new Point(plane.X,plane.Y,plane.Z));
            }
            foreach (Plane plane in GameEngine.GetInstance().Ork.Planes) {
                planePoints.Add(new Point(plane.X,plane.Y,plane.Z));
            }
            return planePoints;
        }
        
    }
}