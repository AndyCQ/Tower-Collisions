using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject UI;
    

    public void Resume(){
        UI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void Pause(){
        UI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
}
