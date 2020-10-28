namespace aernautica_imperiali {
    public class BombBay : AWeapon{
        public BombBay(EFireArc[] fireArc, int shortpower, int mediumpower, int longpower, int damage, int special) : base(new EFireArc[]
            {
                EFireArc.REAR
            }, 8, 0, 0, 2, 5) {
        }
    }
}