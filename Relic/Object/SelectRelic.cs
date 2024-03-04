using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRelic : MonoBehaviour
{
    [SerializeField] LeftRight_Button tb;
    [SerializeField] CubeScene_Button cb;
    readonly float duration = 0.25f;
    float interval = 6f;

    private void Awake()
    {
        int selectNum = PlayerPrefs.GetInt("SelectRelic");
        transform.position = new Vector3(-6 * selectNum, 0, 0);
    }

    public void MoveLeft()
    {
        tb.IsLock = true;
        cb.IsLock = true;
        transform.DOMove(Vector3.left * interval, duration).SetEase(Ease.Linear).SetRelative()
            .OnComplete(() =>
            {
                tb.IsLock = false;
                cb.IsLock = false;
            });
    }

    public void MoveRight()
    {
        tb.IsLock = true;
        cb.IsLock = true;
        transform.DOMove(Vector3.right * interval, duration).SetEase(Ease.Linear).SetRelative()
            .OnComplete(() =>
            {
                tb.IsLock = false;
                cb.IsLock = false;
            });
    }
}
