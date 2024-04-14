using System.Collections.Generic;
using UnityEngine;

public class CarrierController : MonoBehaviour {
    private GameObject summon;
    private GameObject main;
    private GameObject unsummon;

    private GameObject ball;

    public void Start() {
        summon = transform.Find("Summon").gameObject;
        main = transform.Find("Control").gameObject;
        unsummon = transform.Find("Unsummon").gameObject;
    }

    public void Update() {
        // FIXME debug
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            Unsummon();
        }
    }

    public void SetBall(GameObject ball) {
        this.ball = ball;
    }

    // Called through the animation's event system and the SummonEndController in the Summon object
    public void SummonEnd() {
        summon.SetActive(false);
        main.SetActive(true);
    }

    // Call manually to trigger unsummoning animation
    public void Unsummon() {
        summon.SetActive(false);
        main.SetActive(false);
        unsummon.SetActive(true);
    }

    // Called through the animation's event system and the UnsummonEndController in the Summon object
    public void UnsummonEnd() {
        summon.SetActive(false);
        main.SetActive(false);
        unsummon.SetActive(false);
        Destroy(gameObject);

        if (ball != null) {
            var player = ball.GetComponent<Player>();
            player.SetPosition(transform.position);
            player.SetHidden(false);
        }
    }
}
