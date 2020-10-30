namespace aernautica_imperiali{
    public class Hellion : APlane{
        public Hellion(Point p, int speed) : base(p, 2, speed, 3, 2, 8, 7, 2, 5, 26, false, new AWeapon[]{new TwinMultilasers}){
        }
    }
}