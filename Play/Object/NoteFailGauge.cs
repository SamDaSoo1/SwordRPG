using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NoteFailGauge : MonoBehaviour
{
    [SerializeField] GameObject noteFailGauge;
    [SerializeField] SpriteRenderer icon;

    Slider slider;
    public bool KeyBoardLock { get; set; }

    private void Awake()
    {
        slider = noteFailGauge.GetComponent<Slider>();
        noteFailGauge.SetActive(false);
        icon.enabled = false;
    }

    public void GaugeOn()
    {
        icon.enabled = true;
        noteFailGauge.SetActive(true);
        slider.value = slider.maxValue;
        StartCoroutine(GaugeDown());
    }

    IEnumerator GaugeDown()
    {
        float time = 0.5f;

        while(slider.value != 0f)
        {
            slider.value = time;
            time -= Time.deltaTime;
            yield return null;
        }
        slider.value = 0;
        icon.enabled = false;
        noteFailGauge.SetActive(false);

        KeyBoardLock = false;
    }
}
