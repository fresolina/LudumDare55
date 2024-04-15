using System.Collections.Generic;
using UnityEngine;


public class TurnRight : Spell {
    public Sprite icon;

    public override Sprite Icon() {
        return icon;
    }

    public override void Cast(GameObject target = null) {
        //print("Cast TurnRight on " + target);
        target.BroadcastMessage("CastTurnRight");
    }
}
