using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    Scene CurrLevel;
    [SerializeField]
    bool noStartMenu = false;
    [SerializeField]
    string testSceneName;
    [SerializeField]
    public string recentSceneName;
    [SerializeField]
    public Scene recentScene;
    SaveGame save;
    public bool begin = true;

    private void Start() {
        save = GameObject.FindGameObjectWithTag("Save").GetComponent<SaveGame>();
        save.Load();
        //loads the main menu
        if (!noStartMenu) {
            swapToScene("StartMenu");
        } else {
            CurrLevel = SceneManager.GetSceneByName(testSceneName);
            SceneManager.SetActiveScene(CurrLevel);
            
        }
    }

    public void swapToScene(int buildInd) {
        save.Save();
        if (CurrLevel.IsValid()) {
            SceneManager.UnloadSceneAsync(CurrLevel);
        }
        AsyncOperation op = SceneManager.LoadSceneAsync(buildInd, LoadSceneMode.Additive);
        op.completed += handle => {
            CurrLevel = SceneManager.GetSceneByBuildIndex(buildInd);
            SceneManager.SetActiveScene(CurrLevel);
            Screen.SetResolution(1920,1080,true);
        };
    }
    public void swapToScene(string sceneName) {
        save.Save();
        if (CurrLevel.IsValid()) {
            SceneManager.UnloadSceneAsync(CurrLevel);
        }
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        op.completed += handle => {
            CurrLevel = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(CurrLevel);
            Screen.SetResolution(1920,1080,true);
        };
    }

    public void RecentScene(){
        swapToScene(recentSceneName);
    }
}
