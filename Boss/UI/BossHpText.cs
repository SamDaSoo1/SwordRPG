using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossHpText : MonoBehaviour
{
    [SerializeField] TMP_Text bossHpText;

    List<int> bossHPList;

    private void Awake()
    {
        bossHPList = new List<int>()
        {
            5000,
            10000,
            15000,
            20000,
            25000,
            50000
        };

        bossHpText.text = "HP: " + (bossHPList[PlayerPrefs.GetInt("BossNum")] +PlayerPrefs.GetInt("BlackMageHp")).ToString();
    }
}
