using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicSetActive : MonoBehaviour
{
    [SerializeField] GameObject[] relics;

    private void Awake()
    {
        for(int i = 0; i < relics.Length; i++)
        {
            relics[i].SetActive(false);
        }

        relics[PlayerPrefs.GetInt("SelectRelic")].SetActive(true);
    }
}
