using System.Collections.Generic;
using UnityEngine;


public class SummonCannon : Spell {
    public Sprite icon;

    public override Sprite Icon() {
        return icon;
    }

    protected virtual bool FlipX() {
        return false;
    }

    public override void Cast(GameObject target = null) {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            Debug.Log("Player tagged object not found");

        //print("Cast SummonCannon on " + player);
        if (player != null && player.activeInHierarchy) {
            var controller = player.GetComponentInChildren<Player>();
            if (controller != null && !controller.IsHidden())
                controller.SummonCannon(FlipX());
        }
    }
}
