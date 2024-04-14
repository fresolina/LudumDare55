using UnityEngine;

public class ObjectFollower : MonoBehaviour {
    [SerializeField] Transform _target;

    void Update() {
        transform.position = _target.position;
    }
}
