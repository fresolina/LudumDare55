using System.Collections.Generic;
using UnityEngine;

public class MoveCannonController : MonoBehaviour {
    [SerializeField] Sprite[] _sprites;
    CannonController _cannon;
    SpriteRenderer _spriteRenderer;
    int _currentSpriteIndex = 0;
    Vector2[] _shootDirection = {
        Vector2.left,
        new Vector2(-Mathf.Cos(22.5f * Mathf.Deg2Rad), Mathf.Sin(22.5f * Mathf.Deg2Rad)),
        new Vector2(-Mathf.Cos(45f * Mathf.Deg2Rad), Mathf.Sin(45f * Mathf.Deg2Rad)),
        new Vector2(-Mathf.Cos(67.5f * Mathf.Deg2Rad), Mathf.Sin(67.5f * Mathf.Deg2Rad)),
        Vector2.up
    };

    void Awake() {
        _cannon = GetComponentInParent<CannonController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _sprites[0];
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            CastTurnUp();
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            CastTurnDown();
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            CastShoot();
        }
    }

    public void CastTurnUp() {
        if (_currentSpriteIndex == _sprites.Length - 1) return;

        _currentSpriteIndex++;
        _spriteRenderer.sprite = _sprites[_currentSpriteIndex];
    }

    public void CastTurnDown() {
        if (_currentSpriteIndex == 0) return;

        _currentSpriteIndex--;
        _spriteRenderer.sprite = _sprites[_currentSpriteIndex];
    }

    public void CastShoot() {
        _cannon.Shoot(_shootDirection[_currentSpriteIndex] * 10f);
    }

    // FIXME?
    public void CastUnsummon() {
        CastShoot();
    }
}
