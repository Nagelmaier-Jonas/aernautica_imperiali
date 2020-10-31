namespace aernautica_imperiali {
    public interface IPlaneFactory {

        Plane BigBurna(Point p, int speed);

        Plane BlueDevil(Point p, int speed);
        
        Plane Executioner(Point p, int speed);
        
        Plane GrotBommer(Point p, int speed);
        
        Plane Hellion(Point p, int speed);
        
        Plane Vulture(Point p, int speed);
    }
}