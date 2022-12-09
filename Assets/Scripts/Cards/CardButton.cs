using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    public CardData currCard;
    GameObject GM;
    [SerializeField]
    Image cardSprite;
    [SerializeField]
    TMPro.TextMeshProUGUI cardText;
    Image butImage;
    bool setup = false;
    bool selected = false;

    private void Start() {
        GM = GameObject.FindGameObjectWithTag("GameManager");
        butImage = this.GetComponent<Image>();
    }

    private void Update() {
        if (setup) {
            cardText.text = currCard.cardName;
            setup = false;
        }
    }

    public void SetUp() {
        setup = true;
    }

    public void SetArt() {
        cardSprite.sprite = currCard.cardArt;
    }

    public void SetText() {
        cardText.text = currCard.cardName;
    }

    public void SetTower() {
        TouchPlacement TP = GM.GetComponent<TouchPlacement>();
        if (TP.currTower == null && !selected) {
            TP.currTower = currCard;
            TP.currButton = this.gameObject;
            butImage.color = Color.gray;
            selected = true;
        } else if (TP.currTower != null && selected) {
            TP.currTower = null;
            TP.currButton = null;
            butImage.color = Color.white;
            selected = false;
        }
    }
}
