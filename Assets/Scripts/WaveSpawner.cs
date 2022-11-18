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

    public GameObject spawn;

    [SerializeField]
    private bool going = false;
    DeckManager DM;

    [SerializeField]
    private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        ReadTextFile(waveFilePath);
        PrintDebug(fullLevelData);
        DM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeckManager>();
    }


    private void FixedUpdate() {
        if(index<fullLevelData.Count){
            currString=fullLevelData[index];
        }else{
            currString="x";
        }
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length==0&&currString=="w"){
            going=false;
            text.text="Start Wave "+waveNumber;
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
        switch(currString[0]){
                case 'w':
                    index+=1;
                    waveNumber+=1;
                    break;
                case 's':
                    int tier = int.Parse(currString[1].ToString());       
                    StartCoroutine(SpawnSkeletons(tier,currString[2],int.Parse(currString.Substring(3)),1f));
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
    IEnumerator SpawnSkeletons(int tier, char type, int enemies, float time){
        int spawned=0;
        GameObject enemy;
        while(spawned<enemies){
            enemy = Instantiate(skelPrefab, spawn.transform.position, Quaternion.identity);
            print(tier);
            enemy.GetComponent<Health>().SetTier(tier);
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
