using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/*
w - wave number
s - skeleton
d - delay for x seconds

*/


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
    private string currString = "";

    public GameObject skelPrefab;

    public GameObject spawn;

    [SerializeField]
    private bool going = false;



    // Start is called before the first frame update
    void Start()
    {
        ReadTextFile(waveFilePath);
        PrintDebug(fullLevelData);
    }


    private void FixedUpdate() {
        currString=fullLevelData[index];
    }
    public void SpawnWave(){
        if(!going){
            going = true;
            CheckNext();
        }
    }


    private void CheckNext(){
        switch(currString[0]){
                case 'w':
                    index+=1;
                    if(int.Parse(currString.Substring(1))!=waveNumber){
                        waveNumber+=1;
                        going = false;
                    }
                    break;
                case 's':                    
                    StartCoroutine(SpawnSkeletons(int.Parse(currString.Substring(1)),1f));
                    break;
                case 'd':
                    print("stop");
                    StartCoroutine(Wait(float.Parse(currString.Substring(1))));
                    break;
                default:
                    break;
            }
    }
    IEnumerator Wait(float time){
        yield return new WaitForSeconds(time);
        index+=1;
        yield return new WaitForFixedUpdate();
        CheckNext();
        yield break;
    }
    IEnumerator SpawnSkeletons(int enemies, float time){
        int spawned=0;
        while(spawned<enemies){
            Instantiate(skelPrefab, spawn.transform.position, Quaternion.identity);
            spawned+=1;
            yield return new WaitForSeconds(time);
        }
        index+=1;
        yield return new WaitForFixedUpdate();
        CheckNext();
        yield break;
        
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
