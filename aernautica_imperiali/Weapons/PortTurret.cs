namespace aernautica_imperiali {
    public class PortTurret : Weapon{
        public PortTurret() : base(new EFireArc[]{EFireArc.LEFT,EFireArc.UP}, 2, 1, 0, 5, -1, 0){
        }
    }
}