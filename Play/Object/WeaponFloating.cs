using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFloating : MonoBehaviour
{
    Vector3 currentPos;
    Vector3 pointPos = new Vector3(0, -3.9f, 0);
    float time = 0f;
    private void Start()
    {
        currentPos = transform.position;
        StartCoroutine(Floating());
    }

    IEnumerator Floating()
    {
        while(time < 1f)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(currentPos, pointPos, time / 1f);
            yield return null;
        }

        transform.position = pointPos;
        time = 0f;

        yield return null;

        while (time < 1f)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(pointPos, currentPos, time / 1f);
            yield return null;
        }

        transform.position = currentPos;

        yield return null;
        time = 0f;
        StartCoroutine(Floating());
    }
}
