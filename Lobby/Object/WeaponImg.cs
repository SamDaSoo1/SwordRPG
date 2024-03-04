using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponImg : MonoBehaviour
{
    [SerializeField] List<Sprite> weaponImgs;
    Image sr;

    private void Awake()
    {
        sr = GetComponent<Image>();
        sr.sprite = weaponImgs[PlayerPrefs.GetInt("weaponLv")];
    }

    public void WeaponImgUpdate()
    {
        sr.sprite = weaponImgs[PlayerPrefs.GetInt("weaponLv")];
    }
}
