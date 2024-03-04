using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillTextUpdate : MonoBehaviour
{
    [SerializeField] Text skill1;
    [SerializeField] Text skill2;
    [SerializeField] Text skill3;
    [SerializeField] Text skill4;
    [SerializeField] Text skill5;
    [SerializeField] Text skill6;
    [SerializeField] Text skill7;

    Dictionary<string, int> abilityType = new Dictionary<string, int>()
    {
        {"피버 충전량 ", 0 },
        {"피버시 대미지 ", 1 },
        {"기본 대미지 ", 1 },
        {"메소 획득량 ", 1 },
        {"크리티컬 대미지 ", 0 },
        {"피버 지속시간 ", 0 },
    };

    RelicData data;

    string[] a;
    string[] b;
    string[] c;

    int count = 0;            // 큐브 옵션에 오토클릭이 있는지 없는지 체크하는 변수. 0이면 없는거고 1이면 있는거임
    bool reset = false;


    void Start()
    {
        SeparationDict(abilityType);
    }

    public void TextReset()
    {
        reset = true;
        abilityType = new Dictionary<string, int>()
        {
            {"피버 충전량 ", 0 },
            {"피버시 대미지 ", 1 },
            {"기본 대미지 ", 1 },
            {"메소 획득량 ", 1 },
            {"크리티컬 대미지 ", 0 },
            {"피버 지속시간 ", 0 },
        };
        SeparationDict(abilityType);
    }

    void SeparationDict(Dictionary<string, int> dict)
    {
        for (int i = 1; i <= 6; i++)
        {
            string path = Path.Combine(Application.persistentDataPath, "RelicData" + i.ToString() + ".json");
            string jsonData = File.ReadAllText(path);
            data = JsonUtility.FromJson<RelicData>(jsonData);

            if (data.ability1 == "") { continue; }

            if(data.ability1.Substring(9, 2) == "발동")
            {
                PlayerPrefs.SetInt("AutoClick", 1);
                count = 1;
            }
            else
            {
                a = data.ability1.Split(':');
                dict[a[0]] += int.Parse(a[1].Substring(1, 1));
            }

            if (data.ability2.Substring(9, 2) == "발동")
            {
                PlayerPrefs.SetInt("AutoClick", 1);
                count = 1;
            }
            else
            {
                b = data.ability2.Split(':');
                dict[b[0]] += int.Parse(b[1].Substring(1, 1));
            }

            if (data.ability3.Substring(9, 2) == "발동")
            {
                PlayerPrefs.SetInt("AutoClick", 1);
                count = 1;
            }
            else
            {
                c = data.ability3.Split(':');
                dict[c[0]] += int.Parse(c[1].Substring(1, 1));
            }

            // print(a[0] + ", " + a[1].Substring(1, 1));
            // print(b[0] + ", " + b[1].Substring(1, 1));
            // print(c[0] + ", " + c[1].Substring(1, 1));
        }

        if (count == 0) { PlayerPrefs.SetInt("AutoClick", 0); }

        PlayerPrefs.SetInt("FeverChargeAmount", dict["피버 충전량 "]);
        PlayerPrefs.SetInt("FeverDamage", dict["피버시 대미지 "]);
        PlayerPrefs.SetInt("Damage", dict["기본 대미지 "]);
        PlayerPrefs.SetInt("MesoAcquisitionAmount", dict["메소 획득량 "]);
        PlayerPrefs.SetInt("CriticalDamage", dict["크리티컬 대미지 "]);
        PlayerPrefs.SetInt("FeverTime", dict["피버 지속시간 "]);

        skill1.text = "기본 대미지 +" + (PlayerPrefs.GetInt("Damage") - 1).ToString() + "배";
        skill2.text = "메소 획득량 +" + (PlayerPrefs.GetInt("MesoAcquisitionAmount") - 1).ToString() + "배";
        skill3.text = "크리티컬 대미지 +" + PlayerPrefs.GetInt("CriticalDamage").ToString() + "배";

        if(reset)
            skill4.text = "크리티컬 확률 " + 1 + "%";
        else
            skill4.text = "크리티컬 확률 " + PlayerPrefs.GetInt("CriticalPercentage").ToString() + "%";

        skill5.text = "피버시 대미지 +" + (PlayerPrefs.GetInt("FeverDamage") - 1).ToString() + "배";
        skill6.text = "피버 지속시간 +" + PlayerPrefs.GetInt("FeverTime").ToString() + "초";
        skill7.text = "피버 충전량 +" + PlayerPrefs.GetInt("FeverChargeAmount").ToString() + "배";

        reset = false;
    }
}
