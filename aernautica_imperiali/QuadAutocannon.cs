namespace aernautica_imperiali {
    public class QuadAutocannon : AWeapon{
        public QuadAutocannon(EFireArc[] fireArc, int shortpower, int mediumpower, int longpower, int damage, int special) : base(new EFireArc[]{EFireArc.FRONT}, 2, 6, 0, 4, 0){
        }
    }
}