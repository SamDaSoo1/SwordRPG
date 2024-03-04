using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightBtnManager : MonoBehaviour
{
    [SerializeField] GameObject rightBtn;
    [SerializeField] GameObject leftBtn;

    static int page = 1;

    public static int Page
    {
        get { return page; }
        set
        {
            if (value > 6) { value = 6; }
            else if (value < 1) { value = 1; }
            page = value;
        }
    }

    private void Awake()
    {
        if(Page == 1) 
            leftBtn.SetActive(false);
    }

    public void StateCheck()
    {
        if (Page == 1)
        {
            LeftBtnDisable();
            RightBtnEnable();
        }
        else if (Page == 6)
        {
            LeftBtnEnable();
            RightBtnDisable();
        }
        else if (1 < Page && Page < 6)
        {
            LeftBtnEnable();
            RightBtnEnable();
        }
    }

    void RightBtnEnable()
    {
        rightBtn.SetActive(true);
    }

    void LeftBtnEnable()
    {
        leftBtn.SetActive(true);
    }

    void RightBtnDisable()
    {
        rightBtn.SetActive(false);
    }

    void LeftBtnDisable()
    {
        leftBtn.SetActive(false);
    }
}
