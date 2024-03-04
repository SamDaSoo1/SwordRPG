using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityTextManager : MonoBehaviour
{
    [SerializeField] Text abil1;
    [SerializeField] Text abil2;
    [SerializeField] Text abil3;
    [SerializeField] Text abil4;
    [SerializeField] Text abil5;
    [SerializeField] Text abil6;
    [SerializeField] Text abil1Per;
    [SerializeField] Text abil2Per;
    [SerializeField] Text abil3Per;
    [SerializeField] Text abil4Per;
    [SerializeField] Text abil5Per;
    [SerializeField] Text abil6Per;
    [SerializeField] Text grade;

    string[] abil1Group;
    string[] abil2Group;
    string[] abil3Group;
    string[] abil4Group;
    string[] abil5Group;
    string[] abil6Group;
    string[] abil1PerGroup;
    string[] abil2PerGroup;
    string[] abil3PerGroup;
    string[] abil4PerGroup;
    string[] abil5PerGroup;
    string[] abil6PerGroup;
    string[] gradeGroup;

    int idx = 0;

    int Index
    {
        get { return idx; }
        set
        {
            if (value < 0) { value = 0; }
            if (value > 11) { value = 11; }

            idx = value;
        }
    }

    private void Awake()
    {
        abil1Group = new string[]
        {
            "피버 충전량 : 2배 증가",
            "피버 충전량 : 2배 증가",
            "피버 충전량 : 3배 증가",
            "피버 충전량 : 2배 증가",
            "피버 충전량 : 3배 증가",
            "피버 충전량 : 4배 증가",
            "피버 충전량 : 2배 증가",
            "피버 충전량 : 3배 증가",
            "피버 충전량 : 4배 증가",
            "피버 충전량 : 5배 증가",
            "피버시 오토클릭 발동"
        };
        abil2Group = new string[]
        {
            "피버시 대미지 : 2배 증가",
            "피버시 대미지 : 2배 증가",
            "피버시 대미지 : 3배 증가",
            "피버시 대미지 : 2배 증가",
            "피버시 대미지 : 3배 증가",
            "피버시 대미지 : 4배 증가",
            "피버시 대미지 : 2배 증가",
            "피버시 대미지 : 3배 증가",
            "피버시 대미지 : 4배 증가",
            "피버시 대미지 : 5배 증가",
            ""
        };
        abil3Group = new string[]
        {
            "기본 대미지 : 2배 증가",
            "기본 대미지 : 2배 증가",
            "기본 대미지 : 3배 증가",
            "기본 대미지 : 2배 증가",
            "기본 대미지 : 3배 증가",
            "기본 대미지 : 4배 증가",
            "기본 대미지 : 2배 증가",
            "기본 대미지 : 3배 증가",
            "기본 대미지 : 4배 증가",
            "기본 대미지 : 5배 증가",
            ""
        };
        abil4Group = new string[]
        {
            "메소 획득량 : 2배 증가",
            "메소 획득량 : 2배 증가",
            "메소 획득량 : 3배 증가",
            "메소 획득량 : 2배 증가",
            "메소 획득량 : 3배 증가",
            "메소 획득량 : 4배 증가",
            "메소 획득량 : 2배 증가",
            "메소 획득량 : 3배 증가",
            "메소 획득량 : 4배 증가",
            "메소 획득량 : 5배 증가",
            ""
        };
        abil5Group = new string[]
        {
            "크리티컬 대미지 : 2배 증가",
            "크리티컬 대미지 : 2배 증가",
            "크리티컬 대미지 : 3배 증가",
            "크리티컬 대미지 : 2배 증가",
            "크리티컬 대미지 : 3배 증가",
            "크리티컬 대미지 : 4배 증가",
            "크리티컬 대미지 : 2배 증가",
            "크리티컬 대미지 : 3배 증가",
            "크리티컬 대미지 : 4배 증가",
            "크리티컬 대미지 : 5배 증가",
            ""
        };
        abil6Group = new string[]
        {
            "피버 지속시간 : 2배 증가",
            "피버 지속시간 : 2배 증가",
            "피버 지속시간 : 3배 증가",
            "피버 지속시간 : 2배 증가",
            "피버 지속시간 : 3배 증가",
            "피버 지속시간 : 4배 증가",
            "피버 지속시간 : 2배 증가",
            "피버 지속시간 : 3배 증가",
            "피버 지속시간 : 4배 증가",
            "피버 지속시간 : 5배 증가",
            ""
        };
        abil1PerGroup = new string[]
        {
            "17%",
            "8.5%",
            "9%",
            "5.5%",
            "5.5%",
            "5.8%",
            "4.16%",
            "4.16%",
            "4.16%",
            "4.16%",
            "0.16%"
        };
        abil2PerGroup = new string[]
        {
            "17%",
            "8.5%",
            "9%",
            "5.5%",
            "5.5%",
            "5.8%",
            "4.16%",
            "4.16%",
            "4.16%",
            "4.16%",
            ""
        };
        abil3PerGroup = new string[]
        {
            "17%",
            "8.5%",
            "9%",
            "5.5%",
            "5.5%",
            "5.8%",
            "4.16%",
            "4.16%",
            "4.16%",
            "4.16%",
            ""
        };
        abil4PerGroup = new string[]
        {
            "17%",
            "8.5%",
            "9%",
            "5.5%",
            "5.5%",
            "5.8%",
            "4.16%",
            "4.16%",
            "4.16%",
            "4.16%",
            ""
        };
        abil5PerGroup = new string[]
        {
            "17%",
            "8.5%",
            "9%",
            "5.5%",
            "5.5%",
            "5.8%",
            "4.16%",
            "4.16%",
            "4.16%",
            "4.16%",
            ""
        };
        abil6PerGroup = new string[]
        {
            "15%",
            "7.5%",
            "5%",
            "5.5%",
            "5.5%",
            "5%",
            "4.16%",
            "4.16%",
            "4.16%",
            "4.16%",
            ""
        };
        gradeGroup = new string[]
        {
            "<color=#00B7FF>레어</color>",
            "<color=#9B00FF>에픽</color>",
            "<color=#9B00FF>에픽</color>",
            "<color=#FF8200>유니크</color>",
            "<color=#FF8200>유니크</color>",
            "<color=#FF8200>유니크</color>",
            "<color=#2DC800>레전드리</color>",
            "<color=#2DC800>레전드리</color>",
            "<color=#2DC800>레전드리</color>",
            "<color=#2DC800>레전드리</color>",
            "<color=#2DC800>레전드리</color>"
        };

        abil1.text = abil1Group[0];
        abil2.text = abil2Group[0];
        abil3.text = abil3Group[0];
        abil4.text = abil4Group[0];
        abil5.text = abil5Group[0];
        abil6.text = abil6Group[0];
        abil1Per.text = abil1PerGroup[0];
        abil2Per.text = abil2PerGroup[0];
        abil3Per.text = abil3PerGroup[0];
        abil4Per.text = abil4PerGroup[0];
        abil5Per.text = abil5PerGroup[0];
        abil6Per.text = abil6PerGroup[0];
        grade.text = gradeGroup[0];
    }

    public void TextUpdate1()
    {
        Index--;
        abil1.text = abil1Group[Index];
        abil2.text = abil2Group[Index];
        abil3.text = abil3Group[Index];
        abil4.text = abil4Group[Index];
        abil5.text = abil5Group[Index];
        abil6.text = abil6Group[Index];
        abil1Per.text = abil1PerGroup[Index];
        abil2Per.text = abil2PerGroup[Index];
        abil3Per.text = abil3PerGroup[Index];
        abil4Per.text = abil4PerGroup[Index];
        abil5Per.text = abil5PerGroup[Index];
        abil6Per.text = abil6PerGroup[Index];
        grade.text = gradeGroup[Index];
    }

    public void TextUpdate2()
    {
        Index++;
        abil1.text = abil1Group[Index];
        abil2.text = abil2Group[Index];
        abil3.text = abil3Group[Index];
        abil4.text = abil4Group[Index];
        abil5.text = abil5Group[Index];
        abil6.text = abil6Group[Index];
        abil1Per.text = abil1PerGroup[Index];
        abil2Per.text = abil2PerGroup[Index];
        abil3Per.text = abil3PerGroup[Index];
        abil4Per.text = abil4PerGroup[Index];
        abil5Per.text = abil5PerGroup[Index];
        abil6Per.text = abil6PerGroup[Index];
        grade.text = gradeGroup[Index];
    }
}
