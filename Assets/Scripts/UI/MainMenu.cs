using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public string SceneToGo;
    public GameObject mainMenu;
    public GameObject gachaMenu;
    
    
    public void SwitchScene(){
        SceneManager.LoadScene(SceneToGo);
    }

    public void gachaOn(){
        mainMenu.SetActive(false);
        gachaMenu.SetActive(true);
    }
    public void gachaOff(){
        mainMenu.SetActive(true);
        gachaMenu.SetActive(false);
    }
    public void QuitGame(){
        print("quit");
        Application.Quit();
    }
}
