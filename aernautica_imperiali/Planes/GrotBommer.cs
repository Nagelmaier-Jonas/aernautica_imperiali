namespace aernautica_imperiali{
    public class GrotBommer : APlane{
        public GrotBommer(Point p, int speed, EOrientation orientation) : base(p, 6, speed, 1, 2, 4, 3, 5, 4, 28, false, new AWeapon[]{new QuadBigShootas(), new PortTurret(), new StarboardTurret()}, EOrientation.SOUTH){
        }

        public override string ToString() {
            return "g";
        }
    }
}