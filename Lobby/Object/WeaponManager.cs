using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;
    [SerializeField] float[] percentage;

    // 강화성공시 변화를 줘야하는 텍스트들 등록하는 이벤트저장소
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
