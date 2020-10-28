namespace aernautica_imperiali {
    public class DorsalTurret : AWeapon{
        public DorsalTurret(EFireArc[] fireArc, int shortpower, int mediumpower, int longpower, int damage, int special) : base(new EFireArc[]{EFireArc.ALLROUND,EFireArc.UP}, 3, 2, 0, 5, 0){
        }
    }
}