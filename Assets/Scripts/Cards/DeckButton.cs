using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckButton : MonoBehaviour
{
    public CardData currCard;
    [SerializeField]
    Image cardSprite;
    [SerializeField]
    TMPro.TextMeshProUGUI cardText;
    bool setup = false;

    private void Update() {
        if (setup && currCard != null) {
            cardText.text = currCard.cardName;
            setup = false;
        }
    }

    public void DestroySelf() { Destroy(this.gameObject); }
}
