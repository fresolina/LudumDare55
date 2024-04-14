using System.Collections.Generic;
using UnityEngine;

public class MoverPrototype : MonoBehaviour {

    public float speed = 1.0f;
    private Vector3 direction = Vector3.zero;

    private Vector3 collisionDirection = Vector3.zero;
    private bool stuck = false;

    private Animator _animator;


    public void Start() {
        _animator = GetComponent<Animator>();
    }

    public void Update() {
        transform.parent.position += direction * speed * Time.deltaTime;

        if (direction != Vector3.zero) {
            collisionDirection = Vector3.zero;
        }

        // Force walking if needed to get unstuck
        if (stuck) {
            var hit = StuckestDirection();
            if (hit.collider == null) {
                stuck = false;
                OnTriggerEnter2D(null);
            } else {
                if (hit.point.x >= transform.parent.position.x) {
                    direction = Vector3.left;
                    transform.parent.localScale = new Vector3(1, 1, 1);
                    _animator.enabled = true;
                } else {
                    direction = Vector3.right;
                    transform.parent.localScale = new Vector3(-1, 1, 1);
                    _animator.enabled = true;
                }
            }
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

    public RaycastHit2D StuckestDirection() {
        // raycast left and right and find the direction with the closest distance
        var origin = transform.parent.position;
        var left = Physics2D.Raycast(origin, Vector2.left, 2.0f);
        var right = Physics2D.Raycast(origin, Vector2.right, 2.0f);

        if (left.collider != null) {
            if (right.collider != null) {
                if (left.distance < right.distance) {
                    return left;
                } else {
                    return right;
                }
            } else {
                return left;
            }
        } else {
            return right;
        }
    }

    public void CastTurnLeft() {
        if (collisionDirection != Vector3.left && !stuck) {
            direction = Vector3.left;
            _animator.enabled = true;
        }
        transform.parent.localScale = new Vector3(1, 1, 1);
        //_renderer.flipX = false;
    }

    public void CastTurnRight() {
        if (collisionDirection != Vector3.right && !stuck) {
            direction = Vector3.right;
            _animator.enabled = true;
        }
        // _renderer.flipX = true;
        transform.parent.localScale = new Vector3(-1, 1, 1);
    }

    public void CastUnsummon() {
        GetComponentInParent<CarrierController>().Unsummon();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        // print("Collision triggered!");
        stuck = direction == Vector3.zero;
        if (other != null) {
            collisionDirection = direction;
        } else {
            collisionDirection = Vector3.zero;
        }

        direction = Vector3.zero;
        _animator.enabled = false;
    }
}
