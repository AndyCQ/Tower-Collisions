using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    public void PullOne(){
        int rarity = Random.Range(0,100);
        print(rarity);
        int card=0;
        if(rarity<52){
            //R
            print("R");
            card = Random.Range(0,3);
        }else if(rarity<82){
            //SR
            print("SR");
            card = Random.Range(0,3);
        }else if(rarity<94){
            //SSR
            print("SSR");
            card = Random.Range(0,3);
        }else{
            print("UR");
        }
        print(card);
    }

    public void PullEleven(){
        int rarity = Random.Range(0,100);
        print(rarity);
        int card=0;
        if(rarity<82){
            //SR
            print("SR");
            card = Random.Range(0,3);
        }else if(rarity<94){
            //SSR
            print("SSR");
            card = Random.Range(0,3);
        }else{
            print("UR");
        }
        print(card);
        for(int i=0;i<10;i++){
            PullOne();
        }
    }
}
