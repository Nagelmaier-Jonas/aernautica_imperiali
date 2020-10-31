namespace aernautica_imperiali {
    public class PlaneMaker : IPlaneFactory {
        public APlane BigBurna(Point point, int speed, EOrientation orientation) {
            return new BigBurna(point, speed, orientation);
        }

        public APlane BlueDevil(Point point, int speed, EOrientation orientation) {
            return new BlueDevil(point, speed, orientation);
        }

        public APlane Executioner(Point point, int speed, EOrientation orientation) {
            return new Executioner(point, speed, orientation);
        }

        public APlane GrotBommer(Point point, int speed, EOrientation orientation) {
            return new GrotBommer(point, speed, orientation);
        }

        public APlane Hellion(Point point, int speed, EOrientation orientation) {
            return new Hellion(point, speed, orientation);
        }

        public APlane Vulture(Point point, int speed, EOrientation orientation) {
            return new Vulture(point, speed, orientation);
        }
    }
}