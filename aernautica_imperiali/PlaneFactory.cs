namespace aernautica_imperiali {
    public class PlaneFactory : IWeaponFactory{
        public Weapon BombBay() {
            return new Weapon(new []{EFireArc.REAR}, 8,0,0,2,3,5);
        }

        public Weapon DorsalTurret() {
            return new Weapon(new []{EFireArc.ALLROUND,EFireArc.UP},3,2,0,5,-1,0);
        }

        public Weapon Lascannon() {
            return new Weapon(new [] {EFireArc.FRONT},0,2,1,2,-1,6);
        }

        public Weapon PortTurret() {
            return new Weapon(new [] {EFireArc.LEFT,EFireArc.UP},2,1,0,5,-1,0);
        }

        public Weapon QuadAutocannon() {
            return new Weapon(new [] {EFireArc.FRONT},2,6,0,4,-1,0);
        }

        public Weapon QuadBigShootas() {
            return new Weapon(new [] {EFireArc.FRONT},8,4,0,5,-1,0);
        }

        public Weapon RearTurret() {
            return new Weapon(new [] {EFireArc.REAR},3,2,0,5,-1,0);
        }

        public Weapon StarboardTurret() {
            return new Weapon(new [] {EFireArc.RIGHT,EFireArc.UP},2,1,0,5,-1,0);
        }

        public Weapon TailGun() {
            return new Weapon(new [] {EFireArc.REAR},1,0,0,6,-1,0);
        }

        public Weapon TurretBigShootas() {
            return new Weapon(new [] {EFireArc.REAR,EFireArc.RIGHT,EFireArc.LEFT,EFireArc.UP},3,1,0,5,-1,0);
        }

        public Weapon TwinLascannon() {
            return new Weapon(new [] {EFireArc.FRONT},0,2,1,2,-1,6);
        }

        public Weapon TwinMultilasers() {
            return new Weapon(new [] {EFireArc.FRONT},4,6,2,5,-1,0);
        }
    }
}