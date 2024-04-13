using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string _startingScene = "Level_1";

    void Awake()
    {
        SceneManager.LoadScene(_startingScene, LoadSceneMode.Additive);
    }
}
