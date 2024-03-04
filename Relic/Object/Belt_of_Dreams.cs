using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt_of_Dreams : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetInt("RelicSilhouette") > 2)
            spriteRenderer.color = Color.white;
        else
            spriteRenderer.color = Color.black;
    }
}
