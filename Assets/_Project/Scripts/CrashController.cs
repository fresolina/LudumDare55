using System.Collections.Generic;
using UnityEngine;

public class CrashController : MonoBehaviour {
    // Called by animation system when crash animation is finished
    public void AnimationEnd() {
        var overlay = OverlayController.Instance();
        overlay.ShowDeadMessage(true);
        overlay.ShowSummonPalette(false);
        var delay = MusicPlayer.Instance.PlayGameOver().length;
        Invoke("ReloadScene", delay);
    }

    public void ReloadScene() {
        var overlay = OverlayController.Instance();
        overlay.ShowDeadMessage(false);
        // TODO: do something
    }
}
