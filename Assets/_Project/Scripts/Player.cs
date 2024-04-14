using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] GameObject _summonWalkingPrefab;

    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;

    void Awake() {
        _rigidbody = GetComponentInChildren<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - (Vector2)transform.position);
            // Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
            Move(direction);
        }

        // Debug inputs
        if (Input.GetKeyDown(KeyCode.Alpha1) && !IsHidden()) {
            SummonWalking();
        }
    }

    public void Move(Vector2 direction) {
        _rigidbody.AddForce(direction, ForceMode2D.Impulse);
    }

    public void SetHidden(bool hidden) {
        if (hidden) {
            _spriteRenderer.enabled = false;
        } else {
            _spriteRenderer.enabled = true;
        }
    }

    public bool IsHidden() {
        return !_spriteRenderer.enabled;
    }

    public void SummonWalking() {
        Vector2 position = _spriteRenderer.transform.position;
        GameObject anim = Instantiate(_summonWalkingPrefab, position, Quaternion.identity);
        anim.GetComponent<CarrierController>().SetBall(gameObject);
        SetHidden(true);
    }

}
