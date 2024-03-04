using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] GameObject mesoBox;
    [SerializeField] GameObject score;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject bossHp;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject darkBallStart;
    [SerializeField] GameObject darkBallEnd;
    [SerializeField] ComponentControl componentControl;
    [SerializeField] TimeBar timeBar;

    Vector3 LocationPos = new Vector3(-11.5f, -62.5f, 0);
    Vector3 reLocationPos = new Vector3(-11.5f, -112.5f, 0);

    private void Awake()
    {
        if (IsChangeObject.EnterBoss)
        {
            componentControl.ComponentDisable();
            mesoBox.SetActive(false);
            score.SetActive(false);
            boss.SetActive(true);
            bossHp.SetActive(true);
            pauseButton.GetComponent<RectTransform>().anchoredPosition = reLocationPos;
            darkBallStart.GetComponent<DarkBallStart>().BossTarget();
            darkBallEnd.GetComponent<DarkBallEnd>().BossTarget();
            timeBar.IsBossMode = true;
            IsChangeObject.EnterBoss = false;
        }
        else
        {
            componentControl.ComponentEnable();
            mesoBox.SetActive(true);
            score.SetActive(true);
            boss.SetActive(false);
            bossHp.SetActive(false);
            pauseButton.GetComponent<RectTransform>().anchoredPosition = LocationPos;
            darkBallStart.GetComponent<DarkBallStart>().BoxTarget();
            darkBallEnd.GetComponent<DarkBallEnd>().BoxTarget();
            timeBar.IsBossMode = false;
        }
    }
}
