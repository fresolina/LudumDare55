using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Superseeded by GameManager.cs
// DO NOT USE
[System.Obsolete("Use GameManager.cs instead")]
public class SceneLoader : MonoBehaviour {
    [SerializeField] string _startingScene = "Tutorial_1";

    private OverlayController _overlay;

    private string _loadingScene;

    void Awake() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        _loadingScene = _startingScene;
        if (!SceneManager.GetSceneByName(_loadingScene).IsValid()) {
            SceneManager.LoadScene(_loadingScene, LoadSceneMode.Additive);
        }

        _overlay = GameObject.FindGameObjectWithTag("Canvas").GetComponent<OverlayController>();
        // TODO: set up / hide messages depending on state
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == _loadingScene) {
            SceneManager.SetActiveScene(scene);
        }
    }
}
