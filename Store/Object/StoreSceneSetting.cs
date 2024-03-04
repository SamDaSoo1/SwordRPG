using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreSceneSetting : MonoBehaviour
{
    [SerializeField] TMP_Text BuyFailText;
    [SerializeField] TMP_Text BuyCompleteText;

    private void Awake()
    {
        BuyFailText.faceColor = new Color(0, 233/255f, 233/255f, 1);
        BuyCompleteText.faceColor = new Color(213/255f, 224/255f, 0, 1);
    }
}
