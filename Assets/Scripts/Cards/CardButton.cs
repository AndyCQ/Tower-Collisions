using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    public CardData currCard;
    GameObject GM;
    Image cardSprite;

    private void Start() {
        GM = GameObject.FindGameObjectWithTag("GameManager");
        cardSprite = this.GetComponent<Image>();
    }

    public void SetArt() {
        cardSprite.sprite = currCard.cardArt;
    }

    public void SetTower() {
        GM.GetComponent<TouchPlacement>().currPrefab = currCard.towerPrefab;
    }
}
