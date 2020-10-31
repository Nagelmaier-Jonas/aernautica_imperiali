namespace aernautica_imperiali{
    public class Vulture : APlane{
        public Vulture(Point p, int speed, EOrientation orientation) : base(p, 2, speed, 2, 3, 8, 5, 3, 4, 23, false, new Weapon[]{}, EOrientation.SOUTH){
        }

        public override string ToString() {
            return "v";
        }
    }
}