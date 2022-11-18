using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshHand : MonoBehaviour
{
    DeckManager DM;

    private void Start() {
        DM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeckManager>();
    }

    public void Refresh() {
        int currHandSize = DM.GetCurrHandSize() - 1;
        if (currHandSize > 0) {
            DM.FillHand(currHandSize);
        } else {
            DM.ClearHand();
        }
    }
}
