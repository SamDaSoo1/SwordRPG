using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    [SerializeField] Slider bgm_Sound;
    [SerializeField] Slider sfx_Sound;

    private void Start()
    {
        bgm_Sound.maxValue = 1;
        sfx_Sound.maxValue = 1;
        bgm_Sound.value = PlayerPrefs.GetFloat("BGMSound");
        sfx_Sound.value = PlayerPrefs.GetFloat("SFXSound");
        SoundManager.instance.BGMVolume(bgm_Sound.value);
        SoundManager.instance.SFXSoundSetting(sfx_Sound.value);
    }

    public void SoundSetting()
    {
        SoundManager.instance.BGMVolume(bgm_Sound.value);
        SoundManager.instance.SFXSoundSetting(sfx_Sound.value);
    }
}
