using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{
    public GameObject notEnough;
    public Button[] buttons;
    public void PullOne(){
        if(MainCardArray.currency>=10){
            int rarity = Random.Range(0,100);
            print(rarity);
            int card=0;
            if(rarity<52){
                //R
                print("R");
                card = Random.Range(0,4);
                MainCardArray.CardArray[card]+=1;
            }else if(rarity<82){
                //SR
                print("SR");
                card = Random.Range(0,4);
                MainCardArray.CardArray[card+4]+=1;
            }else if(rarity<94){
                //SSR
                print("SSR");
                card = Random.Range(0,4);
                MainCardArray.CardArray[card+8]+=1;
            }else{
                print("UR");
                MainCardArray.CardArray[card+12]+=1;
            }
            print(card);
        }else{
            StartCoroutine(NotEnough());
        }
    }

    public void PullEleven(){
        int rarity = Random.Range(0,100);
        print(rarity);
        int card=0;
        if(rarity<82){
            //SR
            print("SR");
            card = Random.Range(0,4);
            print(card);
            MainCardArray.CardArray[card+4]+=1;
        }else if(rarity<94){
            //SSR
            print("SSR");
            card = Random.Range(0,4);
            print(card);
            MainCardArray.CardArray[card+8]+=1;
        }else{
            print("UR");
            MainCardArray.CardArray[card+12]+=1;
        }
        print(card);
        for(int i=0;i<10;i++){
            PullOne();
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
