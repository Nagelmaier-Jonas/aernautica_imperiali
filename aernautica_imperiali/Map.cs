using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace aernautica_imperiali {
    public class Map {
        private static Map _instance = new Map();
        private Point[,,] _content = new Point[15, 15, 15];

        public static Map GetInstance() {
            return _instance;
        }

        private Map() {
            for (int i = 0; i < _content.GetLength(2); i++) {
                for (int j = 0; j < _content.GetLength(1); j++) {
                    for (int k = 0; k < _content.GetLength(0); k++) {
                        _content[k, j, i] = new Point(k, j, i);
                    }
                }
            }
        }

        public bool IsPointLegal(Point p) {
            if (p.X < _content.GetLength(0) && p.X >= 0 && p.Y < _content.GetLength(1) && p.Y >= 0 &&
                p.X < _content.GetLength(2) && p.X >= 0) return true;
            return false;
        }

        public bool IsSame(Plane plane, Point p) {
            if (plane.X == p.X && plane.Y == p.Y && plane.Z == p.Z)
                return true;
            return false;
        }

        public void PrintMap() {
            bool[] height = new bool[15];

            for (int i = 0; i < _content.GetLength(2); i++) {
                for (int j = 0; j < _content.GetLength(1); j++) {
                    for (int k = 0; k < _content.GetLength(0); k++) {
                        if (GetPlanePoints().Contains(_content[k, j, i])) {
                            foreach (Plane plane in GameEngine.GetInstance().Imperialis.Planes) {
                                if (IsSame(plane, _content[k, j, i])) {
                                    height[i] = true;
                                }
                            }

                            foreach (Plane plane in GameEngine.GetInstance().Ork.Planes) {
                                if (IsSame(plane, _content[k, j, i])) {
                                    height[i] = true;
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < _content.GetLength(2); i++) {
                for (int j = 0; j < _content.GetLength(1); j++) {
                    for (int k = 0; k < _content.GetLength(0); k++) {
                        if (GetPlanePoints().Contains(_content[k, j, i])) {
                            foreach (Plane plane in GameEngine.GetInstance().Imperialis.Planes) {
                                if (IsSame(plane, _content[k, j, i]) && height[i]) {
                                    Console.Write(Char.ToUpperInvariant(plane.Type));
                                    Console.Write(GameEngine.GetInstance().Imperialis.Planes.IndexOf(plane));
                                }
                            }

                            foreach (Plane plane in GameEngine.GetInstance().Ork.Planes) {
                                if (IsSame(plane, _content[k, j, i]) && height[i]) {
                                    Console.Write(Char.ToUpperInvariant(plane.Type));
                                    Console.Write(GameEngine.GetInstance().Ork.Planes.IndexOf(plane));
                                }
                            }
                        }
                        else {
                            if (height[i]) {
                                Console.Write("- ");
                            }
                        }
                    }

                    if (height[i]) {
                        Console.WriteLine();
                    }
                }

                if (height[i]) {
                    Console.WriteLine();
                }

                if (i + 1 < _content.GetLength(2) && height[i + 1]) {
                    Console.WriteLine("         Ebene: " + (i + 1));
                }
            }
        }

        public List<Point> GetPlanePoints() {
            List<Point> planePoints = new List<Point>();
            foreach (Plane plane in GameEngine.GetInstance().Imperialis.Planes) {
                planePoints.Add(new Point(plane.X, plane.Y, plane.Z));
            }

            foreach (Plane plane in GameEngine.GetInstance().Ork.Planes) {
                planePoints.Add(new Point(plane.X, plane.Y, plane.Z));
            }

            return planePoints;
        }
    }
}