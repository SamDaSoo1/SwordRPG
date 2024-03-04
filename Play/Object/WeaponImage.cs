using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponImage : MonoBehaviour
{
    [SerializeField] Sprite[] weaponImg;
    [SerializeField] TextMeshProUGUI weaponPowerText;

    void Start()
    {
        weaponPowerText.text = "+" + (PlayerPrefs.GetInt("weaponLv") + 1).ToString();
        gameObject.GetComponent<SpriteRenderer>().sprite = weaponImg[PlayerPrefs.GetInt("weaponLv")];
    }
}
