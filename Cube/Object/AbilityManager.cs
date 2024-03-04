using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    // Rare -> Epic : 15%
    // Epic -> Unique : 3.5%
    // Unique -> Legendary : 1.4%

    [SerializeField] Text grade;
    [SerializeField] Text notLiberated;
    [SerializeField] Text abil1;
    [SerializeField] Text abil2;
    [SerializeField] Text abil3;
    [SerializeField] string[] abilityOptions;

    readonly Dictionary<string, int[]> optionTable = new Dictionary<string, int[]>
    {
        { "레어", new int[] { 17, 34, 51, 68, 85, 100 } },
        { "에픽", new int[] { 85, 170, 255, 340, 425, 500, 590, 680, 770, 860, 950, 1000 } },
        { "유니크", new int[] { 55, 110, 165, 220, 275, 330, 385, 440, 495, 550, 605, 660, 718, 776, 834, 892, 950, 1000 } },
        { "레전드리", new int[] { 416, 832, 1248, 1664, 2080, 2496, 2912, 3328, 3744, 4160, 4576, 4992, 5408, 5824, 6240, 6656, 7072, 7488, 7904, 8320, 8736, 9152, 9568, 9984, 10000 } }
    };

    public string Option(int index, string grade)
    {
        string option = "";

        for (int i = 0; i < optionTable[grade].Length; i++)
        {
            if (index < optionTable[grade][i])
            {
                option = abilityOptions[i];
                break;
            }
        }
        return option;
    }

    public void NotLiberatedTextDisable()
    {
        notLiberated.enabled = false;
    }

    public IEnumerator AbilityOpenTextUpdate(string ability1, string ability2, string ability3, string ability4)
    {
        yield return new WaitForSeconds(0.2f);
        abil1.text = ability1;
        abil2.text = ability2;
        abil3.text = ability3;
        grade.text = ability4;
    }
}
