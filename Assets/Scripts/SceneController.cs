using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    Scene CurrLevel;

    private void Start() {
        //loads the main menu
        swapToScene("StartMenu");
    }

    public void swapToScene(int buildInd) {
        SceneManager.UnloadSceneAsync(CurrLevel);
        AsyncOperation op = SceneManager.LoadSceneAsync(buildInd, LoadSceneMode.Additive);
        op.completed += handle => {
            CurrLevel = SceneManager.GetSceneByBuildIndex(buildInd);
        };
    }
    public void swapToScene(string sceneName) {
        SceneManager.UnloadSceneAsync(CurrLevel);
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        op.completed += handle => {
            CurrLevel = SceneManager.GetSceneByName(sceneName);
        };
    }
}
