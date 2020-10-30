namespace aernautica_imperiali {
    public class QuadBigShootas : AWeapon{
        public QuadBigShootas(EFireArc[] fireArc, int shortpower, int mediumpower, int longpower, int damage, int ammo, int special) : base(new EFireArc[]{EFireArc.FRONT}, 8, 4, 0, 5, -1, 0) {
        }
    }
}