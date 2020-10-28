namespace aernautica_imperiali {
    public class TwinMultilasers : AWeapon{
        public TwinMultilasers(EFireArc[] fireArc, int shortpower, int mediumpower, int longpower, int damage,int ammo, int special) : base(new EFireArc[] {
            EFireArc.FRONT
        }, 4, 6, 2, 5,-1, 0) {
        }
    }
}