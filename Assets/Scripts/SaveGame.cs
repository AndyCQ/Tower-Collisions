using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameCardManager GCM;
    public SceneController SM;
    void Start()
    {
        GCM = GameObject.FindGameObjectWithTag("GameCardManager").GetComponent<GameCardManager>();
        SM = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
    }

    public void Save(){
        try{
        GCM = GameObject.FindGameObjectWithTag("GameCardManager").GetComponent<GameCardManager>();
        SM = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath 
                    + "/save.dat"); 
        SaveData data = new SaveData();
        for(int i = 0;i<GCM.MainCardList.Count;i++){
            
            data.MainCardList.Add(GCM.MainCardList[i].count);
        }
        data.currency=GCM.currency;
        for(int i = 0;i<GCM.CurrCardList.Count;i++){
            data.CurrCardList.Add(GCM.CurrCardList[i].mainArrayIndex);
        }

        data.begin = SM.begin;
        bf.Serialize(file, data);
        file.Close();
        }catch{}
    }

    public void Load()
    {
        GCM = GameObject.FindGameObjectWithTag("GameCardManager").GetComponent<GameCardManager>();
        SM = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
        print(Application.persistentDataPath 
                    + "/save.dat");
        if (File.Exists(Application.persistentDataPath 
                    + "/save.dat"))
        {
            try{
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = 
                        File.Open(Application.persistentDataPath 
                        + "/save.dat", FileMode.Open);
                SaveData data = (SaveData)bf.Deserialize(file);
                file.Close();
                for(int i =0;i<data.MainCardList.Count;i++){
                    GCM.MainCardList[i].count=data.MainCardList[i];
                }
                GCM.currency = data.currency;
                GCM.CurrCardList.Clear();
                SM.begin = data.begin;
                for(int i = 0;i<data.CurrCardList.Count;i++){
                    GCM.CurrCardList.Add(GCM.MainCardList[data.CurrCardList[i]].CD);
                }
            }catch{}
            
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class SaveData
{
    public List<int> MainCardList = new List<int>();
    public List<int> CurrCardList = new List<int>();
    public int currency;
    public bool begin;
}
