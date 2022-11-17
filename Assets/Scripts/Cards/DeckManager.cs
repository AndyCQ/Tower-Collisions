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
    CardUIManager UIM;

    private void Start() {
        internalDeckList = new List<CardData>(deckList);
        UIM = GameObject.FindGameObjectWithTag("CardUIManager").GetComponent<CardUIManager>();
    }

    public List<CardData> GetHandList() { return handList; }
    public List<CardData> GetInternalDeckList() { return internalDeckList; }
    public List<CardData> GetDiscardList() { return discardList; }
    public GameObject GetObjAtInd(int ind) {
        return handList[ind].towerPrefab;
    }
    public void FillHand(int size = 3) {
        handList.Clear();
        handList = new List<CardData>(size);
        for (int i = 0; i < size; i++)
        {
            CardData currCard = GetDeckCard();
            handList.Add(currCard);
            AddToDiscard(currCard);
        }
        UIM.AddHand(handList);
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
