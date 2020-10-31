using System.Collections.Generic;
using System.ComponentModel;

namespace aernautica_imperiali {
    public class Weapon {

        protected const int SHORT = 4;
        protected const int MEDIUM = 7;
        protected const int LONG = 10;

        private int shortpower;
        private int mediumpower;
        private int longpower;

        private int ammo;

        public int Ammo {
            get => ammo;
            set => ammo = value;
        }

        private EFireArc[] fireArc;

        public EFireArc[] FireArc => fireArc;

        private Dictionary<ERange, int> firepower;
        private int damage;
        private int special;

        public Dictionary<ERange, int> Firepower => firepower;

        public int Damage => damage;

        public int Special => special;

        public Weapon(EFireArc[] fireArc, int shortpower, int mediumpower, int longpower, int damage, int ammo,
            int special){
            this.shortpower = shortpower;
            this.mediumpower = mediumpower;
            this.longpower = longpower;
            this.damage = damage;
            this.special = special;
            this.fireArc = fireArc;
            this.ammo = ammo;

            firepower[ERange.SHORT] = shortpower;
            firepower[ERange.MEDIUM] = mediumpower;
            firepower[ERange.LONG] = longpower;
        }
    }
}