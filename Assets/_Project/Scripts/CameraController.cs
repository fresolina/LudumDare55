using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {
    private Player _target;
    private Transform _map;
    private Camera _cam;
    private Bounds _bounds;
    [SerializeField] float _speed = 2f;

    void Start() {
        _cam = Camera.main;
    }

    void Update() {
        if (_target == null) {
            _target = GameObject.FindWithTag("Player").GetComponentInChildren<Player>();
        }

        if (_map == null) {
            _map = GameObject.FindWithTag("Map").transform;
            _bounds = new Bounds();
            foreach (var map in _map.GetComponentsInChildren<Tilemap>()) {
                var map_bounds = map.localBounds;
                _bounds.Encapsulate(map_bounds.min);
                _bounds.Encapsulate(map_bounds.max);
            }
        }

        if (_target != null) {
            Vector3 targetPosition = _target.GetPosition();
            targetPosition.z = transform.position.z;

            if (_map != null) {
                var viewportCenter = _cam.ViewportToWorldPoint(Vector3.zero);
                var viewportCorner = _cam.ViewportToWorldPoint(Vector3.one / 2.0f);
                var viewportMargin = viewportCorner - viewportCenter;

                if (targetPosition.x > _bounds.max.x - viewportMargin.x) {
                    targetPosition.x = _bounds.max.x - viewportMargin.x;
                } else if (targetPosition.x < _bounds.min.x + viewportMargin.x) {
                    targetPosition.x = _bounds.min.x + viewportMargin.x;
                }
                if (targetPosition.y > _bounds.max.y - viewportMargin.y) {
                    targetPosition.y = _bounds.max.y - viewportMargin.y;
                } else if (targetPosition.y < _bounds.min.y + viewportMargin.y) {
                    targetPosition.y = _bounds.min.y + viewportMargin.y;
                }
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
        }
    }
}
