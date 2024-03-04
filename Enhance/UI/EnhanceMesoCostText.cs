using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnhanceMesoCostText : MonoBehaviour
{
    TextMeshProUGUI tmp;
    EnhanceGo eg;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        eg = GetComponentInParent<EnhanceGo>();
        WeaponManager.TextEvent += MesoCostTextUpdate;
    }

    private void Start()
    {
        tmp.text = string.Format("{0:N0}", eg.EnhanceCost[PlayerPrefs.GetInt("weaponLv")].ToString());
        
    }

    void MesoCostTextUpdate()
    {
        tmp.text = string.Format("{0:N0}", eg.EnhanceCost[PlayerPrefs.GetInt("weaponLv")].ToString());
    }
}
