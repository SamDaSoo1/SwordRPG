using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfPossessions : MonoBehaviour
{
    [SerializeField] Text txt;

    int count = 0;

    private void Awake()
    {
        count = PlayerPrefs.GetInt("Cube");
        txt.text = "보유 개수: " + count + "개";
    }

    public void UpdateText()
    {
        count--;
        if (count < 0) { count = 0; }
        txt.text = "보유 개수: " + count + "개";
    }
}
