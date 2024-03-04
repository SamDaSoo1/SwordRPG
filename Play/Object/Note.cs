using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField] int idx;
    
    readonly List<Vector3> Rlist = new();
    readonly List<Vector3> Llist = new();

    float yPos = 7.5f;

    void Start()
    {
        for(int i = 0; i <= 10; i++)
        {
            Rlist.Add(new(1.6f, yPos, 0));
            Llist.Add(new(-1.6f, yPos, 0));
            yPos -= 1;
        }
    }

    public void Down()
    {
        transform.DOKill();

        if (idx == 10 && transform.position.x > 0)
        {
            transform.position = Rlist[0];
            idx = 0;
            return;
        }
        else if (idx == 10 && transform.position.x < 0)
        {
            transform.position = Llist[0];
            idx = 0;
            return;
        }

        idx++;

        if (transform.position.x > 0)
            transform.DOMove(Rlist[idx], 0.2f).SetEase(Ease.OutExpo);
        else if (transform.position.x < 0)
            transform.DOMove(Llist[idx], 0.2f).SetEase(Ease.OutExpo);
    }
}
