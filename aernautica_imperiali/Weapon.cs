using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace aernautica_imperiali {
    public class Weapon {
        public const int SHORT = 4;
        public const int MEDIUM = 7;
        public const int LONG = 10;

        private int _shortpower;
        private int _mediumpower;
        private int _longpower;

        private int _ammo;

        private EFireArc[] _fireArc;

        private Dictionary<ERange, int> _firePower = new Dictionary<ERange, int>();
        private int _damage;
        private int _special;


        public int Ammo {
            get => _ammo;
            set => _ammo = value;
        }

        public Dictionary<ERange, int> Firepower => _firePower;
        public EFireArc[] FireArc => _fireArc;
        public int Damage => _damage;
        public int Special => _special;

        public Weapon(EFireArc[] fireArc, int shortpower, int mediumpower, int longpower, int damage, int ammo,
            int special) {
            _shortpower = shortpower;
            _mediumpower = mediumpower;
            _longpower = longpower;
            _damage = damage;
            _special = special;
            _fireArc = fireArc;
            _ammo = ammo;

            _firePower[ERange.SHORT] = shortpower;
            _firePower[ERange.MEDIUM] = mediumpower;
            _firePower[ERange.LONG] = longpower;
        }

        public void Fire(Plane plane, Plane target) {
            if (plane.Faction == '-') {
                GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
            }
            else {
                if (GameEngine.GetInstance().TurnToken && plane.Faction == 'i' || !GameEngine.GetInstance().TurnToken && plane.Faction == 'o') {
                    GameEngine.GetInstance().TurnToken = !GameEngine.GetInstance().TurnToken;
                    plane.MoveBehavior.Fire(plane, target, this);
                }
                else {
                    Logger.GetInstance().Info("It's not your turn");
                }
            }
        }

        public bool Equals(Weapon other) {
            return _shortpower == other._shortpower && _mediumpower == other._mediumpower &&
                   _longpower == other._longpower && _ammo == other._ammo && Equals(_fireArc, other._fireArc) &&
                   Equals(_firePower, other._firePower) && _damage == other._damage && _special == other._special;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Weapon) obj);
        }

        public override int GetHashCode() {
            return HashCode.Combine(_shortpower, _mediumpower, _longpower, _ammo, _fireArc, _firePower, _damage,
                _special);
        }
    }
}