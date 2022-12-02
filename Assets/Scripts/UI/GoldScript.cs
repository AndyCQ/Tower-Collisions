using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldScript : MonoBehaviour
{
    public TMP_Text text;
    public GameCardManager GCM;
    // Start is called before the first frame update
    void Start()
    {
        GCM = GameObject.FindGameObjectWithTag("GameCardManager").GetComponent<GameCardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Gold: "+GCM.currency.ToString();
    }
}
