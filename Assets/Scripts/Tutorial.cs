using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    List<string> text = new List<string>(){
        "Welcome to Tower Collision! A tower defense combined with the strategy of card games!",
        "Every round, you get dealt three cards, which will show up on the left side of the screen",
        "To place a tower, select a card on the left, and then tap somewhere on the map to place it!",
        "Great! Now press the start wave button at the bottom!"
    };
    [SerializeField]
    GameObject panel;
    [SerializeField]
    public TMP_Text textbox;
    [SerializeField]
    int tutInd=0;
    [SerializeField]
    bool pause = false;
    [SerializeField]
    GameObject[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!pause){
            switch(tutInd){
                case 0:
                    textbox.text=text[0];
                    panel.SetActive(true);
                    DisableButtons();
                    break;
                case 1:
                    textbox.text=text[1];
                    break;
                case 2:
                    textbox.text=text[2];
                    break;
                case 3:
                    panel.SetActive(false);
                    if(GameObject.FindGameObjectsWithTag("Tower").Length!=0){
                        tutInd+=1;
                    }
                    break;
                case 4:
                    textbox.text=text[3];
                    panel.SetActive(true);
                    EnableButtons();
                    break;
                default:
                    break;
            }
        }
    }

    public void DisableButtons(){
        for(int i=0;i<buttons.Length;i++){
            buttons[i].SetActive(false);
        }
    }

    public void EnableButtons(){
        for(int i=0;i<buttons.Length;i++){
            buttons[i].SetActive(true);
        }
    }
    public void Next(){
        tutInd+=1;
    }
}
