using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] GameObject _summonWalkingPrefab;

    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;

    void Awake() {
        _rigidbody = GetComponentInChildren<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public void Move(Vector2 direction) {
        _rigidbody.AddForce(direction, ForceMode2D.Impulse);
    }

    public void SetHidden(bool hidden) {
        gameObject.SetActive(!hidden);
    }

    public bool IsHidden() {
        return !gameObject.activeSelf;
    }

    public void SummonWalking() {
        Vector2 position = _spriteRenderer.transform.position;
        GameObject anim = Instantiate(_summonWalkingPrefab, position, Quaternion.identity);
        anim.GetComponent<CarrierController>().SetBall(gameObject);
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

}
