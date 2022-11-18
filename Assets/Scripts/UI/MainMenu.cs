using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public string SceneToGo;
    
    public void SwitchScene(){
        SceneManager.LoadScene(SceneToGo);
    }

    public void QuitGame(){
        print("quit");
        Application.Quit();
    }
}
