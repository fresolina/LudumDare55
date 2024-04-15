using System;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] GameObject _summonWalkingPrefab;
    [SerializeField] GameObject _summonCannonPrefab;
    [SerializeField] GameObject _crashPrefab;

    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;

    void Awake() {
        _rigidbody = GetComponentInChildren<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public void Move(Vector2 direction) {
        _rigidbody.AddForce(direction, ForceMode2D.Impulse);
    }

    public void Shoot(Vector2 direction) {
        _rigidbody.AddForce(direction, ForceMode2D.Impulse);
    }

    public void SetHidden(bool hidden) {
        gameObject.SetActive(!hidden);
    }

    public bool IsHidden() {
        return !gameObject.activeSelf;
    }

    // FIXME: This is sooo quick and dirty
    public bool IsGrounded() {
        return Math.Abs(_rigidbody.velocity.y) < 0.00001f;
    }

    public void SummonWalking() {
        if (!IsGrounded())
            return;
        Vector2 position = _spriteRenderer.transform.position;
        GameObject anim = Instantiate(_summonWalkingPrefab, position, Quaternion.identity);
        anim.GetComponent<CarrierController>().SetBall(gameObject);
        SetHidden(true);
    }

    public void SummonCannon(bool facingRight = false) {
        if (!IsGrounded())
            return;
        Vector2 position = _spriteRenderer.transform.position;
        GameObject anim = Instantiate(_summonCannonPrefab, position, Quaternion.identity);
        if (facingRight)
            anim.transform.localScale = new Vector3(-1, 1, 1);
        anim.GetComponent<CannonController>().SetBall(gameObject);
        SetHidden(true);
    }

    public Vector3 GetPosition() {
        return _spriteRenderer.transform.position;
    }

    public void SetPosition(Vector3 position) {
        // TODO: reset rigidbody state (velocity etc)
        _rigidbody.transform.position = position;
        _spriteRenderer.transform.position = position;
    }

    public void Crash() {
        Vector2 position = _spriteRenderer.transform.position;
        Instantiate(_crashPrefab, position, Quaternion.identity);
        SetHidden(true);
    }
}
