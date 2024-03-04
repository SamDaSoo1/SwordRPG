using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eSound
{
    BlackMage,
    BM1,
    BM2,
    BM3,
    BM4,
    Button,
    ButtonMouseOver,
    Demian,
    EnchantFail,
    Enchanting,
    EnchantSuccess,
    CubeBuyFail,
    JinHill,
    Lose,
    Lucid,
    MainBGM,
    Battle,
    RelicGet,
    RollUp,
    Swoo,
    UseCube,
    Will,
    Win,
    Window,
    RollDown,
    ScrollOpen,
    BuyShopItem,
    PlayButtonMouseOver,
    Damage,
    MesoGet,
    Die,
    Result,
    BlackMageShadow,
    GetCri,
    Text
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource bgm_player;
    [SerializeField] AudioSource sfx_player;

    List<AudioSource> audioSourcePool;

    private void Awake()
    {
        audioSourcePool = new List<AudioSource>();

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        
        bgm_player.volume = PlayerPrefs.GetFloat("BGMSound");
        sfx_player.volume = PlayerPrefs.GetFloat("SFXSound");

        //PlayBGM(eSound.MainBGM);
    }

    AudioSource GetSFX()
    {
        AudioSource select = null;

        foreach (AudioSource audioSource in audioSourcePool)
        {
            if (audioSource != null && !audioSource.isPlaying)
            {
                select = audioSource;
                break;
            }
        }

        if (select == null)
        {
            select = Instantiate(sfx_player, transform);
            audioSourcePool.Add(select);
        }

        return select;
    }

    public void PlaySFX(eSound type)
    {
        AudioSource sfx = GetSFX();
        sfx.clip = audioClips[(int)type];
        sfx.Play();
    }

    public void PlayBGM(eSound type)
    {
        bgm_player.clip = audioClips[(int)type];
        bgm_player.Play();
    }

    public void StopBGM()
    {
        bgm_player.Stop();
    }

    public void StopSFX()
    {
        foreach (AudioSource audioSource in audioSourcePool)
        {
            audioSource.Stop();
        }
    }

    public void BGMVolume(float volumeSize)
    {
        bgm_player.volume = volumeSize;
        PlayerPrefs.SetFloat("BGMSound", bgm_player.volume);
    }

    public void SFXSoundSetting(float volumeSize)
    {
        foreach (AudioSource audioSource in audioSourcePool)
        {
            audioSource.volume = volumeSize;
        }
        sfx_player.volume = volumeSize;
        PlayerPrefs.SetFloat("SFXSound", sfx_player.volume);
    }
}
