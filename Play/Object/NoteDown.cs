using System;
using System.Collections;
using UnityEngine;
using WindowsInput;

public class NoteDown : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] GameObject[] rightNote;
    [SerializeField] GameObject[] leftNote;

    [Header("Object")]
    [SerializeField] RandomNoteSetting randomNoteSetting;
    [SerializeField] NoteFailGauge noteFailGauge;
    [SerializeField] FeverMode feverMode;

    [Header("UI")]
    [SerializeField] Score score;
    [SerializeField] TimeBar timeBar;
    [SerializeField] ComboCount comboCount;
    [SerializeField] BossHp bossHp;

    [Header("Particle")]
    [SerializeField] DarkBall darkBall;

    int idx = 10;
    public int CharmingCount { get; set; }
    public bool AutoClicking { get; set; }

    void Update()
    {
        if (AutoClicking) return;
        if (WinInput.GetKeyDown(KeyCode.A)) { ActionDown(LeftCheck); }
        if (WinInput.GetKeyDown(KeyCode.S)) { ActionDown(LeftCheck); }
        if (WinInput.GetKeyDown(KeyCode.K)) { ActionDown(RightCheck); }
        if (WinInput.GetKeyDown(KeyCode.L)) { ActionDown(RightCheck); }
    }

    public IEnumerator AutoClickCo()
    {
        ActionDown(LeftCheck);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(AutoClickCo());
    }

    // 노트 내려오게 하는 함수
    // 입력값: 키보드 키(A,S,K,L)
    void ActionDown(Action noteCheck)
    {
        if (noteFailGauge.KeyBoardLock) return;
        noteCheck();
        NoteDownAndSet();
    }

    void NoteDownAndSet()
    {
        for (int i = 0; i < rightNote.Length; i++)
        {
            rightNote[i].GetComponent<Note>().Down();
            leftNote[i].GetComponent<Note>().Down();
        }

        if (!feverMode.Fever) { randomNoteSetting.Set(); }
        else { randomNoteSetting.Idx--; }
    }

    // ---------------------------Right----------------------------

    void RightCheck()
    {
        if (rightNote[idx].CompareTag("Bomb")) { RightBomb(); }
        else if (rightNote[idx].CompareTag("Meso")) { RightMeso(); }

        idx--;
        if (idx < 0) { idx = 10; }
    }

    void RightBomb()
    {
        //print("오른쪽 폭탄");
        SoundManager.instance.PlaySFX(eSound.Die);
        TimeBarState_Bomb(timeBar.IsBossMode);

        noteFailGauge.KeyBoardLock = true;
        noteFailGauge.GaugeOn();
        comboCount.ComboReset();
    }

    void RightMeso()
    {
        //print("오른쪽 메소");

        SoundManager.instance.PlaySFX(eSound.Damage);
        CharmingCount++;

        TimeBarState_Meso(timeBar.IsBossMode);

        if (score.enabled) { score.Up(PlayerPrefs.GetInt("weaponLv")); }
        else { bossHp.BossAttack(PlayerPrefs.GetInt("weaponLv")); }

        darkBall.Shoot();
        comboCount.ComboUpdate();
    }

    // ---------------------------Left----------------------------

    void LeftCheck()
    {
        if (leftNote[idx].CompareTag("Bomb")) { LeftBomb(); }
        else if (leftNote[idx].CompareTag("Meso")) { LeftMeso(); }

        idx--;
        if (idx < 0) { idx = 10; }
    }

    void LeftBomb()
    {
        //print("왼쪽 폭탄");
        SoundManager.instance.PlaySFX(eSound.Die);
        TimeBarState_Bomb(timeBar.IsBossMode);

        noteFailGauge.KeyBoardLock = true;
        noteFailGauge.GaugeOn();
        comboCount.ComboReset();
    }

    void LeftMeso()
    {
        //print("왼쪽 메소");
        SoundManager.instance.PlaySFX(eSound.Damage);

        CharmingCount++;

        TimeBarState_Meso(timeBar.IsBossMode);

        if (score.enabled) { score.Up(PlayerPrefs.GetInt("weaponLv")); }
        else { bossHp.BossAttack(PlayerPrefs.GetInt("weaponLv")); }

        darkBall.Shoot();
        comboCount.ComboUpdate();
    }

    // ---------------------------Etc----------------------------

    void TimeBarState_Bomb(bool isBossMode)
    {
        if (isBossMode)
        {
            timeBar.Boss_TimeDecreaseStart();
        }
        else
        {
            NormalMode_Bomb();
        }
    }

    void NormalMode_Bomb()
    {
        if (CharmingCount == 0) { timeBar.TimeDecreaseStart(); }
    }

    void TimeBarState_Meso(bool isBossMode)
    {
        if (isBossMode)
        {
            timeBar.Boss_TimeDecreaseStart();
        }
        else
        {
            NormalMode_Meso();
        }
    }

    void NormalMode_Meso()
    {
        if (CharmingCount == 1) { timeBar.TimeDecreaseStart(); }
        else if (CharmingCount > 1) { timeBar.Recovery(); }

        if (CharmingCount % 100 == 0)
        {
            timeBar.SpeedUp();
        }
    }
}
