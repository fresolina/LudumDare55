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
        _audioSource.Play();
    }

    public void PlayGameInProgress() {
        _audioSource.clip = _gameInProgress;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    public void PlayGameWon() {
        _audioSource.clip = _gameWon;
        _audioSource.loop = false;
        _audioSource.Play();
    }

    public void PlayGameOver() {
        _audioSource.clip = _gameOver;
        _audioSource.loop = false;
        _audioSource.Play();
    }

}
