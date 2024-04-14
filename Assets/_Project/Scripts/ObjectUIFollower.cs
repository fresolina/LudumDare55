using System.Collections.Generic;
using UnityEngine;

public class ObjectUIFollower : MonoBehaviour {
    public Transform target;
    public Vector3 offset;

    private Camera cam;
    private RectTransform rectTransform;

    void Start() {
        cam = Camera.main;
        rectTransform = GetComponent<RectTransform>();
    }

    void Update() {
        if (target != null) {
            Vector3 screenPos = cam.WorldToScreenPoint(target.position);
            rectTransform.position = screenPos + offset;
        } else {
            Destroy(gameObject);
        }
    }
}
