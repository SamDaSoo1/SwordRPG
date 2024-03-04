using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbabilityButton : MonoBehaviour
{
    [SerializeField] GameObject probabilityTable;
    [SerializeField] GameObject probabilityTable2;

    int count = 0;

    private void Awake()
    {
        probabilityTable.SetActive(false);
    }

    public void OnClick()
    {
        count++;

        if(probabilityTable2.activeSelf)
        {
            probabilityTable2.SetActive(false);
            gameObject.GetComponent<ProbabilityButton2>().CountUp();
        }

        if (count % 2 == 0)
        {
            SoundManager.instance.PlaySFX(eSound.ScrollOpen);
            probabilityTable.SetActive(false);
        }
        else if (count % 2 == 1)
        {
            SoundManager.instance.PlaySFX(eSound.ScrollOpen);
            probabilityTable.SetActive(true);
        }
            
    }

    public void CountUp()
    {
        count++;
    }
}
