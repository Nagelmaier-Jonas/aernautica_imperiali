﻿using System;

namespace aernautica_imperiali {
    public class RearTurret : AWeapon{
        public RearTurret() : base(new EFireArc[]{EFireArc.REAR}, 3, 2, 0, 5, -1, 0) {
        }
        
    }
}