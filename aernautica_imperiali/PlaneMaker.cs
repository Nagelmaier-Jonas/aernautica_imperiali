namespace aernautica_imperiali {
    public class PlaneMaker : IPlaneFactory {
        public Plane BigBurna(Point p, int speed) {
            return new Plane(p, 3, speed, 2, 3, 7, 4, 4, 4, 22, false, weapons, EOrientation.SOUTH, 'b');
        }

        public Plane BlueDevil(Point p, int speed) {
            return new Plane(p, 5, speed, 1, 2, 5, 3, 3, 5, 26, false, weapons, EOrientation.NORTH, 'd');
        }

        public Plane Executioner(Point p, int speed) {
            return new Executioner(p, 3, speed, 2, 2, 7, 6, 3, 5, 23, false, weapons, EOrientation.NORTH, 'e');
        }

        public Plane GrotBommer(Point p, int speed) {
            return new GrotBommer(p, 6, speed, 1, 2, 4, 3, 5, 4, 28, false, weapons, EOrientation.SOUTH, 'g');
        }

        public Plane Hellion(Point p, int speed) {
            return new Hellion(p, speed);
        }

        public Plane Vulture(Point p, int speed) {
            return new Vulture(p, speed);
        }
    }
}