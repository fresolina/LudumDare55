using System.Collections.Generic;
using UnityEngine;


public class SummonCannon : Spell {
    public Sprite icon;

    protected GameObject player;

    public override Sprite Icon() {
        return icon;
    }

    protected virtual bool FlipX() {
        return false;
    }

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            Debug.Log("Player tagged object not found");
    }

    public override void Cast(GameObject target = null) {
        //print("Cast SummonCannon on " + player);
        if (player != null && player.activeInHierarchy) {
            var controller = player.GetComponentInChildren<Player>();
            if (controller != null && !controller.IsHidden())
                controller.SummonCannon(FlipX());
        }
    }
}
