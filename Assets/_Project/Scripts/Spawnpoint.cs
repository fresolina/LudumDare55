using System.Collections.Generic;
using UnityEditor.Overlays;
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

        Instantiate(_prefab, transform.position, Quaternion.identity);
        _audioSource.Play();
    }
}
