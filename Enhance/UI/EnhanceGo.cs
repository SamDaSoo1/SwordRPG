using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class EnhanceGo : MonoBehaviour
{
    [SerializeField] ChallengeFailText challengeFailText;
    [SerializeField] GameObject weaponImg;
    [SerializeField] WeaponPowerText weaponPowerText;

    public GameObject dark;
    public GameObject normalPtc;
    public GameObject enhancePtc;
    public GameObject enhancePtc2;
    public GameObject enhanceEndBtn;
    public GameObject enhanceFailText;
    public GameObject enhanceSuccessText;
    public MesoText mesoText;
    public int[] EnhanceCost;

    int num = 0;

    private void Awake()
    {
        challengeFailText.ModifyText("", Color.white);
    }

    public void EnhanceTry()
    {
        SoundManager.instance.PlaySFX(eSound.Button);

        if (PlayerPrefs.GetInt("weaponLv") == 39)
        {
            challengeFailText.ModifyText("��ȭ��ġ�� �ִ��Դϴ�.", new Color(8/255f, 1, 250/255f, 1));
            challengeFailText.Disappear();
            return;
        }

        // ���� �����޼Ұ� ��ȭ��뺸�� ���� ���� �ִٸ� ��ȭ�õ�
        if(EnhanceCost[PlayerPrefs.GetInt("weaponLv")] <= PlayerPrefs.GetInt("CurMeso"))
        {
            SoundManager.instance.PlaySFX(eSound.Enchanting);
            int meso = PlayerPrefs.GetInt("CurMeso") - EnhanceCost[PlayerPrefs.GetInt("weaponLv")];
            PlayerPrefs.SetInt("CurMeso", meso);
            StartCoroutine(Enhance());
        }
        else
        {
            SoundManager.instance.PlaySFX(eSound.CubeBuyFail);
            challengeFailText.ModifyText("�޼Ұ� �����մϴ�.", new Color(190/255f, 0, 0, 1));
            challengeFailText.Disappear();
            // Debug.Log($"�޼Ұ� �����մϴ�.");
        }
    }

    IEnumerator Enhance()
    {
        //yield return null;
        dark.SetActive(true);
        normalPtc.SetActive(false);
        enhancePtc.SetActive(true);

        yield return new WaitForSeconds(3f);

        num = Random.Range(1, 1001);
        
        // ��ȭ �������� ��
        if (num <= WeaponManager.instance.Percentage(PlayerPrefs.GetInt("weaponLv")))
        {
            SoundManager.instance.PlaySFX(eSound.EnchantSuccess);
            enhanceSuccessText.SetActive(true);
            enhancePtc2.SetActive(true);
            int weaponLv = PlayerPrefs.GetInt("weaponLv");
            PlayerPrefs.SetInt("weaponLv", weaponLv + 1);


            weaponImg.GetComponent<WeaponImg>().WeaponImgUpdate();
            weaponPowerText.TextUpdate();
            mesoText.TextUpdate();
            WeaponManager.instance.TextEventCall();    // ��ȭ������ �ٲ����ϴ� �ؽ�Ʈ�� ����
        }
        // ��ȭ �������� ��
        else
        {
            SoundManager.instance.PlaySFX(eSound.EnchantFail);
            mesoText.TextUpdate();
            enhanceFailText.SetActive(true);
        }

        StartCoroutine(EnhanceEndVibration());
        enhancePtc.SetActive(false);
        enhanceEndBtn.SetActive(true);
    }

    // ��ȭ ������ ���� �¿�� �ѹ� ��鸲
    IEnumerator EnhanceEndVibration()
    {
        float x = 0f;
        for (int i = 0; i < 10; i++)
        {
            x += 0.06f;

            weaponImg.GetComponent<Transform>().position = new Vector3(x, weaponImg.GetComponent<Transform>().position.y);
            yield return new WaitForSeconds(0.004f);
        }

        for (int i = 0; i < 10; i++)
        {
            x -= 0.06f;

            weaponImg.GetComponent<Transform>().position = new Vector3(x, weaponImg.GetComponent<Transform>().position.y);
            yield return new WaitForSeconds(0.004f);
        }
    }

    // ��ȭ�� ������ ������ Ȯ�ι�ư
    public void EnhanceEnd()
    {
        dark.SetActive(false);
        normalPtc.SetActive(true);
        enhanceSuccessText.SetActive(false);
        enhanceFailText.SetActive(false);
        enhancePtc2.SetActive(false);
        enhanceEndBtn.SetActive(false);
    }
}
