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
    int count;

    private void Start() {
        count = MainCardArray.CardArray[currCard.mainArrayIndex];
    }

    private void Update() {
        if (setup) {
            cardText.text = currCard.cardName + " : " + count;
            setup = false;
        }
    }

    public void AddToDeck() {
        
    }

    public void DestroySelf() { Destroy(this.gameObject); }
}
