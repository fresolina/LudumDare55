using UnityEngine;

public class GoalController : MonoBehaviour {
    // public Scene nextLevel;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponentInParent<Player>()) {
            OverlayController.Instance().ShowCompleteMessage(true);
            OverlayController.Instance().ShowSummonPalette(false);
            MusicPlayer.Instance.PlayGameWon();

            // TODO: load next level or win screen

            // SceneLoader.Instance.LoadScene(nextLevel);
        }
    }
}
