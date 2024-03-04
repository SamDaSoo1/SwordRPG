using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilityButton2 : MonoBehaviour
{
    [SerializeField] GameObject probabilityTable;
    [SerializeField] GameObject probabilityTable2;

    int count = 0;

    private void Awake()
    {
        probabilityTable2.SetActive(false);
    }

    public void OnClick()
    {
        count++;

        if (probabilityTable.activeSelf)
        {
            probabilityTable.SetActive(false);
            gameObject.GetComponent<ProbabilityButton>().CountUp();
        }

        if (count % 2 == 0)
        {
            SoundManager.instance.PlaySFX(eSound.ScrollOpen);
            probabilityTable2.SetActive(false);
        }
        else if (count % 2 == 1)
        {
            SoundManager.instance.PlaySFX(eSound.ScrollOpen);
            probabilityTable2.SetActive(true);
        }

    }

    public void CountUp()
    {
        count++;
    }
}
