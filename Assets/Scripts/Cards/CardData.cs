using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "CardData", menuName = "CustomObjects/CardData", order = 0)]
public class CardData
{
    public string cardName;
    public GameObject towerPrefab;
}
