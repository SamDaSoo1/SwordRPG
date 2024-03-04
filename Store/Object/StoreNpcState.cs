using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreNpcState : MonoBehaviour
{
    Animator animator;
    int ranNum = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(NpcState());
    }

    IEnumerator NpcState()
    {
        yield return new WaitForSeconds(0.6f);
        ranNum = Random.Range(0, 6);
        
        if (ranNum == 0)
        {
            animator.Play("Say", -1, 0);
            StartCoroutine(NpcState());
        }
        else if (ranNum == 1)
        {
            animator.Play("Eye", -1, 0);
            StartCoroutine(NpcState());
        }
        else
        {
            animator.Play("Stand", -1, 0);
            StartCoroutine(NpcState());
        }
    }
}
