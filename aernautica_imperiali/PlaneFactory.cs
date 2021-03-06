﻿namespace aernautica_imperiali{
    public class PlaneFactory{
        public static Plane BigBurna(Point p, int speed){
            return new Plane(p, 3, speed, 2, 3, 7, 4, 4, 4, 22,
                new[]{WeaponFactory.QuadBigShootas(), WeaponFactory.TurretBigShootas(), WeaponFactory.TailGun()},
                EOrientation.SOUTH, 'b', 'o');
        }

        public static Plane BlueDevil(Point p, int speed){
            return new Plane(p, 5, speed, 1, 2, 5, 3, 3, 5, 26,
                new[]{
                    WeaponFactory.Lascannon(), WeaponFactory.DorsalTurret(), WeaponFactory.RearTurret(),
                    WeaponFactory.Lascannon(), WeaponFactory.BombBay()
                }, EOrientation.NORTH, 'd', 'i');
        }

        public static Plane Executioner(Point p, int speed){
            return new Plane(p, 3, speed, 2, 2, 7, 6, 5, 5, 23, //für Program auf 25 gesetzt damit die Orks gewinnen können
                new[]{WeaponFactory.QuadAutocannon(), WeaponFactory.TwinLascannon()}, EOrientation.NORTH, 'e', 'i');
        }

        public static Plane GrotBommer(Point p, int speed){
            return new Plane(p, 6, speed, 1, 2, 4, 3, 3, 4, 28,
                new[]{WeaponFactory.QuadBigShootas(), WeaponFactory.PortTurret(), WeaponFactory.StarboardTurret()},
                EOrientation.SOUTH, 'g', 'o');
        }

        public static Plane Hellion(Point p, int speed){
            return new Plane(p, 2, speed, 3, 2, 8, 7, 2, 5, 26, new[]{WeaponFactory.TwinMultilasers()},
                EOrientation.NORTH, 'h', 'i');
        }

        public static Plane Vulture(Point p, int speed){
            return new Plane(p, 2, speed, 2, 3, 8, 5, 3, 4, 23, new[]{WeaponFactory.QuadBigShootas()},
                EOrientation.SOUTH, 'v', 'o');
        }

        public static Plane Dummy() {
            return new Plane(new Point(-1,-1,-1), 0,0,0,0,0,0,0,0,0,new Weapon[]{new Weapon(new EFireArc[] {EFireArc.ALLROUND}, 0,0,0,0,0,0)}, EOrientation.NORTH,'-','-');
        }
    }
}