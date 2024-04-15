using UnityEngine;

public class GoalController : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponentInParent<Player>()) {
            GameManager.Instance.SetGameState(GameState.LevelComplete);
        }
    }
}
