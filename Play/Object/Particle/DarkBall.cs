using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBall : MonoBehaviour
{
    [SerializeField] GameObject darkBall;
    [SerializeField] GameObject darkBallEnd;
    List<GameObject> pool1;
    List<GameObject> pool2;
    float effectGap = 0.25f;

    private void Start()
    {
        pool1 = new List<GameObject>();
        pool2 = new List<GameObject>();
    }

    public void Shoot()
    {
        GetDarkBall();
        Invoke("GetDarkBallEnd", effectGap);
    }

    void GetDarkBall()
    {
        GameObject select = null;

        foreach(GameObject effect in pool1)
        {
            if(effect.activeSelf == false)
            {
                select = effect;
                select.SetActive(true);
                break;
            }
        }

        if(select == null) 
        {
            select = Instantiate(darkBall, transform);
            select.SetActive(true);
            pool1.Add(select);
        }
    }

    void GetDarkBallEnd()
    {
        GameObject select = null;

        foreach (GameObject effect in pool2)
        {
            if (effect.activeSelf == false)
            {
                select = effect;
                select.SetActive(true);
                break;
            }
        }

        if (select == null)
        {
            select = Instantiate(darkBallEnd, transform);
            select.SetActive(true);
            pool2.Add(select);
        }
    }
}
