using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using WindowsInput;

public class OneMoreYesButtonState : MonoBehaviour, IPointerState
{
    [SerializeField] Animator animator;
    [SerializeField] EffectControl effectControl;
    [SerializeField] GameObject window;
    [SerializeField] CubeText cubeText;
    [SerializeField] Image buttonLockImg;
    [SerializeField] Text txt;
    [SerializeField] NumberOfPossessions nop;
    [SerializeField] BaseRelic[] relics;
    [SerializeField] GameObject oKbtn2;
    [SerializeField] GameObject oneMoreButton;
    [SerializeField] GameObject oneMoreYesButton;
    [SerializeField] GameObject oneMoreNoButton;
    [SerializeField] MesoText mesoText;

    OneMoreButtonState oneMoreButtonState;
    Animator oneMoreButtonAnim;

    bool isLock;
    bool notPlayCo;

    string dummytxt;

    float time = 0;

    private void Awake()
    {
        oneMoreButtonState = gameObject.GetComponent<OneMoreButtonState>();
        oneMoreButtonAnim = oneMoreButton.GetComponent<Animator>();
        dummytxt = "잠재능력을 재설정 하시겠습니까?";
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time < 1.3f)
        {
            return;
        }
        else if( time > 1.3f)
        {
            if (WinInput.GetKeyDown(KeyCode.Return) && buttonLockImg.enabled && !isLock && txt.text == "잠재능력을 재설정 하시겠습니까?")
            {
                Pointer_Click();
                time = 0;
            }
        }
    }

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
        if (dummytxt == txt.text)   // 한 번 더 사용하기 눌렀을 경우
        {
            time = 0;
            SoundManager.instance.PlaySFX(eSound.Button);
            SoundManager.instance.PlaySFX(eSound.UseCube);
            window.transform.localScale = Vector3.zero;
            cubeText.Cube_Use();
            nop.UpdateText();

            bool isGradeUpAni = relics[PlayerPrefs.GetInt("SelectRelic")].SetUp();

            if (isGradeUpAni)
            {
                effectControl.GradeUp();
            }
            else
            {
                effectControl.Use();
            }
        }
        else                        // Npc 눌렀을 경우
        {
            int myMoney = PlayerPrefs.GetInt("CurMeso") - 100000;

            if(myMoney < 0)
            {
                SoundManager.instance.PlaySFX(eSound.Window);
                SoundManager.instance.PlaySFX(eSound.Button);
                txt.text = "메소가 부족합니다.";
                oneMoreYesButton.SetActive(false);
                oneMoreNoButton.SetActive(false);
                oKbtn2.SetActive(true);
                notPlayCo = true;
                return;
            }
            else if(myMoney >= 0)
            {
                SoundManager.instance.PlaySFX(eSound.Button);
                SoundManager.instance.PlaySFX(eSound.UseCube);
                effectControl.GradeUp();
                PlayerPrefs.SetInt("CurMeso", myMoney);
                mesoText.TextUpdate();
                relics[PlayerPrefs.GetInt("SelectRelic")].Open();
                oneMoreButtonState.Open();
                window.transform.localScale = Vector3.zero;
            }
        }

        if (PlayerPrefs.GetInt("Cube") == 0)
        {
            oneMoreButtonState.isLock = true;
            oneMoreButtonAnim.SetTrigger("Disabled");
        }

        if(!notPlayCo)
            StartCoroutine(Unlock());
    }

    IEnumerator Unlock()
    {
        yield return new WaitForSeconds(1.3f);
        buttonLockImg.enabled = false;
    }
}
