using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoButtonState : MonoBehaviour, IPointerState
{
    [SerializeField] GameObject window;
    [SerializeField] Animator animator;

    public void Pointer_Enter()
    {
        SoundManager.instance.PlaySFX(eSound.ButtonMouseOver);

        if (!animator.GetBool("IsPressed"))
            animator.SetTrigger("Highlighted");
        else
            animator.SetTrigger("Pressed");
    }

    public void Pointer_Exit()
    {
        animator.SetTrigger("Normal");
    }

    public void Pointer_Down()
    {
        animator.SetTrigger("Pressed");
        animator.SetBool("IsPressed", true);
    }

    public void Pointer_Up()
    {
        animator.SetTrigger("Normal");
        animator.SetBool("IsPressed", false);
    }

    public void Pointer_Click()
    {
        SoundManager.instance.PlaySFX(eSound.Button);
        window.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
