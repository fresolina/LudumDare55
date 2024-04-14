using System.Collections.Generic;
using UnityEngine;


public class SummonCarriers : Spell {
    public Sprite icon;

    public override Sprite Icon() {
        return icon;
    }

    public override void Cast(GameObject target = null) {
        print("Cast SummonCarriers on " + target);
        if (target != null)
            target.BroadcastMessage("SummonCarriers");
    }
}
