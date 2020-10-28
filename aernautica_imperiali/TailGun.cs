namespace aernautica_imperiali {
    public class TailGun : AWeapon{
        public TailGun(EFireArc[] fireArc, int shortpower, int mediumpower, int longpower, int damage,int ammo, int special) : base(new EFireArc[]{EFireArc.REAR}, 1, 0, 0, 6, -1,0) {
        }
    }
}