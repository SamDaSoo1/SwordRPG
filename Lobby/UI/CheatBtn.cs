using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatBtn : MonoBehaviour
{
    [SerializeField] Text txt;

    bool islock;

    private void Start()
    {
        txt.color = new Color(1, 1, 1, 0);
    }

    public void DamageBtnClick()
    {
        if (islock)
            return;

        islock = true;
        txt.color = Color.green;

        PlayerPrefs.SetInt("Damage", PlayerPrefs.GetInt("Damage") + 100);
        StartCoroutine(ResetImg());
    }

    IEnumerator ResetImg()
    {
        yield return new WaitForSeconds(0.1f);
        txt.color = new Color(1, 1, 1, 0);
        islock = false;
    }
}
