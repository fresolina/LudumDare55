using System.Collections.Generic;
using UnityEngine;

public class MoverPrototype : MonoBehaviour {

    public float speed = 1.0f;
    private Vector3 direction = Vector3.zero;

    private Vector3 collisionDirection = Vector3.zero;
    private bool stuck = false;
    // private SpriteRenderer _renderer;
    private Animator _animator;

    public void Start() {
        // _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

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
        if (direction == Vector3.zero) {
            stuck = true;
            CastUnsummon();
        }
        collisionDirection = direction;
        direction = Vector3.zero;
        _animator.enabled = false;
    }
}
