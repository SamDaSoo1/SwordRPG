using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OKBtn2 : MonoBehaviour, IPointerState
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject oneMoreBox;
    [SerializeField] Image buttonLockImg;
    [SerializeField] GameObject oneMoreYesButton;
    [SerializeField] GameObject oneMoreNoButton;
    [SerializeField] GameObject _OKBtn2;
    [SerializeField] OneMoreYesButtonState oneMoreYesButtonState;

    public void Pointer_Enter()
    {
        SoundManager.instance.PlaySFX(eSound.ButtonMouseOver);

        animator.SetBool("IsEntered", true);
        if (!animator.GetBool("IsPressed"))
            animator.SetTrigger("Highlighted");
        else
            animator.SetTrigger("Pressed");
    }

    public void Pointer_Exit()
    {
        animator.SetBool("IsEntered", false);
        animator.SetTrigger("Normal");
    }

    public void Pointer_Down()
    {
        animator.SetTrigger("Pressed");
        animator.SetBool("IsPressed", true);
    }

    public void Pointer_Up()
    {
        if (!animator.GetBool("IsEntered"))
            animator.SetTrigger("Normal");
        else
            animator.SetTrigger("Highlighted");
        animator.SetBool("IsPressed", false);
    }

    public void Pointer_Click()
    {
        SoundManager.instance.PlaySFX(eSound.Button);

        oneMoreBox.transform.localScale = Vector3.zero;
        oneMoreYesButton.SetActive(true);
        oneMoreNoButton.SetActive(true);
        _OKBtn2.SetActive(false);
        buttonLockImg.enabled = false;
    }
}
