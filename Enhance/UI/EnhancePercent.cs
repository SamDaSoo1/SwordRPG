using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnhancePercent : MonoBehaviour
{
    TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        WeaponManager.TextEvent += EnhancePercentTextUpdate;
    }

    private void Start()
    {
        tmp.text = "��ȭȮ��: " + (WeaponManager.instance.PercentageGet() / 10).ToString() + "%";
        
    }

    void EnhancePercentTextUpdate()
    {
        tmp.text = "��ȭȮ��: " + (WeaponManager.instance.PercentageGet() / 10).ToString() + "%";
    }
}
