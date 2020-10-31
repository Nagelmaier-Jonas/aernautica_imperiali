namespace aernautica_imperiali {
    public class TwinMultilasers : Weapon{
        public TwinMultilasers() : base(new EFireArc[] {
            EFireArc.FRONT
        }, 4, 6, 2, 5,-1, 0) {
        }
    }
}