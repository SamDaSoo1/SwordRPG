using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursed_Grimoire : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetInt("RelicSilhouette") > 3)
            spriteRenderer.color = Color.white;
        else
            spriteRenderer.color = Color.black;
    }
}
