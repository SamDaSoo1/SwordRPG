using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverMode : MonoBehaviour
{
    [SerializeField] GameObject[] rightNote;
    [SerializeField] GameObject[] leftNote;
    [SerializeField] Sprite feverNote;
    [SerializeField] ComboGauge comboGauge;
    [SerializeField] SpriteRenderer backGround;
    [SerializeField] NoteDown noteDown;

    public bool Fever { get; set; }

    Animator animator;
    Color backGroundColor;

    void Awake()
    {
        animator = GetComponent<Animator>();
        backGroundColor = backGround.color;
    }

    public void FeverOn()
    {
        Fever = true;
        if (5 <= PlayerPrefs.GetInt("RelicSilhouette"))
        {
            transform.localScale = new Vector3(0.58f, 1.35f, 1);
            animator.SetBool("BlackMageFever", true);
        }
        else if(5 > PlayerPrefs.GetInt("RelicSilhouette"))
        {
            transform.localScale = new Vector3(0.42f, 1.31f, 1);
            animator.SetBool("Fever", true);
        }
        
        for(int i = 0; i < rightNote.Length; i++)
        {
            rightNote[i].GetComponent<SpriteRenderer>().sprite = feverNote;
            rightNote[i].tag = "Meso";
            leftNote[i].GetComponent<SpriteRenderer>().sprite = feverNote;
            leftNote[i].tag = "Meso";
        }
        backGround.color = Color.black;
        comboGauge.ComboGaugeDecreaseStart();
    }

    public void FeverOff()
    {
        Fever = false;

        if (5 <= PlayerPrefs.GetInt("RelicSilhouette"))
        {
            animator.SetBool("BlackMageFever", false);
        }
        else if (5 > PlayerPrefs.GetInt("RelicSilhouette"))
        {
            animator.SetBool("Fever", false);
        }
        
        backGround.color = backGroundColor;
    }
}
