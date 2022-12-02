using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameCardData {
    [SerializeField]
    CardData CD;
    [SerializeField]
    int count;
}

public class GameCardManager : MonoBehaviour
{
    [SerializeField]
    public List<GameCardData> MainCardList;
}
