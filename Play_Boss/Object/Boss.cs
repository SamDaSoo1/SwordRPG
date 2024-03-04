using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    Animator animator;
    List<string> bossName;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        bossName = new List<string> { "Swoo", "Demian", "Lucid", "Will", "JinHillah", "BlackMage" };
    }

    private void Start()
    {
        animator.Play(bossName[PlayerPrefs.GetInt("BossNum")]);
    }
}
