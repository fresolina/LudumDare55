using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class GoalController : MonoBehaviour {
    // public Scene nextLevel;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponentInParent<Player>()) {
            OverlayController.Instance().ShowCompleteMessage(true);
            OverlayController.Instance().ShowSummonPalette(false);

            var delay = MusicPlayer.Instance.PlayGameWon().length;
            Invoke("LoadNextScene", delay);
        }
    }

    void LoadNextScene() {
        OverlayController.Instance().ShowCompleteMessage(false);

        // TODO: load next level or win screen
        // SceneLoader.Instance.LoadScene(nextLevel);
    }
}
