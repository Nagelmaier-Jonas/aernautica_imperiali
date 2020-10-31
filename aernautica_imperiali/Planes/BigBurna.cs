namespace aernautica_imperiali{
    public class BigBurna : Plane{
        public BigBurna(Point p, int speed, EOrientation orientation) : base(p, 3, speed, 2, 3, 7, 4, 4, 4, 22, false, new AWeapon[]{
            new QuadBigShootas(),
            new TurretBigShootas(),
            new TailGun(), 
        }, EOrientation.SOUTH){
        }

        public override string ToString() {
            return "b";
        }
    }
}