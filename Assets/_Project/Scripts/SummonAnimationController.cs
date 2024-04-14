using System.Collections.Generic;
using UnityEngine;

public class SummonAnimationController : MonoBehaviour {
    // This should be sent as an event from the last frame of the animation
    public void SummonEnd() {
        transform.parent.BroadcastMessage("SummonEnd");
    }

    public void UnsummonEnd() {
        transform.parent.BroadcastMessage("UnsummonEnd");
    }
}
