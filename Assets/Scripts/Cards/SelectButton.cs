using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    public CardData currCard;
    [SerializeField]
    public GameObject deckButton;
    [SerializeField]
    public GameObject deckPanel;
    [SerializeField]
    Image cardSprite;
    [SerializeField]
    TMPro.TextMeshProUGUI cardText;
    bool setup = false;
    int count;

    public void SetUp(CardData newCD) {
        currCard = newCD;
        GameCardManager GCM = GameObject.FindGameObjectWithTag("GameCardManager").GetComponent<GameCardManager>();
        foreach (GameCardData GCD in GCM.MainCardList) {
            if (GCD.CD.cardName == currCard.cardName) {
                count = GCD.count;
            }
        }
        cardText.text = currCard.cardName + " : " + count;
    }

    public void AddToDeck() {
        GameObject currDeckButton = Instantiate(deckButton, deckPanel.transform);
        currDeckButton.GetComponent<DeckButton>().currCard = currCard;
        count -= 1;
    }

    public void DestroySelf() { Destroy(this.gameObject); }
}
