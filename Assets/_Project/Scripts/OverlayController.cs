using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverlayController : MonoBehaviour {
    private GameObject _summonPalette;
    private GameObject _typeIndicator;
    private GameObject _completeMessage;
    private GameObject _deadMessage;

    private static OverlayController _overlayController;

    public GameObject _messagePrefab;

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

    public void LimitSpells(int count = 666) {
        for (int i = 0; i < _summonPalette.transform.childCount; i++) {
            var child = _summonPalette.transform.GetChild(i);
            child.gameObject.SetActive(i < count);
        }
    }

    public GameObject AddMessage(string target, string message) {
        var message_obj = Instantiate(_messagePrefab, transform);
        var textField = message_obj.GetComponent<TMP_Text>();
        var follower = message_obj.GetComponent<ObjectUIFollower>();

        if (textField != null) {
            textField.text = message;
        }
        if (follower != null) {
            follower.target = GameObject.Find(target).transform;
        }
        return message_obj;
    }

    public void ClearMessages() {
        foreach (var child in GameObject.FindGameObjectsWithTag("Message")) {
            Destroy(child.gameObject);
        }
    }
}
