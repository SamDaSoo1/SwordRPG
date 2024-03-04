using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] GameObject pauseWindow;
    [SerializeField] GameOver gameOver;
    [SerializeField] NoteFailGauge noteFailGauge;
    [SerializeField] TimeBar timeBar;
    [SerializeField] ComboGauge comboGauge;
    [SerializeField] WinLoseAnimation winLoseAnimation;

    private void Awake()
    {
        pauseWindow.SetActive(false);
    }

    public void OnClick()
    {
        SoundManager.instance.PlaySFX(eSound.Button);
        noteFailGauge.KeyBoardLock = true;
        pauseButton.interactable = false;
        pauseWindow.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        SoundManager.instance.PlaySFX(eSound.Button);
        noteFailGauge.KeyBoardLock = false;
        pauseWindow.SetActive(false);
        pauseButton.interactable = true;
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        SoundManager.instance.PlaySFX(eSound.Button);
        pauseWindow.SetActive(false);
        Time.timeScale = 1f;
        noteFailGauge.KeyBoardLock = true;
        timeBar.StopAllCoroutines();
        comboGauge.StopAllCoroutines();

        if(gameOver.enabled)
            gameOver.GameOverOn();
        else
            winLoseAnimation.Lose();
    }
}
