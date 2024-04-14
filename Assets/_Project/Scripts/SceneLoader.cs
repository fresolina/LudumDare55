using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    [SerializeField] string _startingScene = "Level_1";

    void Awake() {
        if (SceneManager.GetSceneByName("GameOverlayCanvas").IsValid()) {
            return;
        }
        // Load the spell pallette canvas when loading a scene
        SceneManager.LoadScene("GameOverlayCanvas", LoadSceneMode.Additive);
        SceneManager.LoadScene(_startingScene, LoadSceneMode.Additive);
    }
}
