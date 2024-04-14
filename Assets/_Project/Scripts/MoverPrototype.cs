using System.Collections.Generic;
using UnityEngine;

public class MoverPrototype : MonoBehaviour {

    public float speed = 1.0f;
    private Vector3 direction = Vector3.zero;

    public void Update() {
        transform.parent.position += direction * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            CastTurnLeft();
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            CastTurnRight();
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            CastDesummon();
        }
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
