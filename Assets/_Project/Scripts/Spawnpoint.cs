using System.Collections.Generic;
using UnityEngine;

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
    }
}
