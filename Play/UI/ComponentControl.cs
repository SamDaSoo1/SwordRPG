using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentControl : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvas_BlackMageDieText;

    private void Awake()
    {
        canvas_BlackMageDieText.SetActive(false);
    }

    public void ComponentDisable()
    {
        canvas.GetComponent<Score>().enabled = false;
        canvas.GetComponent<GameOver>().enabled = false;
        canvas.GetComponent<BossHp>().enabled = true;
    }

    public void ComponentEnable()
    {
        canvas.GetComponent<Score>().enabled = true;
        canvas.GetComponent<GameOver>().enabled = true;
        canvas.GetComponent<BossHp>().enabled = false;
    }
}
