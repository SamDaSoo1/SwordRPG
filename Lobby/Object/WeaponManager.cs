using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;
    [SerializeField] float[] percentage;

    // ��ȭ������ ��ȭ�� ����ϴ� �ؽ�Ʈ�� ����ϴ� �̺�Ʈ�����
    public static event Action TextEvent;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public float Percentage(int idx)
    {
        return percentage[idx];
    }

    public void TextEventCall()
    {
        TextEvent?.Invoke();
    }

    public float PercentageGet()
    {
        return percentage[PlayerPrefs.GetInt("weaponLv")];
    }

    public void ResetImgAndText()
    {

    }
}
