using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    List<CardData> deckList;
    [SerializeField]
    List<CardData> handList = new List<CardData>(4);
    [SerializeField]
    List<CardData> internalDeckList;
    [SerializeField]
    List<CardData> discardList;
    [SerializeField]
    int maxHandSize = 3;

    private void Start() {
        internalDeckList = new List<CardData>(deckList);
    }

    private void Update() {
        if (internalDeckList.Count == 0) {
            int numOfNull = 0;
            foreach (CardData cd in handList) { if (cd == null) numOfNull++; }
            if (numOfNull == handList.Count)
                DiscardToDeck();
        }
    }

    public List<CardData> GetHandList() { return handList; }
    public List<CardData> GetInternalDeckList() { return internalDeckList; }
    public List<CardData> GetDiscardList() { return discardList; }
    public GameObject GetObjAtInd(int ind) {
        return handList[ind].towerPrefab;
    }
    public void FillHand(int size = 3) {
        for (int i = 0; i < size; i++)
        {
            handList.Add(GetDeckCard());
        }
    }
    CardData GetDeckCard() {
        if (internalDeckList.Count == 0) {
            DiscardToDeck();
        }
        int index = Random.Range(0, internalDeckList.Count);
        CardData returnObj = internalDeckList[index];
        internalDeckList.RemoveAt(index);
        return returnObj;
    }
    void DiscardToDeck() {
        if (internalDeckList.Count == 0) {
            internalDeckList = new List<CardData>(discardList);
            discardList.Clear();
        }
    }
    public void AddToHand(int position) {
        if (internalDeckList.Count != 0) {
            handList[position] = GetDeckCard();
        }
    }
    public void AddToDeck(CardData newCard) {
        internalDeckList.Add(newCard);
    }
    void AddToDiscard(CardData newCard) {
        discardList.Add(newCard);
    }
}
