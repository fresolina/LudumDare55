using System.Collections.Generic;
using UnityEngine;

public class MoverPrototype : MonoBehaviour {

    public float speed = 1.0f;
    private Vector3 direction = Vector3.zero;

    private Vector3 collisionDirection = Vector3.zero;
    private bool stuck = false;

    public void Update() {
        transform.parent.position += direction * speed * Time.deltaTime;

        if (direction != Vector3.zero) {
            collisionDirection = Vector3.zero;
            stuck = false;
        }

        // TODO: disable dev cheatcodes (?)
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            CastTurnLeft();
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            CastTurnRight();
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            CastUnsummon();
        }
    }

    public void CastTurnLeft() {
        if (collisionDirection != Vector3.left && !stuck)
            direction = Vector3.left;
    }

    public void CastTurnRight() {
        if (collisionDirection != Vector3.right && !stuck)
            direction = Vector3.right;
    }

    public void CastUnsummon() {
        GetComponentInParent<CarrierController>().Unsummon();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        // print("Collision triggered!");
        if (direction == Vector3.zero)
            stuck = true;
        collisionDirection = direction;
        direction = Vector3.zero;
    }
}
