using System.Collections.Generic;
using UnityEngine;

public class ObjectUIFollower : MonoBehaviour {
    public Transform target;

    private Camera cam;
    private RectTransform rectTransform;

    void Start() {
        cam = Camera.main;
        rectTransform = GetComponent<RectTransform>();
    }

    void Update() {
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        rectTransform.position = screenPos;
    }
}
