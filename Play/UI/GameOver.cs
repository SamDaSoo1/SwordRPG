using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] Score score;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject result;
    [SerializeField] GameObject particle;
    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] NoteFailGauge noteFailGauge;

    Vector3 resultScale1 = new Vector3(1f, 1.45f, 1f);
    Vector3 resultScale2 = new Vector3(8f, 11.6f, 1f);
    Vector3 resultScale3 = new Vector3(9f, 13.05f, 1f);
    readonly float timeLimit = 0.15f;

    private void Awake()
    {
        gameOver.SetActive(false);
        result.transform.localScale = resultScale1;
        particle.SetActive(false);
        tmp.text = 0.ToString();
    }

    public void GameOverOn()
    {
        int meso = PlayerPrefs.GetInt("CurMeso") + (score.Num * PlayerPrefs.GetInt("MesoAcquisitionAmount"));
        PlayerPrefs.SetInt("CurMeso", meso);

        noteFailGauge.KeyBoardLock = true;
        StartCoroutine(ResultWindow());
    }

    IEnumerator ResultWindow()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySFX(eSound.Result);
        gameOver.SetActive(true);
        float time = 0f;

        while (time < timeLimit)
        {
            result.transform.localScale = Vector3.Lerp(resultScale1, resultScale3, time / timeLimit);
            time += Time.deltaTime;
            yield return null;
        }
        result.transform.localScale = resultScale3;
        time = 0f;

        while (time < timeLimit)
        {
            result.transform.localScale = Vector3.Lerp(resultScale3, resultScale2, time / timeLimit);
            time += Time.deltaTime;
            yield return null;
        }
        result.transform.localScale = resultScale2;
        Invoke("ParticleOn", 0.5f);
        StartCoroutine(GetMeso());
    }

    void ParticleOn()
    {
        particle.SetActive(true);
    }

    IEnumerator GetMeso()
    {
        yield return new WaitForSeconds(1.1f);
        float time = 0f;
        StartCoroutine(GetMesoSound());

        while (time < 1.4f)
        {
            tmp.text = ((int)Mathf.Lerp(0, score.Num * PlayerPrefs.GetInt("MesoAcquisitionAmount"), time / 1.4f)).ToString();
            time += Time.deltaTime;
            yield return null;
        }

        tmp.text = (score.Num * PlayerPrefs.GetInt("MesoAcquisitionAmount")).ToString();
    }

    IEnumerator GetMesoSound()
    {
        for(int i = 0; i < 10; i++)
        {
            SoundManager.instance.PlaySFX(eSound.MesoGet);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
