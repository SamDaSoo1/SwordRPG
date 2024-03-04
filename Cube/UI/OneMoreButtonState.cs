using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class OneMoreButtonState : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject window;
    [SerializeField] Image buttonLockImg;
    [SerializeField] AbilityManager abilityManager;
    [SerializeField] Text txt;
    [SerializeField] BaseRelic[] relics;

    public bool isLock;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Cube") == 0)
        {
            isLock = true;
            animator.SetTrigger("Disabled");
        }
    }

    private void Start()
    {
        if (!relics[PlayerPrefs.GetInt("SelectRelic")].IsOpen())
        {
            isLock = true;
            animator.SetTrigger("Disabled");
        }
            
        buttonLockImg.enabled = false;
        window.SetActive(true);
        window.transform.localScale = Vector3.zero;
    }

    public void Pointer_Enter()
    {
        if (isLock) { return; }

        SoundManager.instance.PlaySFX(eSound.ButtonMouseOver);

        animator.SetBool("IsEntered", true);

        if (!animator.GetBool("IsPressed"))
            animator.SetTrigger("Highlighted");
        else
            animator.SetTrigger("Pressed");
    }

    public void Pointer_Exit()
    {
        if (isLock) { return; }

        animator.SetBool("IsEntered", false);
        animator.SetTrigger("Normal");
    }

    public void Pointer_Down()
    {
        if (isLock) { return; }

        animator.SetTrigger("Pressed");
        animator.SetBool("IsPressed", true);
    }

    public void Pointer_Up()
    {
        if (isLock) { return; }

        if (!animator.GetBool("IsEntered"))
            animator.SetTrigger("Normal");
        else
            animator.SetTrigger("Highlighted");
        animator.SetBool("IsPressed", false);
    }

    public void Pointer_Click()
    {
        if (isLock) { return; }

        buttonLockImg.enabled = true;
        window.transform.localScale = Vector3.one;
        SoundManager.instance.PlaySFX(eSound.Window);
        txt.text = "잠재능력을 재설정 하시겠습니까?";
    }

    public void Open()
    {
        if (PlayerPrefs.GetInt("Cube") == 0)
        {
            isLock = true;
            animator.SetTrigger("Disabled");
        }

        isLock = false;
        animator.SetTrigger("Normal");
    }
}
