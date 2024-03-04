using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rouge_Control_Machine_Mark : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetInt("RelicSilhouette") > 0)
            spriteRenderer.color = Color.white;
        else
            spriteRenderer.color = Color.black;
    }
}
