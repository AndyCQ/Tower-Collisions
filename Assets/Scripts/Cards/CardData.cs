using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "CardData", menuName = "CustomObjects/CardData", order = 0)]
[Serializable]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite cardArt;
    public GameObject towerPrefab;
    public int mainArrayIndex;
}
