using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPowerText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI weaponPowerText;

    private void Start()
    {
        weaponPowerText.text = "+" + (PlayerPrefs.GetInt("weaponLv") + 1).ToString();
    }

    public void TextUpdate()
    {
        weaponPowerText.text = "+" + (PlayerPrefs.GetInt("weaponLv") + 1).ToString();
    }
}
