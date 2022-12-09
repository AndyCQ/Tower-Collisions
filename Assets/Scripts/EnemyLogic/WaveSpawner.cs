using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private string nextScene;

    [SerializeField]
    private bool going = false;
    DeckManager DM;
    private bool endOfWave = false;
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    GameObject[] enemies;
    public GameObject[] paths;
    GameCardManager GCM;
    bool dealt=false;
    public bool tutorial = false;
    SceneController SM;

    public GameObject pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        if(!tutorial){
            ReadTextFile(waveFilePath);
            //PrintDebug(fullLevelData);
            DM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeckManager>();
            
            GCM = GameObject.FindGameObjectWithTag("GameCardManager").GetComponent<GameCardManager>();
            SM = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
        }
        
        
    }


    private void FixedUpdate() {
        if(!tutorial){
            if(index<fullLevelData.Count){
                currString=fullLevelData[index];
            }else{
                currString="x";
            }
            
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies.Length==0&&currString=="w"){
                CheckNext();
            }
            //print(currString);
            if(enemies.Length==0&&index==fullLevelData.Count){
                going=false;
                text.text="End of Level";
            }

            if(!dealt){
                DM.FillHand();
                SM.recentSceneName = SceneManager.GetActiveScene().name;
                dealt=true;
            }
        }
    }
    public void SpawnWave(){
        if(index>=fullLevelData.Count-1 &&enemies.Length==0){
            GCM.currency+=GCM.earned;
            GCM.earned=0;
            SM.swapToScene(nextScene);
        }
        else if(!going){
            
            text.text="Wave "+waveNumber;
            going = true;
            CheckNext();
            // get the next card hand
            
        }
    }


    private void CheckNext(){
        int tier;
        int path;
        switch(currString[0]){
                case 'w':
                    if(enemies.Length==0 && !endOfWave){
                        if(index<fullLevelData.Count-2){
                            pauseButton.SetActive(false);
                            StartCoroutine(WaitWave(6));
                            endOfWave=true;
                        }else{
                            text.text="Next Level";
                            index+=1;
                        }
                    }
                    
                    break;
                case 'd':
                    pauseButton.SetActive(true);
                    StartCoroutine(Wait(float.Parse(currString.Substring(1))));
                    break;
                default:
                    pauseButton.SetActive(true);
                    tier = int.Parse(currString[1].ToString());  
                    path = int.Parse(currString[3].ToString()); 
                    StartCoroutine(Spawn(currString[0],tier,currString[2],path,int.Parse(currString.Substring(4))));
                    break;
            }
    }

    IEnumerator WaitWave(float time){
        
        DM.FillHand();
        while(time>0){
            yield return new WaitForSeconds(1);
            time-=1;
            print(time);
            text.text=time.ToString();
        }
        
        if(time<=0){
            index+=1;
            waveNumber+=1;
            text.text="Wave "+waveNumber;
            endOfWave=false;
        }
        yield return new WaitForFixedUpdate();
        if(!tutorial){
            CheckNext();
        }
        
        yield break;
    }
    public IEnumerator Wait(float time){
        yield return new WaitForSeconds(time);
        
        index+=1;
        yield return new WaitForFixedUpdate();
        if(!tutorial){
            CheckNext();
        }
        yield break;
    }
    public IEnumerator Spawn(char kind, int tier, char type, int path, int enemies){
        int spawned=0;
        Transform spawn = paths[path].GetComponent<Path>().waypoints[0];
        GameObject enemy;
        float time;
        while(spawned<enemies){
            print(PauseMenu.Paused);
            yield return new WaitUntil(()=>PauseMenu.Paused==false);

            switch(kind){
                case 's':
                    enemy = Instantiate(skelPrefab, spawn.position, Quaternion.identity);
                    time = 1;
                    break;
                case 'o':
                    enemy = Instantiate(orcPrefab, spawn.position, Quaternion.identity);
                    time = 2;
                    break;
                default:
                    enemy = Instantiate(gobPrefab, spawn.position, Quaternion.identity);
                    time = 0.5f;
                    break;
            }
            enemy.GetComponent<Health>().SetTier(tier);
            enemy.GetComponent<EnemyMove>().ChangePath(paths[path].GetComponent<Path>());
            switch (type){
                case 'w':
                    enemy.GetComponentInChildren<EnemyShoot>().SetType("Water");
                    enemy.GetComponent<Health>().SetType("Water");
                    enemy.GetComponent<EnemyVisuals>().Setup(TowerController.DamageType.Water);
                    break;
                case 'p':
                    enemy.GetComponentInChildren<EnemyShoot>().SetType("Plant");
                    enemy.GetComponent<Health>().SetType("Plant");
                    enemy.GetComponent<EnemyVisuals>().Setup(TowerController.DamageType.Plant);
                    break;
                case 'f':
                    enemy.GetComponentInChildren<EnemyShoot>().SetType("Fire");
                    enemy.GetComponent<Health>().SetType("Fire");
                    enemy.GetComponent<EnemyVisuals>().Setup(TowerController.DamageType.Fire);
                    break;
                case 'n':
                    enemy.GetComponentInChildren<EnemyShoot>().SetType("Normal");
                    enemy.GetComponent<Health>().SetType("Normal");
                    enemy.GetComponent<EnemyVisuals>().Setup(TowerController.DamageType.Normal);
                    break;
            }
            spawned+=1;
            yield return new WaitForSeconds(time);
        }
        index+=1;
        yield return new WaitForFixedUpdate();
        if(!tutorial){
            CheckNext();
        }
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
