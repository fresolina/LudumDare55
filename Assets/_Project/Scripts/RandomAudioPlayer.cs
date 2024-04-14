using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour {
    [SerializeField] AudioClip[] audioClips;
    AudioSource audioSource;
    bool _audioQueued;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.enabled = true;
        _audioQueued = false;
    }

    void Update() {
        if (!audioSource.isPlaying && !_audioQueued) {
            // Wait 3-6 seconds before playing another clip
            Invoke("PlayRandomClip", Random.Range(3f, 6f));
            _audioQueued = true;
        }
    }

    void PlayRandomClip() {
        if (audioClips.Length == 0) return;
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }
}
