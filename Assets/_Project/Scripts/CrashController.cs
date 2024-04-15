using System.Collections.Generic;
using UnityEngine;

public class CrashController : MonoBehaviour {
    // Called by animation system when crash animation is finished
    public void AnimationEnd() {
        print("GAME OVER"); // FIXME
        //Destroy(gameObject);
    }
}
