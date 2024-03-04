using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuyButtonState : MonoBehaviour, IPointerState
{
    [SerializeField] BuyFailText buyFailText;
    [SerializeField] Quantity quantity;
    [SerializeField] GameObject window;
    [SerializeField] Animator animator;

    private void Awake()
    {
        window.SetActive(true);
        window.GetComponent<RectTransform>().localScale = Vector3.zero;
    }

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
        if (quantity.Count == 0) 
        {
            SoundManager.instance.PlaySFX(eSound.Button);
            buyFailText.ModifyText("������ �������ּ���.", new Color(0, 233 / 255f, 233 / 255f, 1));
            buyFailText.Disappear(); 
            return; 
        }
        else
        {
            SoundManager.instance.PlaySFX(eSound.Window);
        }
        window.GetComponent<RectTransform>().localScale = Vector3.one;
    }
}
