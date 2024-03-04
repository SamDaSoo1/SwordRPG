using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YesButtonState : MonoBehaviour,IPointerState
{
    [SerializeField] Quantity quantity;
    [SerializeField] BuyCompleteText buyCompleteText;
    [SerializeField] BuyFailText buyFailText;
    [SerializeField] GameObject window;
    [SerializeField] TMP_Text tmp;
    [SerializeField] Animator animator;
    [SerializeField] CubePrice cubePrice;
    [SerializeField] MesoText mesoText;

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
        

        int myMoney = PlayerPrefs.GetInt("CurMeso") - cubePrice.num;

        if(myMoney < 0)
        {
            SoundManager.instance.PlaySFX(eSound.CubeBuyFail);
            buyFailText.ModifyText("메소가 부족합니다.", new Color(190 / 255f, 0, 0, 1));
            buyFailText.Disappear();
        }
        else if(myMoney >= 0) 
        {
            SoundManager.instance.PlaySFX(eSound.Button);
            SoundManager.instance.PlaySFX(eSound.BuyShopItem);

            buyCompleteText.Disappear();

            PlayerPrefs.SetInt("CurMeso", myMoney);
            mesoText.TextUpdate();

            int cubeNum = PlayerPrefs.GetInt("Cube") + quantity.Count;
            tmp.text = string.Format("{0:N0}", cubeNum);
            PlayerPrefs.SetInt("Cube", cubeNum);
        }

        window.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
