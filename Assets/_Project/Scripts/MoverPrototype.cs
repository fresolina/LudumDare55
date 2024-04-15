using System.Collections.Generic;
using UnityEngine;


public class MoverPrototype : MonoBehaviour {
    private enum Direction {
        Left,
        Right,
        None,
    }

    public float speed = 1.0f;
    private Vector3 direction = Vector3.zero;

    private Direction collisionDirection = Direction.None;
    private bool stuck = false;

    private Animator _animator;
    private Collider2D _collider;

    public void Start() {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
    }

    public void Update() {
        transform.parent.position += direction * speed * Time.deltaTime;

        if (direction != Vector3.zero) {
            collisionDirection = Direction.None;
        }

        // Force walking if needed to get unstuck
        if (stuck) {
            var stuckDir = StuckestDirection();
            if (stuckDir == Direction.None)
                stuckDir = AbyssDirection();

            switch (stuckDir) {
                case Direction.None:
                    stuck = false;
                    OnTriggerEnter2D(null);
                    break;
                case Direction.Right:
                    direction = Vector3.left;
                    transform.parent.localScale = new Vector3(1, 1, 1);
                    _animator.enabled = true;
                    break;
                case Direction.Left:
                    direction = Vector3.right;
                    transform.parent.localScale = new Vector3(-1, 1, 1);
                    _animator.enabled = true;
                    break;
            }
        } else {
            var abyss = AbyssDirection();
            if (abyss != Direction.None) {
                print("Abyss detected!: " + abyss);
                stuck = true;
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

    private Direction AbyssDirection() {
        // raycast left down and right down to find if we are hovering above an abyss
        var bounds = _collider.bounds;
        var left_corner = new Vector2(bounds.min.x, bounds.min.y + 0.1f);
        var right_corner = new Vector2(bounds.max.x, bounds.min.y + 0.1f);
        var left = Physics2D.Raycast(left_corner, Vector2.down, 1.0f);
        var right = Physics2D.Raycast(right_corner, Vector2.down, 1.0f);

        if (left.collider != null)
            Debug.DrawLine(left_corner, left.point, Color.red);
        if (right.collider != null)
            Debug.DrawLine(right_corner, right.point, Color.red);

        if (left.collider == null) {
            return Direction.Left;
        } else if (right.collider == null) {
            return Direction.Right;
        } else if (left.distance < 0.20f && right.distance < 0.20f) {
            return Direction.None;
        } else if (left.distance > right.distance) {
            print("Abyss left: " + left.distance + " right: " + right.distance);
            return Direction.Left;
        } else {
            return Direction.Right;
        }
    }

    private Direction StuckestDirection() {
        // raycast left and right and find the direction with the closest distance
        var origin = transform.parent.position;
        var left = Physics2D.Raycast(origin, Vector2.left, 2.0f);
        var right = Physics2D.Raycast(origin, Vector2.right, 2.0f);

        if (left.collider != null)
            Debug.DrawLine(origin, left.point, Color.red);
        if (right.collider != null)
            Debug.DrawLine(origin, right.point, Color.red);

        if (left.collider == null && right.collider == null) {
            return Direction.None;
        } else if (right.collider != null && left.collider != null) {
            if (right.distance < left.distance) {
                return Direction.Right;
            } else {
                return Direction.Left;
            }
        } else if (left.collider == null) {
            return Direction.Right;
        } else {
            return Direction.Left;
        }
    }

    public void CastTurnLeft() {
        if (collisionDirection != Direction.Left && !stuck) {
            direction = Vector3.left;
            _animator.enabled = true;
        }
        transform.parent.localScale = new Vector3(1, 1, 1);
        //_renderer.flipX = false;
    }

    public void CastTurnRight() {
        if (collisionDirection != Direction.Right && !stuck) {
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
            collisionDirection = direction.x < 0f ? Direction.Left : Direction.Right;
        } else {
            collisionDirection = Direction.None;
        }

        direction = Vector3.zero;
        _animator.enabled = false;
    }
}
