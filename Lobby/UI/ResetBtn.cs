using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResetBtn : MonoBehaviour
{
    [SerializeField] Text resetText;
    [SerializeField] TMP_Text meso;
    [SerializeField] TMP_Text cube;
    [SerializeField] WeaponImg weaponImg;
    [SerializeField] WeaponPowerText weaponPowerText;
    [SerializeField] SkillTextUpdate skillTextUpdate;


    bool islock;

    private void Start()
    {
        resetText.color = new Color(1, 1, 1, 0);
    }

    public void ResetBtnClick()
    {
        if (islock)
            return;

        islock = true;
        resetText.color = new Color(1, 0, 146 / 255f, 1);

        PlayerPrefs.DeleteAll();

        for (int i = 1; i <= 6; i++)
        {
            // �����͸� ������ ��� ����
            string path = Path.Combine(Application.persistentDataPath, "RelicData" + i.ToString() + ".json");
            // ToJson�� ����ϸ� JSON���·� �����õ� ���ڿ��� �����ȴ�  
            string jsonData = JsonUtility.ToJson(new RelicData { grade = "����", ability1 = "", ability2 = "", ability3 = "", isOpen = false }, true);
            // ���� ���� �� ����

            File.WriteAllText(path, jsonData);
        }

        meso.text = "0";
        cube.text = "0";
        weaponImg.WeaponImgUpdate();
        weaponPowerText.TextUpdate();
        skillTextUpdate.TextReset();

        StartCoroutine(ResetImg());
    }

    IEnumerator ResetImg()
    {
        yield return new WaitForSeconds(1f);
        resetText.color = new Color(1, 1, 1, 0);
        islock = false;
    }
}
