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
        "Great! Now press the start wave button at the bottom!",
        "Keep in mind that in a normal level, the waves will continuously spawn once you hit the button",
        "Well done!",
        "Once a wave ends, you're dealt three new cards from your deck to place",
        "Towers can have one of four different types: Normal, Fire, Water, and Plant",
        "The card on the left will show the corresponding symbol",
        "Enemies can also belong to one of those four types",
        "The type of enemy and tower changes how much damage they do to each other",
        "You can tell what type a tower is with the color of its crystal",
        "Enemies will also slightly change color to show their type",
        "Press the start button to spawn enemies of different types!",
        "Well done!",
        "In addition to shooting towers, there are also shrines",
        "Shrines buff nearby towers or debuff nearby enemies",
        "There are many different kinds of shrines, and you can see what they do in the deck builder",
        "Every enemy you defeat gives you a certain amount of gold",
        "You can then use this gold to buy cards for your deck, and potentially get new ones!",
        "Enemies will get stronger the longer a level lasts, so be sure to get stronger cards to place down",
        "Thats it for the tutorial. Have fun!"
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

    [SerializeField]
    List<CardData> normal;
    [SerializeField]
    List<CardData> types;

    List<CardData> empty = new List<CardData>();
    DeckManager DM;
    WaveSpawner spawner;
    bool dealt=false;

    public GameObject box;
    [SerializeField]
    TMP_Text textbox2;
    public GameObject panel2;

    [SerializeField]
    Image typechart;

    SceneController SM;
    // Start is called before the first frame update
    void Start()
    {
        SM = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
        DM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeckManager>();
        spawner = gameObject.GetComponent<WaveSpawner>();
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
                    DM.OverrideDeck(empty);
                    break;
                case 1:
                    textbox.text=text[1];
                    break;
                case 2:
                    textbox.text=text[2];
                    break;
                case 3:
                    panel.SetActive(false);
                    if(!dealt){
                        DM.OverrideDeck(normal);
                        DM.FillHand(1);
                        dealt=true;
                    }
                    if(GameObject.FindGameObjectsWithTag("Tower").Length!=0){
                        tutInd+=1;
                    }
                    break;
                case 4:
                    dealt = false;
                    textbox.text=text[3];
                    panel.SetActive(true);
                    DisableButtons();
                    break;
                case 5:
                    textbox.text=text[4];
                    break;
                case 6:
                    panel.SetActive(false);
                    EnableButtons();
                    break;
                case 7:
                    if(GameObject.FindGameObjectsWithTag("Enemy").Length==0){
                        tutInd+=1;
                    }
                    break;
                case 8:
                    textbox.text=text[5];
                    panel.SetActive(true);
                    DisableButtons();
                    break;
                case 9:
                    textbox.text=text[6];
                    break;
                case 10:
                    textbox.text=text[7];
                    break;
                case 11:
                    textbox.text=text[8];
                    break;
                case 12:
                    textbox.text=text[9];
                    break;
                case 13:
                    box.SetActive(false);
                    textbox.text = "";
                    panel2.SetActive(true);
                    textbox2.text=text[10];
                    break;
                case 14:
                    panel2.SetActive(false);
                    box.SetActive(true);
                    textbox.text=text[11];
                    break;
                case 15:
                    textbox.text=text[12];
                    break;
                case 16:
                    textbox.text=text[13];
                    break;
                case 17:
                    panel.SetActive(false);
                    EnableButtons();
                    if(!dealt){
                        DM.OverrideDeck(types);
                        DM.FillHand();
                        dealt=true;
                    }
                    break;
                case 18:
                    if(GameObject.FindGameObjectsWithTag("Enemy").Length==0){
                        tutInd+=1;
                    }
                    break;
                case 19:
                    textbox.text=text[14];
                    panel.SetActive(true);
                    DisableButtons();
                    break;
                case 20:
                    textbox.text=text[15];
                    break;
                case 21:
                    textbox.text=text[16];
                    break;
                case 22:
                    textbox.text=text[17];
                    break;
                case 23:
                    textbox.text=text[18];
                    break;
                case 24:
                    textbox.text=text[19];
                    break;
                case 25:
                    textbox.text=text[20];
                    break;
                case 26:
                    textbox.text=text[21];
                    break;
                case 27:
                    SM.begin=false;
                    SM.swapToScene("MainMenu");
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
        dealt=false;
    }

    public void Spawn(){
        if(!pause){
            switch(tutInd){
                case 6:
                    StartCoroutine(spawner.Spawn('g',1,'n',0,1));
                    tutInd+=1;
                    break;
                case 17:
                    pause=true;
                    StartCoroutine(WaitSpawn());
                    
                    break;
                default:
                    break;
            }
        }

    }

    public IEnumerator WaitSpawn(){
        print("hi");
        StartCoroutine(spawner.Spawn('g',1,'n',0,1));
        yield return new WaitForSeconds(1f);
        StartCoroutine(spawner.Spawn('g',1,'w',0,1));
        yield return new WaitForSeconds(1f);
        StartCoroutine(spawner.Spawn('g',1,'f',0,1));
        yield return new WaitForSeconds(1f);
        StartCoroutine(spawner.Spawn('g',1,'p',0,1));
        yield return new WaitForFixedUpdate();
        print("kek");
        tutInd+=1;
        pause=false;
        Spawn();
        yield break;
    }
}
