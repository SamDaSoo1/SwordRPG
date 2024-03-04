using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        if (!PlayerPrefs.HasKey("BGMSound")) { PlayerPrefs.SetFloat("BGMSound", 1); }                             // ����� ũ��
        if (!PlayerPrefs.HasKey("SFXSound")) { PlayerPrefs.SetFloat("SFXSound", 1); }                             // ȿ���� ũ��
        if (!PlayerPrefs.HasKey("weaponLv")) { PlayerPrefs.SetInt("weaponLv", 0); }                               // ���� ���� ����
        if (!PlayerPrefs.HasKey("CurMeso")) { PlayerPrefs.SetInt("CurMeso", 0); }                                 // �ӽ÷� ġƮ�Ἥ 100���޼� �����ϰ���. ���߿� 0���� �ٽ� �ٲ�
        if (!PlayerPrefs.HasKey("BossNum")) { PlayerPrefs.SetInt("BossNum", 0); }                                 // ��� �������� ��Ҵ���    0 = ����, 5 = �˸�
        if (!PlayerPrefs.HasKey("BlackMageHp")) { PlayerPrefs.SetInt("BlackMageHp", 0); }                         // ���� ������ óġ�� Ƚ�� x 10000�� Hp�� �����ϴ� ����
        if (!PlayerPrefs.HasKey("RelicSilhouette")) { PlayerPrefs.SetInt("RelicSilhouette", 0); }                 // ���� �Ƿ翧 Ȱ��ȭ ����   1 = ������, 6 = â��
        if (!PlayerPrefs.HasKey("Cube")) { PlayerPrefs.SetInt("Cube", 0); }                                       // ť�� ����
        if (!PlayerPrefs.HasKey("SelectRelic")) { PlayerPrefs.SetInt("SelectRelic", 0); }                         // � ������ �ɼǺ����ϴ���
        if (!PlayerPrefs.HasKey("RelicNames")) { PlayerPrefs.SetInt("RelicNames", 0); }                           // ���� �̸� Ȱ��ȭ ����
        if (!PlayerPrefs.HasKey("Damage")) { PlayerPrefs.SetInt("Damage", 1); }                                   // �⺻ ����� ���
        if (!PlayerPrefs.HasKey("MesoAcquisitionAmount")) { PlayerPrefs.SetInt("MesoAcquisitionAmount", 1); }     // �޼� ȹ�淮 ���
        if (!PlayerPrefs.HasKey("CriticalDamage")) { PlayerPrefs.SetInt("CriticalDamage", 0); }                   // ũ��Ƽ�� ����� ���
        if (!PlayerPrefs.HasKey("CriticalPercentage")) { PlayerPrefs.SetInt("CriticalPercentage", 1); }           // ũ��Ƽ�� Ȯ�� ���
        if (!PlayerPrefs.HasKey("FeverDamage")) { PlayerPrefs.SetInt("FeverDamage", 1); }                         // �ǹ��� ����� ���
        if (!PlayerPrefs.HasKey("FeverTime")) { PlayerPrefs.SetInt("FeverTime", 0); }                             // �ǹ� ���ӽð� ���
        if (!PlayerPrefs.HasKey("FeverChargeAmount")) { PlayerPrefs.SetInt("FeverChargeAmount", 0); }             // �ǹ� ������ ���
        if (!PlayerPrefs.HasKey("AutoClick")) { PlayerPrefs.SetInt("AutoClick", 0); }                             // �ǹ�Ÿ�ӿ���Ŭ�� ���(0�̸� OFF, 1�̸� ON)

        PlayerPrefs.SetInt("SelectRelic", 0);          // ���� ����â���� �����ٰ� �ٽ� ������ �������� ���̰� ��
        LeftRightBtnManager.Page = 1;                  // ���� ����â �¿��ư�� �ʱ�ȭ
    }
}
