using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {
    Title,
    GameInProgress,
    GameWon,
    GameOver,
    LevelComplete,
}

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    [SerializeField] string _titleSceneName = "Title";
    [SerializeField] string[] _levelNames;

    MusicPlayer _musicPlayer;
    GameState _gameState;
    string _additiveSceneName;
    int _currentLevel;
    OverlayController _overlay;

    void Awake() {
        Instance = this;
        SceneManager.sceneLoaded += OnSceneLoaded;
        _currentLevel = 0;
    }

    void Start() {
        _overlay = OverlayController.Instance();
        _musicPlayer = MusicPlayer.Instance;
        SetGameState(GameState.Title);
    }

    void Update() {
        switch (_gameState) {
            case GameState.Title:
                if (Input.GetKeyDown(KeyCode.Space)) {
                    SetGameState(GameState.GameInProgress);
                }
                break;
            case GameState.GameInProgress:
                if (Input.GetKeyDown(KeyCode.Escape)) {
                    SetGameState(GameState.Title);
                }
                break;
            case GameState.LevelComplete:
                if (Input.anyKey) {
                    TimeoutMusicOrAnyKey();
                }
                break;
            case GameState.GameWon:
                // TODO: show win screen
                if (Input.anyKey) {
                    TimeoutMusicOrAnyKey();
                }
                break;
            case GameState.GameOver:
                if (Input.anyKey) {
                    TimeoutMusicOrAnyKey();
                }
                break;
        }
    }

    public void SetGameState(GameState state) {
        ResetOverlay();

        float delay;
        switch (state) {
            case GameState.Title:
                _musicPlayer.PlayTitle();
                LoadScene(_titleSceneName);
                break;
            case GameState.GameInProgress:
                _overlay.ShowSummonPalette(true);
                _overlay.ShowTypeIndicator(true);
                LoadScene(_levelNames[_currentLevel]);
                _musicPlayer.PlayGameInProgress();
                break;
            case GameState.GameWon:
                _overlay.ShowCompleteMessage(true);
                delay = _musicPlayer.PlayGameWon().length;
                Invoke("TimeoutMusicOrAnyKey", delay);
                break;
            case GameState.GameOver:
                _overlay.ShowDeadMessage(true);
                delay = _musicPlayer.PlayGameOver().length;
                Invoke("TimeoutMusicOrAnyKey", delay);
                break;
            case GameState.LevelComplete:
                _overlay.ShowCompleteMessage(true);
                delay = _musicPlayer.PlayGameWon().length;
                Invoke("TimeoutMusicOrAnyKey", delay);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
        _gameState = state;
    }

    void TimeoutMusicOrAnyKey() {
        switch (_gameState) {
            case GameState.LevelComplete:
                _currentLevel++;
                if (_currentLevel >= _levelNames.Length) {
                    SetGameState(GameState.GameWon);
                } else {
                    SetGameState(GameState.GameInProgress);
                }
                break;
            case GameState.GameOver:
                SetGameState(GameState.Title);
                break;
            case GameState.GameWon:
                SetGameState(GameState.Title);
                break;
        }
    }

    void ResetOverlay() {
        _overlay.ShowCompleteMessage(false);
        _overlay.ShowDeadMessage(false);
        _overlay.ShowSummonPalette(false);
        _overlay.ShowTypeIndicator(false);
    }

    void LoadScene(string sceneName) {
        // Unload old scene
        if (!string.IsNullOrEmpty(_additiveSceneName)) {
            SceneManager.UnloadSceneAsync(_additiveSceneName);
        }

        // Load new scene
        _additiveSceneName = sceneName;
        if (!SceneManager.GetSceneByName(_additiveSceneName).IsValid()) {
            SceneManager.LoadScene(_additiveSceneName, LoadSceneMode.Additive);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == _additiveSceneName) {
            SceneManager.SetActiveScene(scene);
        }
    }
}
