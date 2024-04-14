using System.Collections.Generic;
using UnityEngine;

public class MoverPrototype : MonoBehaviour {

    public float speed = 1.0f;
    private Vector3 direction = Vector3.zero;

    public void Update() {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void CastTurnLeft() {
        direction = Vector3.left;
    }

    public void CastTurnRight() {
        direction = Vector3.right;
    }

    public void CastDesummon() {
        direction = Vector3.zero;
    }
}
