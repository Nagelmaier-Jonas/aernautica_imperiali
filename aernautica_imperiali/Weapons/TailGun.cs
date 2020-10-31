namespace aernautica_imperiali {
    public class TailGun : Weapon{
        public TailGun() : base(new EFireArc[]{EFireArc.REAR}, 1, 0, 0, 6, -1,0) {
        }
    }
}