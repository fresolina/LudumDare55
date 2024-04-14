using System.Collections.Generic;
using UnityEngine;


public class FireCannon : Spell {
    public Sprite icon;

    public override Sprite Icon() {
        return icon;
    }

    public override void Cast(GameObject target = null) {
        // print("Cast TurnCannonUp on " + target);
        target.BroadcastMessage("CastShoot");
    }
}
