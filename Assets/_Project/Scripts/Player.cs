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

    public void SummonWalking() {
        Vector2 position = _spriteRenderer.transform.position;
        GameObject anim = Instantiate(_summonWalkingPrefab, position, Quaternion.identity);
        SetHidden(true);
    }

}
