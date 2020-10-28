namespace aernautica_imperiali {
    public class PortTurret : AWeapon{
        public PortTurret(EFireArc[] fireArc, int shortpower, int mediumpower, int longpower, int damage, int special) : base(new EFireArc[]{EFireArc.LEFT,EFireArc.UP}, 2, 1, 0, 5, 0){
        }
    }
}