using System.Collections.Generic;
using UnityEngine;


public class TurnCannonDown : Spell {
    public Sprite icon;

    public override Sprite Icon() {
        return icon;
    }

    public override void Cast(GameObject target = null) {
        //print("Cast TurnCannonUp on " + target);

        target.BroadcastMessage("CastTurnDown");
    }
}
