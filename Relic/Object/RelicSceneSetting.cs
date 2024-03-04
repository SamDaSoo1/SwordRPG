using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RelicSceneSetting : MonoBehaviour
{
    [SerializeField] TMP_Text confirm_Acquisition_Text;
    [SerializeField] TMP_Text relicName;

    private void Awake()
    {
        confirm_Acquisition_Text.faceColor = new Color(190/255f, 0, 0, 1);
        relicName.faceColor = new Color(0, 224 / 255f, 163 / 255f, 1);
    }
}
