using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Confirm_Acquisition: MonoBehaviour
{
    [SerializeField] SpriteRenderer[] relics;
    [SerializeField] TMP_Text tmp;

    private void Awake()
    {
        tmp.faceColor = new Color(190 / 255f, 0, 0, 1);
        tmp.outlineColor = Color.black;
        tmp.enabled = false;

    }

    bool IsLock { get; set; }

    public bool Notification_text()
    {
        if (relics[PlayerPrefs.GetInt("SelectRelic")].color == Color.black)
        {
            Disappear();
            return true;
        }
        return false;
    }

    void Disappear()
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
}
