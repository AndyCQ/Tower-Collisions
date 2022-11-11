using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private string waveFilePath;

    [SerializeField]
    private List<string> fullLevelData;

    public int waveNumber = 0;

    [SerializeField]
    private int index = 0;
    [SerializeField]
    private bool stop = true;
    [SerializeField]
    private string currString = "";

    public GameObject skelPrefab;

    public GameObject spawn;
    private float countdown;

    // Start is called before the first frame update
    void Start()
    {
        ReadTextFile(waveFilePath);
        PrintDebug(fullLevelData);
    }

    private void Update() {
        countdown-=Time.deltaTime;
    }

    public void SpawnWave(){
        stop = false;
        currString=fullLevelData[index];
        while(!stop){
            switch(currString[0]){
                case 'w':
                    if(int.Parse(currString.Substring(1))!=waveNumber){
                        stop = true;
                        waveNumber+=1;
                    }
                    break;
                case 's':
                    int spawned=0;
                    while(spawned<int.Parse(currString.Substring(1))){
                        if(countdown<=0){
                            countdown=0.5f;
                            Instantiate(skelPrefab, spawn.transform.position, Quaternion.identity);
                            spawned+=1;
                        }
                    }
                    break;
            }
            index+=1;
            currString=fullLevelData[index];
        }
    }


    void ReadTextFile(string file_path)
    {
        StreamReader inp_stm = new StreamReader(file_path);

        while(!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine( );
            fullLevelData.Add(inp_ln);
        }

        inp_stm.Close( );  
    }

    void PrintDebug(List<string> list){
        for(int i=0;i<list.Count;i++){
            print(list[i]);
        }
    }
}
