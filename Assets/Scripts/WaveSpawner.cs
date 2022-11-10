using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private string waveFilePath;
    // Start is called before the first frame update
    void Start()
    {
        readTextFile(waveFilePath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void readTextFile(string file_path)
    {
        StreamReader inp_stm = new StreamReader(file_path);

        while(!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine( );
            print(inp_ln);
        }

        inp_stm.Close( );  
    }
}
