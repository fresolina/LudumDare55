using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    public static MusicPlayer Instance { get; private set; }
    [SerializeField] AudioClip _title;
    [SerializeField] AudioClip _gameInProgress;
    [SerializeField] AudioClip _gameWon;
    [SerializeField] AudioClip _gameOver;

    AudioSource _audioSource;

    void Awake() {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayTitle() {
        _audioSource.clip = _title;
        _audioSource.loop = true;
        _audioSource.volume = 0.8f;
        _audioSource.Play();
    }

    public void PlayGameInProgress() {
        _audioSource.clip = _gameInProgress;
        _audioSource.loop = true;
        _audioSource.volume = 0.1f;
        _audioSource.Play();
    }

    // Returns the clip so that the caller can use it for e.g.
    // clip.length to wait for the clip to finish playing
    public AudioClip PlayGameWon() {
        _audioSource.clip = _gameWon;
        _audioSource.loop = false;
        _audioSource.volume = 0.2f;
        _audioSource.Play();
        return _gameWon;
    }


    public AudioClip PlayGameOver() {
        _audioSource.clip = _gameOver;
        _audioSource.loop = false;
        _audioSource.volume = 0.1f;
        _audioSource.Play();
        return _gameOver;
    }

}
