using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayToLobby : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Animator BossMode_animator;
    [SerializeField] NoteFailGauge noteFailGauge;

    public void Exit()
    {
        animator.Play("Normal");
    }

    public void BossButton_Exit()
    {
        BossMode_animator.Play("Normal");
    }

    public void Down()
    {
        animator.Play("Pressed");
    }

    public void BossButton_Down()
    {
        BossMode_animator.Play("Pressed");
    }

    public void Up()
    {
        animator.Play("Normal");
    }

    public void BossButton_Up()
    {
        BossMode_animator.Play("Normal");
    }

    public void Click()
    {
        SoundManager.instance.StopSFX();
        SoundManager.instance.PlaySFX(eSound.Button);
        noteFailGauge.KeyBoardLock = false;
        SceneManager.LoadScene("Lobby");
    }

    public void BossButton_Click()
    {
        SoundManager.instance.StopSFX();
        SoundManager.instance.PlaySFX(eSound.Button);
        noteFailGauge.KeyBoardLock = false;
        SceneManager.LoadScene("Lobby");
    }
}
