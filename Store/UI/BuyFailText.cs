using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyFailText : MonoBehaviour
{
    [SerializeField] TMP_Text tmp;
    bool IsLock { get; set; }

    private void Awake()
    {
        tmp.enabled = false;
    }

    public void Disappear()
    {
        if (IsLock) { return; }
        StartCoroutine(DisappearCo());
        IsLock = true;
    }

    IEnumerator DisappearCo()
    {
        tmp.enabled = true;
        tmp.color = Color.white;

        yield return new WaitForSeconds(0.3f);
        DOTween.ToAlpha(() => tmp.color, x => tmp.color = x, 0, 0.5f).SetEase(Ease.Linear).OnComplete( () => IsLock = false );
    }

    public void ModifyText(string str, Color color)
    {
        tmp.faceColor = color;
        tmp.text = str;
    }
}
