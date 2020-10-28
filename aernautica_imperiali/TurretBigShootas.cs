namespace aernautica_imperiali {
    public class TurretBigShootas : AWeapon{
        public TurretBigShootas(EFireArc[] fireArc, int shortpower, int mediumpower, int longpower, int damage, int special) : base(new EFireArc[]
            {
                EFireArc.REAR,EFireArc.RIGHT,EFireArc.LEFT,EFireArc.UP
            }, 3, 1, 0, 5, 0) {
        }
    }
}