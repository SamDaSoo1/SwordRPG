using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    [SerializeField] GameObject optionPanel;
    [SerializeField] SoundControl soundControl;
    [SerializeField] GameObject buttonLockImg2;

    private void Awake()
    {
        optionPanel.SetActive(false);
        buttonLockImg2.SetActive(false);
    }

    public void OnClick()
    {
        SoundManager.instance.PlaySFX(eSound.Button);

        if(!optionPanel.activeSelf)
        {
            buttonLockImg2.SetActive(true);
            optionPanel.SetActive(true);
        }    
        else
        {
            soundControl.SoundSetting();
            optionPanel.SetActive(false);
            buttonLockImg2.SetActive(false);
        }
    }
}
