namespace aernautica_imperiali {
    public class TurretBigShootas : Weapon{
        public TurretBigShootas() : base(new EFireArc[]
            {
                EFireArc.REAR,EFireArc.RIGHT,EFireArc.LEFT,EFireArc.UP
            }, 3, 1, 0, 5,-1, 0) {
        }
    }
}