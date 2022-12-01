using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

/*
w - end of wave
s - skeleton
d - delay for x seconds

*/


public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private string waveFilePath;

    [SerializeField]
    private List<string> fullLevelData;

    public int waveNumber = 1;

    [SerializeField]
    private int index = 0;

    [SerializeField]
    private string currString = "";

    public GameObject skelPrefab;
    public GameObject orcPrefab;
    public GameObject gobPrefab;

    public GameObject spawn;

    [SerializeField]
    private bool going = false;
    DeckManager DM;
    private bool endOfWave = false;
    [SerializeField]
    private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        ReadTextFile(waveFilePath);
        //PrintDebug(fullLevelData);
        DM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeckManager>();
    }


    private void FixedUpdate() {
        if(index<fullLevelData.Count){
            currString=fullLevelData[index];
        }else{
            currString="x";
        }
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //print(currString);
        if(enemies.Length==0&&endOfWave){
            going=false;
            text.text="Start Wave "+waveNumber;
            endOfWave=false;
        }else if(enemies.Length==0&&index==fullLevelData.Count){
            going=false;
            text.text="End of Level";
        }

        
    }
    public void SpawnWave(){
        if(!going){
            going = true;
            text.text="Good Luck!";
            CheckNext();
            // get the next card hand
            DM.FillHand();
        }
    }


    private void CheckNext(){
        int tier;
        int path;
        switch(currString[0]){
                case 'w':
                    index+=1;
                    waveNumber+=1;
                    endOfWave=true;
                    break;
                case 'd':
                    StartCoroutine(Wait(float.Parse(currString.Substring(1))));
                    break;
                default:
                    tier = int.Parse(currString[1].ToString());  
                    path = int.Parse(currString[3].ToString()); 
                    StartCoroutine(Spawn(currString[0],tier,currString[2],path,int.Parse(currString.Substring(4))));
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
    IEnumerator Spawn(char kind, int tier, char type, int path, int enemies){
        int spawned=0;
        GameObject enemy;
        float time;
        while(spawned<enemies){
            switch(kind){
                case 's':
                    enemy = Instantiate(skelPrefab, spawn.transform.position, Quaternion.identity);
                    time = 1;
                    break;
                case 'o':
                    enemy = Instantiate(orcPrefab, spawn.transform.position, Quaternion.identity);
                    time = 2;
                    break;
                default:
                    enemy = Instantiate(gobPrefab, spawn.transform.position, Quaternion.identity);
                    time = 0.5f;
                    break;
            }
            enemy.GetComponent<Health>().SetTier(tier);
            enemy.GetComponent<EnemyMove>().ChangePath(path);
            switch (type){
                case 'w':
                    enemy.GetComponentInChildren<EnemyShoot>().SetType("Water");
                    enemy.GetComponent<Health>().SetType("Water");
                    break;
                case 'p':
                    enemy.GetComponentInChildren<EnemyShoot>().SetType("Plant");
                    enemy.GetComponent<Health>().SetType("Plant");
                    break;
                case 'f':
                    enemy.GetComponentInChildren<EnemyShoot>().SetType("Fire");
                    enemy.GetComponent<Health>().SetType("Fire");
                    break;
                case 'n':
                    enemy.GetComponentInChildren<EnemyShoot>().SetType("Normal");
                    enemy.GetComponent<Health>().SetType("Normal");
                    break;
            }
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
        TextAsset textFile = Resources.Load<TextAsset>(file_path);
        if(textFile == null){
            print("bad");
        }
            

        StreamReader inp_stm = new StreamReader(new MemoryStream(textFile.bytes));

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
