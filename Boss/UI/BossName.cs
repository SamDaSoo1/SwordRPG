using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossName : MonoBehaviour
{
    [SerializeField] TMP_Text bossName;
    List<string> bossNames;
    List<Color> face_Color;

    void Awake()
    {
        bossNames = new List<string>
        {
            "스우",
            "데미안",
            "루시드",
            "윌",
            "진 힐라",
            "검은 마법사"
        };

        face_Color = new List<Color>
        {
            new Color(1, 121/255f, 0, 1),
            new Color(154/255f, 0, 65/255f, 1),
            new Color(1, 0, 1, 1),
            new Color(152/255f, 152/255f, 152/255f, 1),
            new Color(140/255f, 164/255f, 0, 1),
            new Color(108/255f, 0, 0, 1)
        };

        bossName.text = bossNames[PlayerPrefs.GetInt("BossNum")];
        bossName.faceColor = face_Color[PlayerPrefs.GetInt("BossNum")];
        bossName.outlineColor = Color.black;
    }
}
