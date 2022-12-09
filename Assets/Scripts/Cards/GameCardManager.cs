using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameCardData {
    [SerializeField]
    public CardData CD;
    [SerializeField]
    public int count;
}

public class GameCardManager : MonoBehaviour
{
    [SerializeField]
    public List<GameCardData> MainCardList;
    public List<CardData> CurrCardList;
    public int currency=100;
    public int earned=0;
    public int maxDeckSize = 10;

}
