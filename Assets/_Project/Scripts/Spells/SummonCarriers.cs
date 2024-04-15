using System.Collections.Generic;
using UnityEngine;


public class SummonCarriers : Spell {
    public Sprite icon;

    public override Sprite Icon() {
        return icon;
    }

    void Start() {
    }

    public override void Cast(GameObject target = null) {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            Debug.Log("Player tagged object not found");

        // print("Cast SummonCarriers on " + player);
        if (player != null && player.activeInHierarchy) {
            var controller = player.GetComponentInChildren<Player>();
            if (controller && !controller.IsHidden())
                controller.SummonWalking();
        }
    }
}
