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
    bool setup = false;

    private void Start() {
        GM = GameObject.FindGameObjectWithTag("GameManager");
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
        GM.GetComponent<TouchPlacement>().currPrefab = currCard.towerPrefab;
        Destroy(this.gameObject);
    }
}
