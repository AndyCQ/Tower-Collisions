using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GoldText : MonoBehaviour
{
    // Start is called before the first frame update
    GameCardManager GCM;
    public TMP_Text text;
    void Start()
    {
        GCM = GameObject.FindGameObjectWithTag("GameCardManager").GetComponent<GameCardManager>();

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Gold Earned: "+GCM.earned.ToString();
    }
}
