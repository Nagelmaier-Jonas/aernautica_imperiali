namespace aernautica_imperiali {
    public interface IPlaneFactory {

        APlane BigBurna(Point point, int speed, EOrientation orientation);

        APlane BlueDevil(Point point, int speed, EOrientation orientation);
        
        APlane Executioner(Point point, int speed, EOrientation orientation);
        
        APlane GrotBommer(Point point, int speed, EOrientation orientation);
        
        APlane Hellion(Point point, int speed, EOrientation orientation);
        
        APlane Vulture(Point point, int speed, EOrientation orientation);
    }
}