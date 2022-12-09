using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPopup : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI mainText;

    public void SetUp(CardData card) {
        string textStr = card.cardDescription + System.Environment.NewLine;
        textStr += "Element: " + card.damageType.ToString() + System.Environment.NewLine;
        textStr += "Damage: " + card.Damage.ToString() + System.Environment.NewLine;
        textStr += "Range: " + card.range.ToString() + System.Environment.NewLine;
        textStr += "Fire Rate: " + card.fireRate.ToString() + System.Environment.NewLine;
        mainText.text = textStr;
    }
}
