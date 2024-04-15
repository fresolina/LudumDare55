using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawnpoint : MonoBehaviour {
    private OverlayController _overlayController;
    private AudioSource _audioSource;

    public GameObject _prefab;

    void Start() {
        _overlayController = OverlayController.Instance();
        _audioSource = GetComponent<AudioSource>();

        _overlayController.ShowSummonPalette(true);
        _overlayController.ShowTypeIndicator(true);
        _overlayController.ShowCompleteMessage(false);
        _overlayController.ShowDeadMessage(false);

        var pos = transform.position;
        pos.z = Camera.main.transform.position.z;
        Camera.main.transform.position = pos;

        Instantiate(_prefab, transform.position, Quaternion.identity);
        _audioSource.Play();

        // Ugly level-specific setup
        OverlayController.Instance().LimitSpells();
        switch (SceneManager.GetActiveScene().name) {
            case "Tutorial_1":
                OverlayController.Instance().LimitSpells(1);
                OverlayController.Instance().AddMessage("message", "You are trapped and can't move yourself\nSummon your trusty servants for help.\nType their name now!\nThen tell them to carry you left.\nFinally unsummon them when touching the flag.");
                break;
        }
    }
}
