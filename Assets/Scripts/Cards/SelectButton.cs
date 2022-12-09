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
    [SerializeField]
    GameObject PopupPrefab;
    [SerializeField]
    Transform PopupPos;
    [SerializeField]
    float PopupWaitTime = 2f;
    GameObject currPopup;
    bool popUp = false;

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
        gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = newCD.border;
        setup = true;
    }

    public void OnClick() {
        bool ret_val = DC.SelectCard(currCard);
        if (ret_val) { count -= 1; }
    }

    public void DestroySelf() { Destroy(this.gameObject); }

    IEnumerator waitTime(float time = .5f) {
        yield return new WaitForSeconds(time);
    }

    public void startPopup() {
        if (!popUp) {
            popUp = true;
            StartCoroutine(waitTime(PopupWaitTime));
            if (popUp) {
                currPopup = Instantiate(PopupPrefab,
                            PopupPos
                            );
                currPopup.GetComponent<InfoPopup>().SetUp(currCard);
            }
        }
    }

    public void endPopup() {
        popUp = false;
        Destroy(currPopup);
    }
}
