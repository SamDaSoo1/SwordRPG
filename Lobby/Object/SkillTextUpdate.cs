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
        {"�ǹ� ������ ", 0 },
        {"�ǹ��� ����� ", 1 },
        {"�⺻ ����� ", 1 },
        {"�޼� ȹ�淮 ", 1 },
        {"ũ��Ƽ�� ����� ", 0 },
        {"�ǹ� ���ӽð� ", 0 },
    };

    RelicData data;

    string[] a;
    string[] b;
    string[] c;

    int count = 0;            // ť�� �ɼǿ� ����Ŭ���� �ִ��� ������ üũ�ϴ� ����. 0�̸� ���°Ű� 1�̸� �ִ°���
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
            {"�ǹ� ������ ", 0 },
            {"�ǹ��� ����� ", 1 },
            {"�⺻ ����� ", 1 },
            {"�޼� ȹ�淮 ", 1 },
            {"ũ��Ƽ�� ����� ", 0 },
            {"�ǹ� ���ӽð� ", 0 },
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

            if(data.ability1.Substring(9, 2) == "�ߵ�")
            {
                PlayerPrefs.SetInt("AutoClick", 1);
                count = 1;
            }
            else
            {
                a = data.ability1.Split(':');
                dict[a[0]] += int.Parse(a[1].Substring(1, 1));
            }

            if (data.ability2.Substring(9, 2) == "�ߵ�")
            {
                PlayerPrefs.SetInt("AutoClick", 1);
                count = 1;
            }
            else
            {
                b = data.ability2.Split(':');
                dict[b[0]] += int.Parse(b[1].Substring(1, 1));
            }

            if (data.ability3.Substring(9, 2) == "�ߵ�")
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

        PlayerPrefs.SetInt("FeverChargeAmount", dict["�ǹ� ������ "]);
        PlayerPrefs.SetInt("FeverDamage", dict["�ǹ��� ����� "]);
        PlayerPrefs.SetInt("Damage", dict["�⺻ ����� "]);
        PlayerPrefs.SetInt("MesoAcquisitionAmount", dict["�޼� ȹ�淮 "]);
        PlayerPrefs.SetInt("CriticalDamage", dict["ũ��Ƽ�� ����� "]);
        PlayerPrefs.SetInt("FeverTime", dict["�ǹ� ���ӽð� "]);

        skill1.text = "�⺻ ����� +" + (PlayerPrefs.GetInt("Damage") - 1).ToString() + "��";
        skill2.text = "�޼� ȹ�淮 +" + (PlayerPrefs.GetInt("MesoAcquisitionAmount") - 1).ToString() + "��";
        skill3.text = "ũ��Ƽ�� ����� +" + PlayerPrefs.GetInt("CriticalDamage").ToString() + "��";

        if(reset)
            skill4.text = "ũ��Ƽ�� Ȯ�� " + 1 + "%";
        else
            skill4.text = "ũ��Ƽ�� Ȯ�� " + PlayerPrefs.GetInt("CriticalPercentage").ToString() + "%";

        skill5.text = "�ǹ��� ����� +" + (PlayerPrefs.GetInt("FeverDamage") - 1).ToString() + "��";
        skill6.text = "�ǹ� ���ӽð� +" + PlayerPrefs.GetInt("FeverTime").ToString() + "��";
        skill7.text = "�ǹ� ������ +" + PlayerPrefs.GetInt("FeverChargeAmount").ToString() + "��";

        reset = false;
    }
}
