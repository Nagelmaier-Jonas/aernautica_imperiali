using System.Collections.Generic;

namespace aernautica_imperiali {
    public class GameEngine {
        private static GameEngine _instance = new GameEngine();
        private Player _imperialis;
        private Player _ork;
        private GameEngine() {
        }

        public Player Imperialis {
            get => _imperialis;
            set => _imperialis = value;
        }

        public Player Ork {
            get => _ork;
            set => _ork = value;
        }

        public static GameEngine GetInstance() {
            return _instance;
        }
        
        public bool IsMoveLegal(APlane plane, Point destination) {
            foreach (Point p in plane.CalculateRoute(destination)){
                if (!IsPointValid(p)) return false;
            }

            int speed = plane.Speed;
            int maneuver = plane.Maneuver;

            for (int i = 0; i < plane.CalculateRoute(destination).Count; i++){
                if (plane.CalculateRoute(destination)[i].X != plane.CalculateRoute(destination)[i++].X &&
                    plane.CalculateRoute(destination)[i].Y != plane.CalculateRoute(destination)[i++].Y){
                    maneuver--;
                    if (maneuver == 0) return false;
                }
                speed--;
                if (speed == 0) return false;
            }

            return true;

        }

        public void MovePlane(APlane plane, Point destination) {
            if (IsMoveLegal(plane, destination)){
                plane.Move(destination);
                for (int i = 0; i < plane.CalculateRoute(destination).Count; i++){
                    if (plane.CalculateRoute(destination)[i].X != plane.CalculateRoute(destination)[i++].X &&
                        plane.CalculateRoute(destination)[i].Y != plane.CalculateRoute(destination)[i++].Y){
                        plane.Maneuver--;
                    }
                    plane.Speed--;
                }
            }
        }

        public bool IsPointValid(Point p){
            if (!Map.GetInstance().IsPointLegal(p)) return false;
                foreach (APlane plane in _ork.Planes){
                    if (plane.X == p.X && plane.Y == p.Y && plane.Z == p.Z) return false;
                }
                foreach (APlane plane in _imperialis.Planes){
                    if (plane.X == p.X && plane.Y == p.Y && plane.Z == p.Z) return false;
                }
                return true;
        }

        public bool CheckSpin() {
            return true;
        }

        public void HandlingTest() {
            
        }
    }
}