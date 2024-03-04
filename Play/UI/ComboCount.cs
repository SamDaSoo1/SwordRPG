using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI comboCount;
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] ComboGauge comboGauge;
    int ComboNum = 0;

    void Awake()
    {
        comboCount.text = ComboNum.ToString();
        comboCount.enabled = false;
        comboText.enabled = false;
    }

    public void ComboUpdate()
    {
        if(ComboNum == 0)
        {
            comboCount.enabled = true;
            comboText.enabled = true;
        }

        ComboNum++;
        comboCount.text = ComboNum.ToString();
        comboGauge.ComboGaugeUpdate();
    }

    public void ComboReset()
    {
        ComboNum = 0;
        comboCount.text = ComboNum.ToString();
        comboCount.enabled = false;
        comboText.enabled = false;
        comboGauge.ComboGaugeReset();
    }
}
