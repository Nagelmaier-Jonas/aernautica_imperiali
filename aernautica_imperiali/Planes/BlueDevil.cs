namespace aernautica_imperiali{
    public class BlueDevil : APlane{
        public BlueDevil(Point p, int speed, EOrientation orientation) : base(p, 5, speed, 1, 2, 5, 3, 3, 5, 26, false, new Weapon[] {
            new Lascannon(),
            new DorsalTurret(),
            new RearTurret(),
            new BombBay(), 
        }, EOrientation.NORTH){
        }

        public override string ToString() {
            return "d";
        }
    }
}