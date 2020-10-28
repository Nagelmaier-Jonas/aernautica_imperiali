namespace aernautica_imperiali {
    public class StarboardTurret : AWeapon{
        public StarboardTurret(EFireArc[] fireArc, int shortpower, int mediumpower, int longpower, int damage,int ammo, int special) : base(new EFireArc[]{EFireArc.RIGHT, EFireArc.UP}, 2, 1, 0, 5,-1, 0) {
        }
    }
}