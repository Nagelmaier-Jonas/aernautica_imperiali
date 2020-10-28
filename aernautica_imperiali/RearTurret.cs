using System;

namespace aernautica_imperiali {
    public class RearTurret : AWeapon{
        public RearTurret(EFireArc[] fireArc, int shortpower, int mediumpower, int longpower, int damage, int special) : base(new EFireArc[]{EFireArc.REAR}, 3, 2, 0, 5, 0) {
        }
        
    }
}