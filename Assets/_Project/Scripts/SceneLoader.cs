using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    [SerializeField] string _startingScene = "Level_1";

    private OverlayController _overlay;

    void Awake() {
        /*
        // Load the spell pallette canvas when loading a scene
        if (!SceneManager.GetSceneByName("GameOverlayCanvas").IsValid()) {
            SceneManager.LoadScene("GameOverlayCanvas", LoadSceneMode.Additive);
        }
        */

        if (!SceneManager.GetSceneByName(_startingScene).IsValid()) {
            SceneManager.LoadScene(_startingScene, LoadSceneMode.Additive);
        }

        _overlay = GameObject.FindGameObjectWithTag("Canvas").GetComponent<OverlayController>();
        // TODO: set up / hide messages depending on state
    }
}
