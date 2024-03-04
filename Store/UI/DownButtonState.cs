using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownButtonState : MonoBehaviour, IPointerState
{
    [SerializeField] Quantity quantity;
    [SerializeField] Animator animator;
    [SerializeField] CubePrice cubePrice;

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
        if(!animator.GetBool("IsEntered"))
            animator.SetTrigger("Normal");
        else
            animator.SetTrigger("Highlighted");
        animator.SetBool("IsPressed", false);
    }

    public void Pointer_Click()
    {
        SoundManager.instance.PlaySFX(eSound.Button);
        quantity.Down();
        cubePrice.Subtract();
    }
}
