namespace aernautica_imperiali {
    public class Lascannon : AWeapon{
        public Lascannon(EFireArc[] fireArc, int shortpower, int mediumpower, int longpower, int damage, int special) : base(new EFireArc[]{EFireArc.FRONT}, 0, 2, 1, 2, 6){
        }
    }
}