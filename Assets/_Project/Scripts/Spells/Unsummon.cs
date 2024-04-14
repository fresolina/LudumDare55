using System.Collections.Generic;
using UnityEngine;


public class Unsummon : Spell {
    public Sprite icon;

    public override Sprite Icon() {
        return icon;
    }

    public override void Cast(GameObject target = null) {
        target.BroadcastMessage("CastUnsummon");
    }
}
