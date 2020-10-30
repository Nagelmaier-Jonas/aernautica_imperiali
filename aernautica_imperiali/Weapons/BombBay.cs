namespace aernautica_imperiali {
    public class BombBay : AWeapon{
        public BombBay() : base(new EFireArc[]
            {
                EFireArc.REAR
            }, 8, 0, 0, 2, 3,5) {
        }
    }
}