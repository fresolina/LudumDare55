using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {
    // public Scene nextLevel;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponentInParent<Player>()) {
            // TODO: play success sound
            // TODO: show success text
            // TODO: load next level or win screen
            print("You win!");
            // SceneLoader.Instance.LoadScene(nextLevel);
        }
    }
}
