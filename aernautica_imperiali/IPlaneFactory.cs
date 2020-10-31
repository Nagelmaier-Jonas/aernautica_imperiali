namespace aernautica_imperiali {
    public interface IPlaneFactory {

        APlane BigBurna(Point point, int speed);

        APlane BlueDevil(Point point, int speed);
        
        APlane Executioner(Point point, int speed);
        
        APlane GrotBommer(Point point, int speed);
        
        APlane Hellion(Point point, int speed);
        
        APlane Vulture(Point point, int speed);
    }
}