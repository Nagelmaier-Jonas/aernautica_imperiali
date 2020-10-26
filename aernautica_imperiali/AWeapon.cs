using System.Collections.Generic;
using System.ComponentModel;

namespace aernautica_imperiali {
    public abstract class AWeapon {

        protected const int SHORT = 4;
        protected const int MEDIUM = 7;
        protected const int LONG = 10;

        private int shortpower;
        private int mediumpower;
        private int longpower;

        private Dictionary<string, int> firepower;
        private int damage;
        private int special;

        public Dictionary<string, int> Firepower => firepower;

        public int Damage => damage;

        public int Special => special;

        protected AWeapon(int shortpower, int mediumpower, int longpower, int damage, int special) {
            this.shortpower = shortpower;
            this.mediumpower = mediumpower;
            this.longpower = longpower;
            this.damage = damage;
            this.special = special;

            firepower["shortpower"] = shortpower;
            firepower["mediumpower"] = mediumpower;
            firepower["longpower"] = longpower;
        }

        
    }
}