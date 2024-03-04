using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeText : MonoBehaviour
{
    [SerializeField] TMP_Text tmp;

    private void Start()
    {
        tmp.text = string.Format("{0:N0}", PlayerPrefs.GetInt("Cube"));
    }

    public void Cube_Use()
    {
        int cubeNum = PlayerPrefs.GetInt("Cube");
        if(cubeNum == 0) { return; }
        tmp.text = string.Format("{0:N0}", cubeNum - 1);
        PlayerPrefs.SetInt("Cube", cubeNum - 1);
    }
}
