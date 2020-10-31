namespace aernautica_imperiali {
    public class DorsalTurret : Weapon{
        public DorsalTurret() : base(new EFireArc[]{EFireArc.ALLROUND,EFireArc.UP}, 3, 2, 0, 5, -1,0){
        }
    }
}