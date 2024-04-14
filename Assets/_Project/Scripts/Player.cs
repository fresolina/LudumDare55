using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] GameObject _summonWalkingPrefab;

    CircleCollider2D _collider;
    Rigidbody2D _rigidbody;

    void Awake() {
        _collider = GetComponent<CircleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - (Vector2)transform.position);
            // Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
            Move(direction);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SummonWalking();
        }
    }

    public void Move(Vector2 direction) {
        _rigidbody.AddForce(direction, ForceMode2D.Impulse);
    }

    public void SummonWalking() {
        Vector2 position = transform.position;
        GameObject anim = Instantiate(_summonWalkingPrefab, position, Quaternion.identity);
        gameObject.SetActive(false);
    }

}
