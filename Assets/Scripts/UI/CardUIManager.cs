using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUIManager : MonoBehaviour
{
    [SerializeField]
    GameObject cardButtonPrefab;
    [SerializeField]
    GameObject UIPanel;
    List<GameObject> currButtons = new List<GameObject>();

    public void AddHand(List<CardData> handList) {
        ClearButtons();
        foreach (CardData cd in handList) {
            GameObject currButton = Instantiate(
                cardButtonPrefab,
                UIPanel.transform.position,
                Quaternion.identity,
                UIPanel.transform) as GameObject;
            currButton.GetComponent<CardButton>().currCard = cd;
            currButton.GetComponent<CardButton>().SetUp();
            currButton.GetComponent<CardButton>().SetArt();
            currButtons.Add(currButton);
        }
    }

    public void ClearButtons() {
        foreach (GameObject go in currButtons) {
            Destroy(go);
        }
    }
}
