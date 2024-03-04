using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MesoText : MonoBehaviour
{
    [SerializeField] TMP_Text tmp;

    private void Start()
    {
        TextUpdate();
    }

    public void TextUpdate()
    {
        // 1000단위마다 콤마 넣는 포맷형식
        tmp.text = string.Format("{0:N0}", PlayerPrefs.GetInt("CurMeso"));
    }
}
