using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        if (!PlayerPrefs.HasKey("BGMSound")) { PlayerPrefs.SetFloat("BGMSound", 1); }                             // 배경음 크기
        if (!PlayerPrefs.HasKey("SFXSound")) { PlayerPrefs.SetFloat("SFXSound", 1); }                             // 효과음 크기
        if (!PlayerPrefs.HasKey("weaponLv")) { PlayerPrefs.SetInt("weaponLv", 0); }                               // 무기 레벨 저장
        if (!PlayerPrefs.HasKey("CurMeso")) { PlayerPrefs.SetInt("CurMeso", 0); }                                 // 임시로 치트써서 100만메소 보유하게함. 나중에 0으로 다시 바꿔
        if (!PlayerPrefs.HasKey("BossNum")) { PlayerPrefs.SetInt("BossNum", 0); }                                 // 어디 보스까지 잡았는지    0 = 스우, 5 = 검마
        if (!PlayerPrefs.HasKey("BlackMageHp")) { PlayerPrefs.SetInt("BlackMageHp", 0); }                         // 검은 마법사 처치한 횟수 x 10000씩 Hp를 저장하는 변수
        if (!PlayerPrefs.HasKey("RelicSilhouette")) { PlayerPrefs.SetInt("RelicSilhouette", 0); }                 // 유물 실루엣 활성화 변수   1 = 루컨마, 6 = 창뱃
        if (!PlayerPrefs.HasKey("Cube")) { PlayerPrefs.SetInt("Cube", 0); }                                       // 큐브 갯수
        if (!PlayerPrefs.HasKey("SelectRelic")) { PlayerPrefs.SetInt("SelectRelic", 0); }                         // 어떤 유물을 옵션변경하는지
        if (!PlayerPrefs.HasKey("RelicNames")) { PlayerPrefs.SetInt("RelicNames", 0); }                           // 유물 이름 활성화 변수
        if (!PlayerPrefs.HasKey("Damage")) { PlayerPrefs.SetInt("Damage", 1); }                                   // 기본 대미지 상수
        if (!PlayerPrefs.HasKey("MesoAcquisitionAmount")) { PlayerPrefs.SetInt("MesoAcquisitionAmount", 1); }     // 메소 획득량 상수
        if (!PlayerPrefs.HasKey("CriticalDamage")) { PlayerPrefs.SetInt("CriticalDamage", 0); }                   // 크리티컬 대미지 상수
        if (!PlayerPrefs.HasKey("CriticalPercentage")) { PlayerPrefs.SetInt("CriticalPercentage", 1); }           // 크리티컬 확률 상수
        if (!PlayerPrefs.HasKey("FeverDamage")) { PlayerPrefs.SetInt("FeverDamage", 1); }                         // 피버시 대미지 상수
        if (!PlayerPrefs.HasKey("FeverTime")) { PlayerPrefs.SetInt("FeverTime", 0); }                             // 피버 지속시간 상수
        if (!PlayerPrefs.HasKey("FeverChargeAmount")) { PlayerPrefs.SetInt("FeverChargeAmount", 0); }             // 피버 충전량 상수
        if (!PlayerPrefs.HasKey("AutoClick")) { PlayerPrefs.SetInt("AutoClick", 0); }                             // 피버타임오토클릭 상수(0이면 OFF, 1이면 ON)

        PlayerPrefs.SetInt("SelectRelic", 0);          // 유물 선택창에서 나갔다가 다시 들어오면 루컨마가 보이게 함
        LeftRightBtnManager.Page = 1;                  // 유물 선택창 좌우버튼값 초기화
    }
}
