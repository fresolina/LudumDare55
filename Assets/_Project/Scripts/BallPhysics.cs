using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallPhysics : MonoBehaviour {

    // Should be able to survive vertical cannon shot, but not more
    public float maxCollisionSpeed = 11f;

    private AudioSource _audio;

    public void Start() {
        _audio = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        var speed = collision.relativeVelocity.magnitude;
        if (speed > maxCollisionSpeed) {
            print("Hit " + collision.collider + " hard: " + speed);
            var player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Player>();
            player.Crash();
        } else if (speed > 0.1f) {
            //print("Hit softly. " + collision.relativeVelocity.magnitude);
            // TODO: replace sound effect with Dara's
            _audio.pitch = Random.Range(1.0f, 1.2f);
            _audio.Play();
        }
    }
}
