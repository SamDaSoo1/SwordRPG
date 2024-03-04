using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{
    [SerializeField] Slider bossHp;
    [SerializeField] WinLoseAnimation winLoseAnimation;
    [SerializeField] NoteFailGauge noteFailGauge;
    [SerializeField] FeverMode feverMode;
    [SerializeField] Animator criticalEffect;

    List<int> bossHpList;

    private void Awake()
    {
        criticalEffect.enabled = true;
        bossHpList = new List<int> { 5000, 10000, 15000, 20000, 25000, 50000 };         // 임시로 일단 책정함. 나중에 바꾸셈
    }

    private void Start()
    {
        criticalEffect.transform.position = new Vector3(0, 2.6f, 0);
    }

    private void OnEnable()
    {
        bossHp.interactable = false;
        bossHp.maxValue = bossHpList[PlayerPrefs.GetInt("BossNum")] + PlayerPrefs.GetInt("BlackMageHp");
        bossHp.value = bossHpList[PlayerPrefs.GetInt("BossNum")] + PlayerPrefs.GetInt("BlackMageHp");
    }

    public void BossAttack(int weaponPower)
    {
        int criticalPer = Random.Range(0, 100);
        int critical = 1;
        if (criticalPer < PlayerPrefs.GetInt("CriticalPercentage"))
        {
            if (feverMode.Fever)
                critical = (2 + PlayerPrefs.GetInt("CriticalDamage")) * PlayerPrefs.GetInt("FeverDamage");
            else
                critical = 2 + PlayerPrefs.GetInt("CriticalDamage");

            //print("오우 크리터짐");
            //print((weaponPower + 1) * PlayerPrefs.GetInt("Damage") * critical);
            StartCoroutine(CriticalEffectCo());
        }

        bossHp.value -= (weaponPower + 1) * PlayerPrefs.GetInt("Damage") * critical;
        if (bossHp.value == 0)
        {

            noteFailGauge.StopAllCoroutines();
            winLoseAnimation.Win();
        } 
    }

    IEnumerator CriticalEffectCo()
    {
        yield return new WaitForSeconds(0.3f);
        criticalEffect.Play("Idle", -1, 0);
    }

    public void BlackMageHpUp()
    {
        int hp = PlayerPrefs.GetInt("BlackMageHp") + 10000;
        PlayerPrefs.SetInt("BlackMageHp", hp);                // 임시로 정함. 나중에 밸패 ㄱ
    }
}