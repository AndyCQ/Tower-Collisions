using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{
    public GameObject notEnough;
    public Button[] buttons;
    GameCardManager GCM;
    private void Start() {
        GCM = GameObject.FindGameObjectWithTag("GameCardManager").GetComponent<GameCardManager>();
    }
    public void PullOne(){
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
            int card = Random.Range(0,5);
            GCM.MainCardList[card].count += 1;
            GCM.currency-=10;
        }else{
            StartCoroutine(NotEnough());
        }
    }

    public void PullEleven(){
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
            int card = Random.Range(0,5);
            GCM.MainCardList[card].count += 1;
            for(int i=0;i<10;i++){
                PullOne();
            }
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
}
