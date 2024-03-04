using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MyOptionWindow : MonoBehaviour
{
    [SerializeField] Image ButtonLockImg;
    [SerializeField] GameObject myOptionWindow;
    [SerializeField] GameObject canvas_Option_UI;
    [SerializeField] SpriteRenderer myOptionWindowDummy;
    [SerializeField] SkillTextUpdate skillTextUpdate;

    Animator animator;
    SpriteRenderer spriteRenderer;
    int count = 0;

    bool IsLock { get; set; }

    void Awake()
    {
        ButtonLockImg.enabled = false;
        myOptionWindow.SetActive(true);
        animator = myOptionWindow.GetComponent<Animator>();
        spriteRenderer = myOptionWindow.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        canvas_Option_UI.SetActive(false);
        myOptionWindowDummy.color = Color.white;
        myOptionWindowDummy.enabled = false;
    }

    public void OnClick()
    {
        if (IsLock) return;
        

        StartCoroutine(ButtonLock());
        
        if (count % 2 == 0)
        {
            SoundManager.instance.PlaySFX(eSound.RollDown);
            ButtonLockImg.enabled = true;
            spriteRenderer.enabled = true;
            animator.Play("Normal", -1, 0);
            StartCoroutine(CanvasEnable());
            StartCoroutine(DummyEnable());
        }
        else if (count % 2 == 1)
        {
            SoundManager.instance.PlaySFX(eSound.RollUp);
            myOptionWindowDummy.enabled = false;
            animator.Play("Reverse", -1, 0);
            canvas_Option_UI.SetActive(false);
            StartCoroutine(Disable());
        }

        count++;
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.33f);
        spriteRenderer.enabled = false;
        ButtonLockImg.enabled = false;
    }

    IEnumerator ButtonLock()
    {
        IsLock = true;
        yield return new WaitForSeconds(0.5f);
        IsLock = false;
    }

    IEnumerator CanvasEnable()
    {
        yield return new WaitForSeconds(0.4f);
        canvas_Option_UI.SetActive(true);
    }

    IEnumerator DummyEnable()
    {
        yield return new WaitForSeconds(0.3f);
        myOptionWindowDummy.enabled = true;
        myOptionWindowDummy.color = Color.white;
        myOptionWindowDummy.DOFade(0, 0.5f);
    }

    public void Pointer_Enter()
    {
        SoundManager.instance.PlaySFX(eSound.ButtonMouseOver);
    }
}
