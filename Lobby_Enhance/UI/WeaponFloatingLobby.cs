using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponFloatingLobby : MonoBehaviour
{
    public Image img;            // 무기 이미지
    float yPos = 0f;
    readonly WaitForSeconds waitForSeconds = new(0.05f);

    void Start()
    {
        img = GetComponent<Image>();
        
        StartCoroutine(FloatingDown());
    }

    // 중앙의 무기가 서서히 내려가는 코루틴, 끝나면 무기가 올라가는 코루틴을 호출
    IEnumerator FloatingDown()
    {
        yPos = transform.position.y;

        for (int i = 0; i < 16; i++)
        {
            yPos -= 0.005f;
            transform.position = new Vector2(transform.position.x, yPos);
            yield return waitForSeconds;
        }

        StartCoroutine(FloatingUp());
    }

    // 중앙의 무기가 서서히 올라가는 코루틴, 끝나면 무기가 내려가는 코루틴을 호출
    IEnumerator FloatingUp()
    {
        yPos = transform.position.y;

        for (int i = 0; i < 16; i++)
        {
            yPos += 0.005f;
            transform.position = new Vector2(transform.position.x, yPos);
            yield return waitForSeconds;
        }

        StartCoroutine(FloatingDown());
    }
}
