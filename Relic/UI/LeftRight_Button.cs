using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeftRight_Button : MonoBehaviour
{
    [SerializeField] Animator leftAnimator;
    [SerializeField] Animator rightAnimator;
    [SerializeField] SelectRelic selectRelic;
    [SerializeField] Confirm_Acquisition ca;
    [SerializeField] TMP_Text relicName;
    [SerializeField] LeftRightBtnManager leftRightBtnManager;

    string[] relicNames = new string[] { "루즈 컨트롤 머신 마크", "마력이 깃든 안대", "몽환의 벨트", "저주받은 마도서", "고통의 근원", "창세의 뱃지" };

    List<string> relicNameList;
    
    public bool IsLock {  get; set; }

    private void Awake()
    {
        int num = PlayerPrefs.GetInt("RelicNames");

        relicNameList = new List<string>();

        for(int i = 0; i < num; i++)
        {
            relicNameList.Add(relicNames[i]);
        }

        for (int i = num; i < 6; i++)
        {
            relicNameList.Add("???");
        }

        relicName.text = relicNameList[PlayerPrefs.GetInt("SelectRelic")];
    }

    public void LeftDown()
    {
        leftAnimator.SetTrigger("Pressed");
    }

    public void LeftUp()
    {
        leftAnimator.SetTrigger("Normal");
    }

    public void LeftClick()
    {
        SoundManager.instance.PlaySFX(eSound.Button);

        if (IsLock) { return; }
       
        selectRelic.MoveRight();

        --LeftRightBtnManager.Page;
        leftRightBtnManager.StateCheck();

        int selectNum = PlayerPrefs.GetInt("SelectRelic");
        selectNum -= 1;
        if(selectNum < 0) { selectNum = 0; }

        PlayerPrefs.SetInt("SelectRelic", selectNum);

        relicName.text = relicNameList[PlayerPrefs.GetInt("SelectRelic")];
    }

    public void RightDown()
    {
        rightAnimator.SetTrigger("Pressed");
    }

    public void RightUp()
    {
        rightAnimator.SetTrigger("Normal");
    }

    public void RightClick()
    {
        SoundManager.instance.PlaySFX(eSound.Button);

        if (IsLock) { return; }

        selectRelic.MoveLeft();

        ++LeftRightBtnManager.Page;
        leftRightBtnManager.StateCheck();

        int selectNum = PlayerPrefs.GetInt("SelectRelic");
        selectNum += 1;
        if (selectNum > 5) { selectNum = 5; }

        PlayerPrefs.SetInt("SelectRelic", selectNum);
        relicName.text = relicNameList[PlayerPrefs.GetInt("SelectRelic")];
    }
}
