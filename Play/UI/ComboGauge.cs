using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboGauge : MonoBehaviour
{
    [SerializeField] FeverMode feverMode;
    [SerializeField] GameObject comboGauge;
    [SerializeField] Image fill;
    [SerializeField] Slider bossHp;
    [SerializeField] NoteDown noteDown;
    Slider slider;
    bool isFever = false;

    void Awake()
    {
        bossHp.value = bossHp.maxValue;
        slider = comboGauge.GetComponent<Slider>();
        slider.maxValue = 100;                         // ³ªÁß¿¡ 100À¸·Î ¹Ù²Ù¼À
        slider.value = 0;
        comboGauge.SetActive(false);
    }

    public void ComboGaugeUpdate()
    {
        if(!comboGauge.activeSelf)
            comboGauge.SetActive(true);

        if (isFever) return;

        slider.value += 1 + PlayerPrefs.GetInt("FeverChargeAmount");
        if (slider.value == slider.maxValue)
        {
            feverMode.FeverOn();
        }
    }

    public void ComboGaugeReset()
    {
        slider.value = 0;
        comboGauge.SetActive(false);
    }

    public void ComboGaugeDecreaseStart()
    {
        isFever = true;
        ColorChange();
        StartCoroutine(ComboGaugeDecrease());

        if (PlayerPrefs.GetInt("AutoClick") == 1)
        {
            noteDown.AutoClicking = true;
            StartCoroutine(noteDown.AutoClickCo());
        } 
    }

    IEnumerator ComboGaugeDecrease()
    {
        float feverTime = PlayerPrefs.GetInt("FeverTime");
        float time = 3f + feverTime;

        while (time > 0f)
        {
            if(bossHp.value == 0) yield break;                              // ÀÌ°Ô ¸Â³ª..  comboGauge.StopAllCoroutines();¶û °ãÄ§
            slider.value = Mathf.Lerp(0, slider.maxValue, time / (3f + feverTime));
            time -= Time.deltaTime;
            yield return null;
        }
        slider.value = 0;
        noteDown.StopAllCoroutines();
        noteDown.AutoClicking = false;
        feverMode.FeverOff();
        ColorReset();
        isFever = false;
    }

    void ColorChange()
    {
        fill.color = new Color(0, 1, 1, 1);
    }

    void ColorReset()
    {
        fill.color = Color.white;
    }
}
