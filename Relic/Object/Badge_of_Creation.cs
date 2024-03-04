using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badge_of_Creation : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetInt("RelicSilhouette") > 5)
            spriteRenderer.color = Color.white;
        else
            spriteRenderer.color = Color.black;
    }
}
