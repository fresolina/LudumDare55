using System.Collections.Generic;
using UnityEngine;

public class PlayerDebugInputController : MonoBehaviour {
    [SerializeField] Player _player;

    void Update() {
        // Debug inputs
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (_player.gameObject.activeSelf && !_player.IsHidden()) {
                _player.SummonWalking();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            if (_player.gameObject.activeSelf && !_player.IsHidden()) {
                _player.SummonCannon(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            if (_player.gameObject.activeSelf && !_player.IsHidden()) {
                _player.SummonCannon(true);
            }
        }
    }
}
