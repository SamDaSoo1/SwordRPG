using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControl : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Use()
    {
        StartCoroutine(UseCo());
    }

    IEnumerator UseCo()
    {
        yield return null;
        animator.Play("Effect_Use", -1, 0);
        yield return new WaitForSeconds(1.0f);
        animator.Play("Effect_Normal", -1, 0);
    }

    public void GradeUp()
    {
        StartCoroutine(GradeUpCo());
    }

    IEnumerator GradeUpCo()
    {
        yield return null;
        animator.Play("Effect_GradeUp", -1, 0);
        yield return new WaitForSeconds(1.0f);
        animator.Play("Effect_Normal", -1, 0);
    }
}
