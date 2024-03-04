using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponFloatingLobby : MonoBehaviour
{
    public Image img;            // ���� �̹���
    float yPos = 0f;
    readonly WaitForSeconds waitForSeconds = new(0.05f);

    void Start()
    {
        img = GetComponent<Image>();
        
        StartCoroutine(FloatingDown());
    }

    // �߾��� ���Ⱑ ������ �������� �ڷ�ƾ, ������ ���Ⱑ �ö󰡴� �ڷ�ƾ�� ȣ��
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

    // �߾��� ���Ⱑ ������ �ö󰡴� �ڷ�ƾ, ������ ���Ⱑ �������� �ڷ�ƾ�� ȣ��
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
