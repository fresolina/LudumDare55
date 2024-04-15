using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PortalLight : MonoBehaviour {
    [SerializeField] float _radius = 3.0f;
    Light2D _light;
    public float _factor = 5.0f;

    void Awake() {
        _light = GetComponent<Light2D>();
        _light.lightType = Light2D.LightType.Point;
        _light.pointLightOuterRadius = 0;
    }

    void Update() {
        _light.pointLightOuterRadius += _factor * Time.deltaTime;
        if (_light.pointLightOuterRadius >= _radius) {
            _light.pointLightOuterRadius = _radius;
            _factor *= -1;
        }
        if (_light.pointLightOuterRadius <= 0.0f) {
            enabled = false;
        }
    }
}
