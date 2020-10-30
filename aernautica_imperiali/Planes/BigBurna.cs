namespace aernautica_imperiali{
    public class BigBurna : APlane{
        public BigBurna(Point p, int speed) : base(p, 3, speed, 2, 3, 7, 4, 4, 4, 22, false, new AWeapon[] {
            new QuadBigShootas(),
            new TurretBigShootas(),
            new TailGun(), 
        }){
        }

        public override string ToString() {
            return "b";
        }
    }
}