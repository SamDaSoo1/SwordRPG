using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField] NoteDown noteDown;
    [SerializeField] Slider timeBar;
    [SerializeField] GameOver gameOver;
    [SerializeField] ComboGauge comboGauge;
    [SerializeField] WinLoseAnimation winLoseAnimation;
    [SerializeField] Button pauseButton;
    [SerializeField] NoteFailGauge noteFailGauge;
    [SerializeField] FeverMode feverMode;

    public bool IsBossMode { get; set; } = false;

    float time = 3.5f;
    float bossTime = 3000f;
    float maxTime = 3.5f;
    int speed = 100;
    bool coroutineStart = false;
    bool bossMode_CoroutineStart = false;

    private void Awake()
    {
        timeBar.maxValue = 1000;
        timeBar.value = timeBar.maxValue;
        pauseButton.interactable = true;
    }

    public void TimeDecreaseStart()
    {
        if (coroutineStart) return;
        StartCoroutine(TimeDecrease());
        coroutineStart = true;
    }

    IEnumerator TimeDecrease()
    {
        float timeDiv = time;

        while(time > 0)
        {
            timeBar.value = Mathf.Lerp(0, timeBar.maxValue, time / timeDiv);
            time -= Time.deltaTime * (speed / 100f);
            yield return null;
        }

        timeBar.value = 0;
        comboGauge.StopAllCoroutines();
        noteDown.StopAllCoroutines();
        noteFailGauge.StopAllCoroutines();
        pauseButton.interactable = false;
        gameOver.GameOverOn();
    }

    public void Recovery()
    {
        time += 0.25f;
        if(time > maxTime) time = maxTime;
    }

    public void SpeedUp()
    {
        if(speed == 300) { return; }
        speed += 10;
    }

    public void Boss_TimeDecreaseStart()
    {
        if(bossMode_CoroutineStart) return;
        StartCoroutine(Boss_TimeDecrease());
        bossMode_CoroutineStart = true;
    }

    IEnumerator Boss_TimeDecrease()
    {
        timeBar.maxValue = 3000f;
        float timeDiv = bossTime;

        while (bossTime > 0)
        {
            timeBar.value = Mathf.Lerp(0, timeBar.maxValue, bossTime / timeDiv);
            bossTime -= Time.deltaTime * 100;
            yield return null;
        }

        timeBar.value = 0;
        comboGauge.StopAllCoroutines();
        noteDown.StopAllCoroutines();
        noteFailGauge.StopAllCoroutines();
        pauseButton.interactable = false;
        IsBossMode = false;
        winLoseAnimation.Lose();
    }
}
