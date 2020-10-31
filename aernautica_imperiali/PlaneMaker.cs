namespace aernautica_imperiali {
    public class PlaneMaker : IPlaneFactory {
        public APlane BigBurna(Point p, int structure, int speed, int throttle, int minSpeed, int maxSpeed, int maneuver, int handling, int maxAltitude, int planeValue, bool spin, Weapon[] weapons, char type) {
            return new APlane(p, structure, speed, throttle, minSpeed, maxSpeed, maneuver, handling, maxAltitude, planeValue, spin, weapons, type);
        }

        public APlane BlueDevil(Point point, int speed) {
            return new BlueDevil(point, speed);
        }

        public APlane Executioner(Point point, int speed) {
            return new Executioner(point, speed);
        }

        public APlane GrotBommer(Point point, int speed) {
            return new GrotBommer(point, speed);
        }

        public APlane Hellion(Point point, int speed) {
            return new Hellion(point, speed);
        }

        public APlane Vulture(Point point, int speed) {
            return new Vulture(point, speed);
        }
    }
}