namespace aernautica_imperiali{
    public class Executioner : APlane{
        public Executioner(Point p, int speed, EOrientation orientation) : base(p, 3, speed, 2, 2, 7, 6, 3, 5, 23, false, new AWeapon[] {
            new QuadAutocannon(),
            new TwinLasercannon(), 
        }, EOrientation.NORTH){
        }

        public override string ToString() {
            return "e";
        }
    }
}