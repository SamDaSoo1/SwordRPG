using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightBtnState : MonoBehaviour
{
    [SerializeField] GameObject rightBtn;
    [SerializeField] GameObject leftBtn;

    int page = 1;

    public int Page
    {
        get { return page; }
        set
        {
            if (value > 11) { value = 11; }
            else if (value < 1) { value = 1; }
            page = value;
        }
    }

    private void Awake()
    {
        leftBtn.SetActive(false);
    }

    public void StateCheck()
    {
        if(Page == 1)
        {
            LeftBtnDisable();
            RightBtnEnable();
        }
        else if (Page == 11)
        {
            LeftBtnEnable();
            RightBtnDisable();
        }
        else if (1 < Page && Page < 11)
        {
            LeftBtnEnable();
            RightBtnEnable();
        }
    }

    public void RightBtnEnable()
    {
        rightBtn.SetActive(true);
    }

    public void LeftBtnEnable()
    {
        leftBtn.SetActive(true);
    }

    public void RightBtnDisable()
    {
        rightBtn.SetActive(false);
    }

    public void LeftBtnDisable()
    {
        leftBtn.SetActive(false);
    }
}
