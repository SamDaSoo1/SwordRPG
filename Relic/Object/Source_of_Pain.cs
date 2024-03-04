using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source_of_Pain : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetInt("RelicSilhouette") > 4)
            spriteRenderer.color = Color.white;
        else
            spriteRenderer.color = Color.black;
    }
}
