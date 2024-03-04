using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Setting2 : MonoBehaviour
{
    [SerializeField] Score score;

    void Start()
    {
        if (score.enabled) { SoundManager.instance.PlayBGM(eSound.Battle); }
        else { PlayBossBGM(); }
    }

    void PlayBossBGM()
    {
        int boss = PlayerPrefs.GetInt("BossNum");
        switch (boss)
        {
            case 0: SoundManager.instance.PlayBGM(eSound.Swoo); break;
            case 1: SoundManager.instance.PlayBGM(eSound.Demian); break;
            case 2: SoundManager.instance.PlayBGM(eSound.Lucid); break;
            case 3: SoundManager.instance.PlayBGM(eSound.Will); break;
            case 4: SoundManager.instance.PlayBGM(eSound.JinHill); break;
            case 5: SoundManager.instance.PlayBGM(eSound.BlackMage); break;
        }
    }
}
