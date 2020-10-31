namespace aernautica_imperiali {
    public interface IPlaneFactory {

        APlane BigBurna(Point p, int structure, int speed, int throttle, int minSpeed, int maxSpeed, int maneuver, int handling, int maxAltitude, int planeValue, bool spin, AWeapon[] weapons, char type);

        APlane BlueDevil(Point point, int speed);
        
        APlane Executioner(Point point, int speed);
        
        APlane GrotBommer(Point point, int speed);
        
        APlane Hellion(Point point, int speed);
        
        APlane Vulture(Point point, int speed);
    }
}