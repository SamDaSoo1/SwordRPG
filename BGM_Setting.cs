using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM_Setting : MonoBehaviour
{
    static BGM_Setting instance;

    void Awake()
    {
        if(instance == null)
        {
            SoundManager.instance.PlayBGM(eSound.MainBGM);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
           
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Play")
        {
            Destroy(gameObject);
        }
    }
}
