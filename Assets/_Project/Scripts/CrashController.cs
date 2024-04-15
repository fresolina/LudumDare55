using System.Collections.Generic;
using UnityEngine;

public class CrashController : MonoBehaviour {
    // Called by animation system when crash animation is finished
    public void AnimationEnd() {
        GameManager.Instance.SetGameState(GameState.GameOver);
    }
}
