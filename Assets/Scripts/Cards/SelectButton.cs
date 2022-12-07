using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    public CardData currCard;
    [SerializeField]
    Image cardSprite;
    [SerializeField]
    TMPro.TextMeshProUGUI cardText;
    bool setup = false;
    public int count;
    [SerializeField]
    DeckCreator DC;

    private void Start() {
        DC = GameObject.FindGameObjectWithTag("DeckMenu").GetComponent<DeckCreator>();
    }

    private void Update() {
        if (setup) {
            cardText.text = currCard.cardName + " : " + count;
        }
    }

    public void SetUp(CardData newCD, int newCount) {
        currCard = newCD;
        count = newCount;
        cardText.text = currCard.cardName + " : " + count;
        cardSprite.sprite = newCD.cardArt;
        setup = true;
    }

    public void OnClick() {
        bool ret_val = DC.SelectCard(currCard);
        if (ret_val) { count -= 1; }
    }

    public void DestroySelf() { Destroy(this.gameObject); }
}
