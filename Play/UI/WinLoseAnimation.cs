using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseAnimation : MonoBehaviour
{
    [SerializeField] NoteFailGauge noteFailGauge;
    [SerializeField] Image bossGameOverBG;
    [SerializeField] GameObject gameOverButton;
    [SerializeField] Button pauseButton;
    [SerializeField] TimeBar timeBar;
    [SerializeField] ComboGauge comboGauge;
    [SerializeField] BossReward bossReward;
    [SerializeField] Animator bossAnimator;
    [SerializeField] GameObject blackMageDieObj;
    [SerializeField] GameObject criticalGetEffect;
    [SerializeField] GameObject critical_Icon;
    [SerializeField] GameObject critical_IconEffect;
    [SerializeField] Text criticalText;
    [SerializeField] BossHp bossHp;

    Animator animator;

    int getBossNum;

    List<WaitForSeconds> waitBossDie;
    List<string> bossName;

    private void Awake()
    {
        criticalGetEffect.SetActive(false);
        critical_Icon.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        critical_IconEffect.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        criticalText.enabled = false;

        blackMageDieObj.SetActive(false);
        noteFailGauge.KeyBoardLock = false;
        animator = GetComponent<Animator>();
        bossGameOverBG.enabled = false;
        gameOverButton.SetActive(false);

        waitBossDie = new List<WaitForSeconds>
        {
            new WaitForSeconds(5),         // 스우 죽는모션 기다리는 시간
            new WaitForSeconds(3.5f),      // 데미안       ~
            new WaitForSeconds(3.5f),      // 루시드       ~
            new WaitForSeconds(5),         // 윌           ~
            new WaitForSeconds(3),         // 진           ~
            new WaitForSeconds(24.5f)      // 검마         ~
        };

        bossName = new List<string> { "Swoo", "Demian", "Lucid", "Will", "JinHillah", "BlackMage" };
        getBossNum = PlayerPrefs.GetInt("BossNum");
    }

    public void Win()
    {
        int bossNum = getBossNum;
        if (bossNum < 5) { PlayerPrefs.SetInt("BossNum", ++bossNum); }

        int relicNamesNum = PlayerPrefs.GetInt("RelicNames");
        if (relicNamesNum < 6) { PlayerPrefs.SetInt("RelicNames", ++relicNamesNum); }

        int treasureNum = PlayerPrefs.GetInt("RelicSilhouette");
        if (treasureNum < 6)
        {
            PlayerPrefs.SetInt("RelicSilhouette", treasureNum + 1);

            // 검마 처치할 때마다 체력 증가함수 호출
            if (PlayerPrefs.GetInt("RelicSilhouette") == 6)
            {
                bossHp.BlackMageHpUp();
            }

            StartCoroutine(WinAniPlay());
        }
        else if (treasureNum == 6)
        {
            bossHp.BlackMageHpUp();
            StartCoroutine(CriticalPerIncrease());
        }

        pauseButton.interactable = false;
        noteFailGauge.KeyBoardLock = true;
        timeBar.StopAllCoroutines();
        comboGauge.StopAllCoroutines();
    }

    public void Lose()
    {
        noteFailGauge.KeyBoardLock = true;
        StartCoroutine(LoseAniPlay());
    }

    IEnumerator CriticalPerIncrease()
    {
        yield return new WaitForSeconds(1.5f);
        if (getBossNum < 5) bossAnimator.Play(bossName[getBossNum] + "Die", -1, 0);
        else if (getBossNum == 5)
        {
            blackMageDieObj.SetActive(true);
            SoundManager.instance.PlaySFX(eSound.BlackMageShadow);
            StartCoroutine(BlackMageSpeak());
        }

        yield return waitBossDie[getBossNum];
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySFX(eSound.Win);
        bossGameOverBG.enabled = true;
        animator.Play("Win", -1, 0);

        yield return new WaitForSeconds(1.5f);
        // 크확 증가했다는 표시
        SoundManager.instance.PlaySFX(eSound.GetCri);
        criticalGetEffect.SetActive(true);
        critical_Icon.GetComponent<SpriteRenderer>().DOFade(1.0f, 1.4f);
        critical_IconEffect.GetComponent<SpriteRenderer>().DOFade(1.0f, 1.4f);

        yield return new WaitForSeconds(2f);
        string txt = "";
        int criPer = PlayerPrefs.GetInt("CriticalPercentage");
        if (criPer < 100)
        {
            txt = "크리티컬 확률 <color=#FF00DD>1%</color> 증가!";
            PlayerPrefs.SetInt("CriticalPercentage", ++criPer);
        }
        else if (criPer == 100)
        {
            txt = "크리티컬 확률이 최대입니다!";
        }
        criticalText.enabled = true;
        SoundManager.instance.PlaySFX(eSound.Text);
        criticalText.DOText(txt, 1f).OnComplete(() => SoundManager.instance.StopSFX());
     
        yield return new WaitForSeconds(2f);
        gameOverButton.SetActive(true);
    }

    IEnumerator WinAniPlay()
    {
        yield return new WaitForSeconds(1.5f);
        if(getBossNum < 5) bossAnimator.Play(bossName[getBossNum] + "Die", -1, 0);
        else if(getBossNum == 5)
        {
            blackMageDieObj.SetActive(true);
            SoundManager.instance.PlaySFX(eSound.BlackMageShadow);
            StartCoroutine(BlackMageSpeak());
        }

        yield return waitBossDie[getBossNum];
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySFX(eSound.Win);
        bossGameOverBG.enabled = true;
        animator.Play("Win", -1, 0);

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(BossRewardSound());
        bossReward.Appear();

        yield return new WaitForSeconds(4f);
        gameOverButton.SetActive(true);

        
    }

    IEnumerator LoseAniPlay()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySFX(eSound.Lose);
        bossGameOverBG.enabled = true;
        animator.Play("Lose", -1, 0);

        yield return new WaitForSeconds(1f);
        gameOverButton.SetActive(true);
    }

    IEnumerator BossRewardSound()
    {
        yield return new WaitForSeconds(0.4f);
        SoundManager.instance.PlaySFX(eSound.RelicGet);
    }

    IEnumerator BlackMageSpeak()
    {
        float curBgmVolume = PlayerPrefs.GetFloat("BGMSound");
        float plusBgmVolume = curBgmVolume - (curBgmVolume * 0.3f);
        SoundManager.instance.BGMVolume(curBgmVolume * 0.3f);

        yield return new WaitForSeconds(2.8f);
        SoundManager.instance.PlaySFX(eSound.BM1);
        yield return new WaitForSeconds(3f);
        SoundManager.instance.PlaySFX(eSound.BM2);
        yield return new WaitForSeconds(4f);
        SoundManager.instance.PlaySFX(eSound.BM3);
        yield return new WaitForSeconds(6f);
        SoundManager.instance.PlaySFX(eSound.BM4);
        yield return new WaitForSeconds(4f);

  
        for(int i = 1; i <= 10; i++)
        {
            SoundManager.instance.BGMVolume(curBgmVolume * 0.3f + (plusBgmVolume * i / 10f));
            yield return new WaitForSeconds(0.2f);
        }
    }
}
