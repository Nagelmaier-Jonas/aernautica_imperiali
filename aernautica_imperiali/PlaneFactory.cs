namespace aernautica_imperiali {
    public class PlaneFactory : IPlaneFactory {
        
        WeaponFactory _weaponFactory = new WeaponFactory();
        
        public Plane BigBurna(Point p, int speed) {
            return new Plane(p, 3, speed, 2, 3, 7, 4, 4, 4, 22, new []{_weaponFactory.QuadBigShootas(), _weaponFactory.TurretBigShootas(), _weaponFactory.TailGun()}, EOrientation.SOUTH, 'b');
        }

        public Plane BlueDevil(Point p, int speed) {
            return new Plane(p, 5, speed, 1, 2, 5, 3, 3, 5, 26, new []{_weaponFactory.Lascannon(), _weaponFactory.DorsalTurret(), _weaponFactory.RearTurret(), _weaponFactory.Lascannon(), _weaponFactory.BombBay()}, EOrientation.NORTH, 'd');
        }

        public Plane Executioner(Point p, int speed) {
            return new Plane(p, 3, speed, 2, 2, 7, 6, 3, 5, 23, new []{_weaponFactory.QuadAutocannon(), _weaponFactory.TwinLascannon()}, EOrientation.NORTH, 'e');
        }

        public Plane GrotBommer(Point p, int speed) {
            return new Plane(p, 6, speed, 1, 2, 4, 3, 5, 4, 28, new []{_weaponFactory.QuadBigShootas(), _weaponFactory.PortTurret(), _weaponFactory.StarboardTurret()}, EOrientation.SOUTH, 'g');
        }

        public Plane Hellion(Point p, int speed) {
            return new Plane(p, 2, speed, 3, 2, 8, 7, 2, 5, 26, new []{_weaponFactory.TwinMultilasers()}, EOrientation.NORTH, 'h');
        }

        public Plane Vulture(Point p, int speed) {
            return new Plane(p, 2, speed, 2, 3, 8, 5, 3, 4, 23, new []{_weaponFactory.QuadBigShootas()}, EOrientation.SOUTH, 'v');
        }
    }
}