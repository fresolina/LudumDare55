using System.Collections.Generic;
using UnityEngine;

public class CrashController : MonoBehaviour {

    public AudioClip deathMusic;

    // Called by animation system when crash animation is finished
    public void AnimationEnd() {
        GameManager.Instance.SetGameState(GameState.GameOver);
        // var overlay = GameObject.FindGameObjectWithTag("Canvas").GetComponent<OverlayController>();


        // overlay.ShowDeadMessage(true);
        // var source = GetComponent<AudioSource>();
        // if (deathMusic != null)
        //     source.PlayOneShot(deathMusic);
    }
}
