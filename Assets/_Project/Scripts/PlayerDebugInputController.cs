using System.Collections.Generic;
using UnityEngine;

public class PlayerDebugInputController : MonoBehaviour {
    [SerializeField] Player _player;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - (Vector2)transform.position);
            _player.Move(direction);
        }

        // Debug inputs
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (_player.gameObject.activeSelf && !_player.IsHidden()) {
                _player.SummonWalking();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (_player.gameObject.activeSelf && !_player.IsHidden()) {
                _player.SummonCannon();
            }
        }
    }
}
