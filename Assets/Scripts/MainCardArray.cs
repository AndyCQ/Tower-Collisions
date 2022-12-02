using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MainCardArray
{
    /*
    Big array of cards. Each index is the number of that card in the player's inventory
    [index] : [card name]
    0 : 
    1 : 
    2 : 
    3 : 
    4 : 
    5 : 
    6 : 
    7 : 
    8 : 
    9 : 
    10 : 
    */
    public static List<int> CardArray = new List<int>(11);
    public static List<CardData> DeckArray;
}
