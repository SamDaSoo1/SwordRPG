using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] FeverMode feverMode;
    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] Animator criticalEffect;

    const float getScore_timeLimit = 1f;
    const float getScale_timeLimit = 0.1f;
    const float speed = 6.5f;

    Vector3 currentScale;

    readonly Vector3 scaleLimit = new Vector3(3f, 3f, 3f);

    public int Num { get; set; } = 0;

    void Awake()
    {
        tmp.text = 0.ToString();
        currentScale = tmp.rectTransform.localScale;
        criticalEffect.enabled = true;
    }

    private void Start()
    {
        criticalEffect.transform.position = new Vector3(0, 3.3f, 0);
    }

    public void Up(int weaponPower)
    {
        weaponPower += 1;
        StartCoroutine(GetScore(weaponPower));
        StartCoroutine(GetScale());
    }

    IEnumerator GetScore(int weaponPower)
    {
        float time = 0f;
        int criticalPer = Random.Range(0, 100);
        int critical = 1;
        if (criticalPer < PlayerPrefs.GetInt("CriticalPercentage"))
        {
            if (feverMode.Fever)
                critical = (2 + PlayerPrefs.GetInt("CriticalDamage")) * PlayerPrefs.GetInt("FeverDamage");
            else
                critical = 2 + PlayerPrefs.GetInt("CriticalDamage");

            //print("오우 크리터짐");
            //print(weaponPower * PlayerPrefs.GetInt("Damage") * critical);
            StartCoroutine(CriticalEffectCo());
        }  

        while (time < getScore_timeLimit)
        {
            tmp.text = ((int)Mathf.Lerp(Num, Num + (weaponPower * PlayerPrefs.GetInt("Damage") * critical), time / getScore_timeLimit)).ToString();
            time += Time.deltaTime * speed;
            yield return null;
        }

        Num += weaponPower * PlayerPrefs.GetInt("Damage") * critical;
        tmp.text = Num.ToString();
    }

    IEnumerator GetScale()
    {
        tmp.rectTransform.DOScale(scaleLimit, getScale_timeLimit);
        yield return new WaitForSeconds(getScale_timeLimit);
        tmp.rectTransform.DOScale(currentScale, getScale_timeLimit);
    }

    IEnumerator CriticalEffectCo()
    {
        yield return new WaitForSeconds(0.25f);
        criticalEffect.Play("Idle", -1, 0);
    }
}
