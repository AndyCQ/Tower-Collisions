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

    private void Start() {
        GameCardManager GCM = GameObject.FindGameObjectWithTag("GameCardManager").GetComponent<GameCardManager>();
        foreach (GameCardData GCD in GCM.MainCardList) {
            if (GCD.CD == currCard) {
                count = GCD.count;
            }
        }
    }

    private void Update() {
        if (setup) {
            cardText.text = currCard.cardName + " : " + count;
            setup = false;
        }
    }

    public void AddToDeck() {
        GameObject currDeckButton = Instantiate(deckButton, deckPanel.transform);
        currDeckButton.GetComponent<DeckButton>().currCard = currCard;
        count -= 1;
    }

    public void DestroySelf() { Destroy(this.gameObject); }
}
