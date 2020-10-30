namespace aernautica_imperiali {
    public class StarboardTurret : AWeapon{
        public StarboardTurret() : base(new EFireArc[]{EFireArc.RIGHT, EFireArc.UP}, 2, 1, 0, 5,-1, 0) {
        }
    }
}