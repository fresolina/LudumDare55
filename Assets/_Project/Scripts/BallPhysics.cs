using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallPhysics : MonoBehaviour {

    // Should be able to survive vertical cannon shot, but not more
    public float maxCollisionSpeed = 11f;

    public AudioClip _crashSound;
    public AudioClip _bounceSound;

    private AudioSource _audio;

    public void Start() {
        _audio = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        var speed = collision.relativeVelocity.magnitude;
        if (speed > maxCollisionSpeed) {
            print("Hit " + collision.collider + " hard: " + speed);
            _audio.pitch = 1.0f;
            _audio.volume = 1.0f;
            _audio.PlayOneShot(_crashSound);
            GetComponent<Rigidbody2D>().simulated = false;
        } else if (speed > 0.1f) {
            //print("Hit softly. " + collision.relativeVelocity.magnitude);
            // TODO: replace sound effect with Dara's
            _audio.pitch = Random.Range(1.0f, 1.2f);
            _audio.volume = 0.1f;
            _audio.PlayOneShot(_bounceSound);
        }
    }
}
