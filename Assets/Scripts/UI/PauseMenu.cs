using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject UI;
    //public GameObject wave;
    

    public void Resume(){
        UI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        //wave.enabled = true;
    }

    public void Pause(){
        UI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        //wave.enabled = false;
    }
}
