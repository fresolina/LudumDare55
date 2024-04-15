using System.Collections.Generic;
using UnityEngine;

public class OverlayController : MonoBehaviour {
    private GameObject _summonPalette;
    private GameObject _typeIndicator;
    private GameObject _completeMessage;
    private GameObject _deadMessage;

    private static OverlayController _overlayController;

    void Awake() {
        _overlayController = this;
        _summonPalette = transform.Find("SummonPalette").gameObject;
        _typeIndicator = transform.Find("TypeIndicator").gameObject;
        _completeMessage = transform.Find("Completed").gameObject;
        _deadMessage = transform.Find("Dead").gameObject;
    }

    public static OverlayController Instance() {
        return _overlayController;
    }

    public void ShowSummonPalette(bool show) {
        _summonPalette.SetActive(show);
    }

    public void ShowTypeIndicator(bool show) {
        _typeIndicator.SetActive(show);
    }

    public void ShowCompleteMessage(bool show) {
        _completeMessage.SetActive(show);
    }

    public void ShowDeadMessage(bool show) {
        _deadMessage.SetActive(show);
    }
}
