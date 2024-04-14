using System.Collections.Generic;
using UnityEngine;


public class SummonCarriers : Spell {
    public Sprite icon;

    private GameObject player;

    public override Sprite Icon() {
        return icon;
    }

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            Debug.Log("Player tagged object not found");
    }

    public override void Cast(GameObject target = null) {
        // print("Cast SummonCarriers on " + player);
        if (player != null && player.activeInHierarchy) {
            var controller = player.GetComponentInChildren<Player>();
            if (controller && !controller.IsHidden())
                controller.SummonWalking();
        }
    }
}
