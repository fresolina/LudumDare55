using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour {
    [SerializeField] AudioClip[] audioClips;
    AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.enabled = true;
        PlayRandomClip();
    }

    void Update() {
        if (!audioSource.isPlaying) {
            PlayRandomClip();
        }
    }

    void PlayRandomClip() {
        if (audioClips.Length == 0) return;
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }
}
