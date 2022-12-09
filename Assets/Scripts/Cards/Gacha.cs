using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{
    public GameObject notEnough;
    public GameObject pullOnePanel;
    public Image pullOneImg;
    public GameObject pullElevenPanel;
    public Image[] pullElevenImg;
    public Button[] buttons;
    GameCardManager GCM;
    SaveGame save;
    private void Start() {
        GCM = GameObject.FindGameObjectWithTag("GameCardManager").GetComponent<GameCardManager>();
        save = GameObject.FindGameObjectWithTag("Save").GetComponent<SaveGame>();
    }
    public void PullOne(){
        List<int> pulled = new List<int>();
        if(GCM.currency>=10){
            // int rarity = Random.Range(0,100);
            // print(rarity);
            // int card=0;
            // if(rarity<52){
            //     //R
            //     print("R");
            //     card = Random.Range(0,4);
            //     GCM.MainCardList[card].count += 1;
            // }else if(rarity<82){
            //     //SR
            //     print("SR");
            //     card = Random.Range(0,4);
            //     GCM.MainCardList[card+4].count += 1;
            // }else if(rarity<94){
            //     //SSR
            //     print("SSR");
            //     card = Random.Range(0,4);
            //     GCM.MainCardList[card+8].count += 1;
            // }else{
            //     print("UR");
            //     GCM.MainCardList[card+12].count += 1;
            // }
            int card = Random.Range(0,9);
            GCM.MainCardList[card].count += 1;
            GCM.currency-=10;
            pulled.Add(card);
            Display(pulled);
        }else{
            StartCoroutine(NotEnough());
        }
    }

    public void PullEleven(){
        List<int> pulled = new List<int>();
        if(GCM.currency>=100){
            
            // int rarity = Random.Range(0,100);
            // print(rarity);
            // int card=0;
            // if(rarity<82){
            //     //SR
            //     print("SR");
            //     card = Random.Range(0,4);
            //     print(card);
            //     GCM.MainCardList[card+4].count += 1;
            // }else if(rarity<94){
            //     //SSR
            //     print("SSR");
            //     card = Random.Range(0,4);
            //     print(card);
            //     GCM.MainCardList[card+8].count += 1;
            // }else{
            //     print("UR");
            //     GCM.MainCardList[card+12].count += 1;
            // }
            // print(card);
            
            for(int i=0;i<11;i++){
                int card = Random.Range(0,9);
                GCM.MainCardList[card].count += 1;
                pulled.Add(card);
            }
            GCM.currency-=100;
            Display(pulled);
        }else{
            StartCoroutine(NotEnough());
        }
       
    }

    public IEnumerator NotEnough(){
        notEnough.SetActive(true);
        for(int i=0;i<buttons.Length;i++){
            buttons[i].enabled=false;
        }
        yield return new WaitForSeconds(3);
        for(int i=0;i<buttons.Length;i++){
            buttons[i].enabled=true;
        }
        notEnough.SetActive(false);
        yield break;
    }

    public void Display(List<int> pulled){
        save.Save();
        if(pulled.Count==1){
            pullOnePanel.SetActive(true);
            for(int i=0;i<buttons.Length;i++){
                buttons[i].enabled=false;
            }
            pullOneImg.sprite = GCM.MainCardList[pulled[0]].CD.cardArt;
        }else{
            pullElevenPanel.SetActive(true);
            for(int i=0;i<buttons.Length;i++){
                buttons[i].enabled=false;
            }
            for(int i=0;i<pullElevenImg.Length;i++){
                pullElevenImg[i].sprite = GCM.MainCardList[pulled[i]].CD.cardArt;
            }
        }
    }

    public void Return(){
        pullOnePanel.SetActive(false);
        pullElevenPanel.SetActive(false);
        for(int i=0;i<buttons.Length;i++){
            buttons[i].enabled=true;
        }
    }
}
