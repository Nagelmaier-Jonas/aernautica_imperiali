namespace aernautica_imperiali {
    public class PlaneMaker : IPlaneFactory {
        public APlane BigBurna(Point point, int speed) {
            return new BigBurna(point, speed);
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